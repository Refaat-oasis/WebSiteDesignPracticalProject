using DoctorsAppointment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointment.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();

        public IActionResult adminLogin(Admin adm)
        {
            Admin admin = context.Admins.FirstOrDefault
            (admin => admin.Email == adm.Email && admin.Password == adm.Password);
            if (admin != null)
            {
                return View("AdminHome", admin);
            }
            else
            {
                return View();
            }
        }
        public IActionResult adminLogout()
        {
            return RedirectToAction("Index","Home");
        }
        public IActionResult adminSignup()
        {
            return View();
        }
        public IActionResult signUpSave(Admin admin)
        {
            if (admin.Name != null && admin.Password != null && admin.Password != null)
            {
                context.Admins.Add(admin);
                context.SaveChanges();
                return RedirectToAction("adminLogin");
            }
            return View("adminSignup");
        }

        public IActionResult ShowMyProfile(int id)
        {
            Admin admin = context.Admins.Find(id);
            if (admin == null)
            {
                return NotFound("Admin not found.");
            }

            return View(admin);
        }
        public IActionResult saveModifiedData(Admin admin, int id)
        {
            if (admin.Name!=null & admin.Email != null & admin.Password != null & admin.Password != null)
            {

                Admin oldAdmin = context.Admins.FirstOrDefault(admin => admin.AdminId == id);
                oldAdmin.Name = admin.Name;
                oldAdmin.Email = admin.Email;
                oldAdmin.PhoneNumber = admin.PhoneNumber;
                oldAdmin.Password = admin.Password;

                context.SaveChanges();
                return View("AdminHome", admin);

            }
            else
            {
                return View("ShowMyProfile", admin.AdminId);
            }

        }
        public IActionResult forgetPassword() { 
            return View();
        }
        public ActionResult forgetpasswordconfirm(Admin adm)
        {
            Admin admin = context.Admins.FirstOrDefault(admin => admin.Email == adm.Email);
            if (admin == null)
            {
                return View("notfound");
            }
            else
            {
                return View("modifypassword", admin);
            }

        }


        public IActionResult saveModifiedPassword(Admin admin) {
            
            Admin oldadmin = context.Admins.FirstOrDefault(ad => ad.AdminId == admin.AdminId);
            
            oldadmin.Password = admin.Password;

            context.SaveChanges();

            return RedirectToAction("adminLogin");
         }

    }
}

