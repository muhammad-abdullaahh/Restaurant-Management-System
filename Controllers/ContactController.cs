using Microsoft.AspNetCore.Mvc;
using FoodHeaven.Data;
using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: Contact/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                contactMessage.CreatedAt = DateTime.Now;
                contactMessage.IsRead = false;

                _context.ContactMessages.Add(contactMessage);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Thank you for contacting us! We'll get back to you soon.";
                return RedirectToAction(nameof(Index));
            }

            return View("Index", contactMessage);
        }

        // POST: Contact/SubmitAjax (for AJAX submissions)
        [HttpPost]
        public async Task<JsonResult> SubmitAjax([FromBody] ContactMessage message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    message.CreatedAt = DateTime.Now;
                    message.IsRead = false;

                    _context.ContactMessages.Add(message);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Thank you for contacting us! We'll get back to you soon." });
                }

                return Json(new { success = false, message = "Please fill in all required fields correctly." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
