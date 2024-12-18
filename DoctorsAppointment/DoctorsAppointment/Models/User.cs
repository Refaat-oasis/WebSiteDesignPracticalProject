﻿using System.ComponentModel.DataAnnotations;

namespace DoctorsAppointment.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual List<Appointment> AppointmentsList { get; set; }
    }
}
