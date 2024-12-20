using DoctorsAppointment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        Context context = new Context();
        public IActionResult showAdminAppointments()
        {
            List<Admin> adminList = context.Admins.ToList();
            List<Appointment> appointmentList = context.Appointments.Select(e => e).ToList();
            return View(appointmentList);
        }

        public IActionResult showUserAppointments(int id)
        {

            List<Appointment> appointmentList = context.Appointments
                .Where(e => e.UserId == id)
                .ToList();

            return View(appointmentList);
        }
        public IActionResult showDoctorAppointments(int id)
        {

            List<Appointment> appointmentList = context.Appointments
                .Where(e => e.DoctorId == id)
                .ToList();

            return View(appointmentList);
        }


        public IActionResult ShowAdminSpecificAppointment(int id)
        {
            var appointment = context.Appointments
                                     .Include(a => a.User) 
                                     .FirstOrDefault(ap => ap.Id == id);

            if (appointment == null)
            {
                return NotFound(); 
            }

            List<User> userList = context.Users.ToList();
            List<Doctor> doctorList = context.Doctors.ToList();
            ViewData["users"] = userList;
            ViewData["doctors"] = doctorList;

            ViewBag.UserName = appointment.User?.Name ?? "User not found";

            return View(appointment); 
        }


        public IActionResult addAppointement()
        {
            List<User> userList = context.Users.ToList();
            List<Doctor>doctorList = context.Doctors.ToList();

            ViewData["Doctors"] = doctorList;
            ViewData["users"] = userList;
            return View();
        }

        public IActionResult addAppointmentSave(Appointment appoint)
        { 
            if (appoint.Name != null & appoint.AppointmentHour != null & appoint.CreatedDate != null & appoint.PhoneNumber != null 
                & appoint.Address != null & appoint.DoctorId != null & appoint.UserId != null )
            {
                context.Appointments.Add(appoint);
                context.SaveChanges();
                return RedirectToAction("showAdminAppointments");

            }
            else
            {
                return View("addAppointement");
            }
        }

        public IActionResult deleteAppointement(int id)
        {
            Appointment appoint = context.Appointments.FirstOrDefault(ap => ap.Id == id);
            context.Appointments.Remove(appoint);
            context.SaveChanges();
            return RedirectToAction("showAdminAppointments");
        }
        public IActionResult modifyAppointment(int id)
        {
            List<User> userList = context.Users.ToList();
            List<Doctor> doctorsList = context.Doctors.ToList();
            ViewData["doctors"] = doctorsList;
            ViewData["users"] = userList;

            Appointment oldappoint = context.Appointments.FirstOrDefault(appoint => appoint.Id == id);
            return View("modifyAppointment", oldappoint);
        }
        public IActionResult modifyAppointmentSave(Appointment appoint, int id)
        {

            if (appoint != null)
            {
                Appointment oldappoint = context.Appointments.FirstOrDefault(appoint => appoint.Id == id);
                oldappoint.Name = appoint.Name;
                oldappoint.UserId = appoint.UserId;
                oldappoint.AppointmentHour = appoint.AppointmentHour;
                oldappoint.PhoneNumber = appoint.PhoneNumber;
                oldappoint.DoctorId = appoint.DoctorId;
                oldappoint.Address = appoint.Address;
                oldappoint.Age = appoint.Age;
                oldappoint.CreatedDate = appoint.CreatedDate;

                context.SaveChanges();
                return RedirectToAction("showAdminAppointments");
            }
            else
            {
                return View("modifyAppointment");
            }

        }

    }
}
