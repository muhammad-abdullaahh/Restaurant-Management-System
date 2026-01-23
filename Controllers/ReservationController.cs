using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using FoodHeaven.Services;

namespace FoodHeaven.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public ReservationController(ApplicationDbContext context, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.CreatedAt = DateTime.Now;
                reservation.Status = "Confirmed";

                // Ensure ReservationType is set if null
                if (string.IsNullOrEmpty(reservation.ReservationType))
                {
                    reservation.ReservationType = "Standard";
                }

                // Calculate Cost and set Flags
                if (reservation.ReservationType == "Premium")
                {
                    reservation.IsPremiumTable = true;
                    reservation.EstimatedCost = reservation.PartySize * 15.00m;
                    // reservation.ReservationType remains "Premium"
                }
                else if (reservation.ReservationType == "PrivateParty")
                {
                    reservation.IsPremiumTable = false; // Or true if private party implies premium, but usually distinct in this logic
                    reservation.EstimatedCost = 0; // Custom quote usually
                    // reservation.ReservationType remains "PrivateParty"
                }
                else 
                {
                    // Standard
                    reservation.IsPremiumTable = false;
                    reservation.EstimatedCost = 0;
                    reservation.ReservationType = "Standard";
                }

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();

                // Send SMS Confirmation (Silently handle errors/simulation)
                try {
                    SendSmsConfirmation(reservation.PhoneNumber, reservation.CustomerName, reservation.ReservationDate, reservation.ReservationTime);
                } catch (Exception ex) {
                    Console.WriteLine("SMS Failed: " + ex.Message);
                }

                // Send Email Confirmation
                if (!string.IsNullOrEmpty(reservation.Email))
                {
                    try
                    {
                        // Format the table type for display
                        string displayTableType = reservation.ReservationType switch
                        {
                            "PrivateParty" => "Private Party",
                            "Premium" => "Premium",
                            _ => "Standard"
                        };

                        string emailSubject = $"Reservation Confirmation - {displayTableType} Table";
                        string emailBody = $@"
                            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; color: #333;'>
                                <div style='background-color: #000; padding: 20px; text-align: center; border-radius: 10px 10px 0 0;'>
                                    <h1 style='color: #fff; margin: 0;'>FoodHeaven</h1>
                                </div>
                                <div style='padding: 20px; border: 1px solid #ddd; border-top: none; border-radius: 0 0 10px 10px;'>
                                    <h2 style='color: #d4a017;'>Reservation Confirmed!</h2>
                                    <p>Dear {reservation.CustomerName},</p>
                                    <p>We are delighted to confirm your <strong>{displayTableType}</strong> reservation at FoodHeaven.</p>
                                    
                                    <table style='width: 100%; border-collapse: collapse; margin: 20px 0;'>
                                        <tr>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>📅 Date:</strong></td>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'>{reservation.ReservationDate.ToShortDateString()}</td>
                                        </tr>
                                        <tr>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>⏰ Time:</strong></td>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'>{DateTime.Today.Add(reservation.ReservationTime).ToString("hh:mm tt")}</td>
                                        </tr>
                                        <tr>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>👥 Guests:</strong></td>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'>{reservation.PartySize}</td>
                                        </tr>
                                        <tr>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>🍽️ Table Type:</strong></td>
                                            <td style='padding: 10px; border-bottom: 1px solid #eee;'>{displayTableType}</td>
                                        </tr>
                                        {(reservation.ReservationType == "Premium" ? $"<tr><td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>💰 Estimated Cost:</strong></td><td style='padding: 10px; border-bottom: 1px solid #eee;'>${reservation.EstimatedCost}</td></tr>" : "")}
                                    </table>

                                    <p>We look forward to serving you an unforgettable dining experience.</p>
                                    <br/>
                                    <p>Best Regards,<br/><strong>The FoodHeaven Team</strong></p>
                                </div>
                            </div>";

                        await _emailService.SendEmailAsync(reservation.Email, emailSubject, emailBody);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Email Failed: " + ex.Message);
                    }
                }

                string typeMsg = reservation.ReservationType == "Premium" ? "Premium" : 
                                 (reservation.ReservationType == "PrivateParty" ? "Private Party" : "Standard");
                TempData["SuccessMessage"] = $"{typeMsg} Reservation Confirmed! A confirmation email has been sent to {reservation.Email}.";
                
                return RedirectToAction(nameof(Confirmation), new { id = reservation.Id });
            }

            return View(reservation);
        }

        // GET: Reservation/Confirmation/{id}
        public async Task<IActionResult> Confirmation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservation/Cancel
        [HttpPost]
        public async Task<JsonResult> Cancel(int id)
        {
            try
            {
                var reservation = await _context.Reservations.FindAsync(id);
                if (reservation == null)
                {
                    return Json(new { success = false, message = "Reservation not found" });
                }

                reservation.Status = "Cancelled";
                reservation.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Reservation cancelled successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: Reservation/CheckAvailability
        [HttpGet]
        public async Task<JsonResult> CheckAvailability(DateTime date, string time, string tableNumber)
        {
            var timeSpan = TimeSpan.Parse(time);
            
            var existingReservation = await _context.Reservations
                .AnyAsync(r => r.ReservationDate.Date == date.Date 
                    && r.ReservationTime == timeSpan 
                    && r.TableNumber == tableNumber
                    && r.Status == "Confirmed");

            return Json(new { available = !existingReservation });
        }

        private bool SendSmsConfirmation(string phoneNumber, string name, DateTime date, TimeSpan time)
        {
            var accountSid = _configuration["Twilio:AccountSid"];
            var authToken = _configuration["Twilio:AuthToken"];
            var fromNumber = _configuration["Twilio:PhoneNumber"];

            // Check if configured (ignore placeholder values)
            if (!string.IsNullOrEmpty(accountSid) && 
                !string.IsNullOrEmpty(authToken) && 
                !string.IsNullOrEmpty(fromNumber) &&
                !fromNumber.Contains("YOUR_TWILIO_NUMBER"))
            {
                try {
                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        body: $"Hello {name}, your table at FoodHeaven is reserved for {date.ToShortDateString()} at {time}. We look forward to seeing you!",
                        from: new PhoneNumber(fromNumber),
                        to: new PhoneNumber(phoneNumber)
                    );
                    
                    Console.WriteLine($"[SMS SENT] SID: {message.Sid}");
                    return true;
                }
                catch (Exception ex) {
                    Console.WriteLine($"[SMS FAILURE] {ex.Message}");
                    return false;
                }
            }
            else
            {
                // Fallback to simulation
                Console.WriteLine($"[SMS SIMULATION] To: {phoneNumber} - Body: Hello {name}, your table at FoodHeaven is reserved for {date:d} at {time}.");
                return false;
            }
        }
    }
}
