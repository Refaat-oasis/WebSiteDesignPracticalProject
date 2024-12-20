using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsAppointment.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Appointment hour is required.")]
        public TimeSpan AppointmentHour { get; set; }

        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
        public int Age { get; set; }

        [ForeignKey("User")]
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [ForeignKey("Doctor")]
        [Required(ErrorMessage = "Doctor ID is required.")]
        public int DoctorId { get; set; }

        public virtual User User { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
