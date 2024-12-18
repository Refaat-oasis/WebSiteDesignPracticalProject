using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointment.Models
{
    public class Context:DbContext
    {
        public Context() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EFNEGP3;Initial Catalog=DoctorsAppointmentsDB2;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        //public DbSet<AppointmentToView> appointmentWithUserName_AdminNames { get; set; }

    }
}
