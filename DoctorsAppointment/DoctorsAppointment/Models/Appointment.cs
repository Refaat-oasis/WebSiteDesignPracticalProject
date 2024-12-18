using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsAppointment.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public TimeSpan AppointmentHour { get; set; }
        public int? Age { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }


        public virtual User User { get; set; }
        public virtual Admin Admin { get; set; }


    }
}
