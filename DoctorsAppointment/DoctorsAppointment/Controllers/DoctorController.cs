using DoctorsAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAppointment.Controllers
{
    public class DoctorController : Controller
    {
        Context context = new Context();
        public IActionResult doctorLogin(Doctor Doc)
        {
            Doctor doctor = context.Doctors.FirstOrDefault
            (doctor => doctor.Email == Doc.Email && doctor.Password == Doc.Password);
            if (doctor != null)
            {
                return View("Doctorhome", doctor);
            }
            else
            {
                return View();
            }
        }
        public IActionResult doctorSignUp()
        {
            return View();
        }
        public IActionResult doctorSignupSave(Doctor doc)
        {
            if (doc.Email != null & doc.Name != null & doc.Password != null
               & doc.Age != null & doc.Address != null & doc.PhoneNumber != null)
            {
                context.Doctors.Add(doc);
                context.SaveChanges();
                return RedirectToAction("DoctorLogin");
            }
            else
            {
                return View("DoctorSignUp");
            }
        }
        public IActionResult modifyDoctorData(int id)
        {
            Doctor doc = context.Doctors.Find(id);
            if (doc == null)
            {
                return NotFound("Doctor not found.");
            }
            return View(doc);
        }
        public IActionResult saveModifiedData(Doctor doc, int id)
        {
            Doctor olddoctor = context.Doctors.Find(id);
            if (doc.Password != null & doc.Email != null & doc.Age != null
                & doc.PhoneNumber != null & doc.Address != null)
            {
                olddoctor.Name = doc.Name;
                olddoctor.Password = doc.Password;
                olddoctor.Email = doc.Email;
                olddoctor.Address = doc.Address;
                olddoctor.Age = doc.Age;
                olddoctor.PhoneNumber = doc.PhoneNumber;
                context.SaveChanges();
                return View("DoctorHome", doc);
            }
            else
            {
                return RedirectToAction("modifyUserData", doc.DoctorId);
            }
        }
        public IActionResult DoctorLogout()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult forgetPassword()
        {
            return View();
        }
        public ActionResult forgetpasswordconfirm(Doctor doc)
        {
            Doctor doctor = context.Doctors.FirstOrDefault(doctor => doctor.Email == doc.Email);
            if (doctor == null)
            {
                return View("notfound");
            }
            else
            {
                return View("modifypassword", doctor);
            }

        }


        public IActionResult saveModifiedPassword(Doctor doc)
        {
            Doctor olddoctor = context.Doctors.FirstOrDefault(doctor => doctor.DoctorId == doc.DoctorId);
            olddoctor.Password = doc.Password;
            context.SaveChanges();
            return RedirectToAction("DoctorLogin");
        }
    }
}

