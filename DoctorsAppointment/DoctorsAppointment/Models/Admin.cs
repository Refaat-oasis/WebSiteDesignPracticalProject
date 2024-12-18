using System.ComponentModel.DataAnnotations;

namespace DoctorsAppointment.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual List<Appointment> AppointmentsList { get; set; }
    }
}
