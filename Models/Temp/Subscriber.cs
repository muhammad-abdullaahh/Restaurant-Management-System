using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Models.Temp;

public partial class Subscriber
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public DateTime SubscribedAt { get; set; }
}
