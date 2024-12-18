using Microsoft.AspNetCore.Mvc;
using DoctorsAppointment.Models;
using System.Runtime.Intrinsics.Arm;

namespace DoctorsAppointment.Controllers
{
    public class UserController : Controller
    {
        Context context = new Context();
        public IActionResult userLogin(User us)
        {
            User user = context.Users.FirstOrDefault
            (user => user.Email == us.Email && user.Password == us.Password);
            if (user != null)
            {
                return View("Userhome", user);
            }
            else
            {
                return View();
            }
        }
        public IActionResult userSignUp()
        {
            return View();
        }
        public IActionResult userSignupSave(User user)
        {

            if (user.Email != null & user.Name != null & user.Password != null
               & user.Age != null & user.Address != null & user.PhoneNumber != null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("userLogin");
            }
            else
            {
                return View("userSignUp");
            }
        }

        public IActionResult modifyUserData(int id)
        {
            User user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return View(user);
        }
        public IActionResult saveModifiedData(User user, int id)
        {
            User olduser = context.Users.Find(id);
            if (user.Password != null & user.Email != null & user.Age != null
                & user.PhoneNumber != null & user.Address != null)
            {
                olduser.Name = user.Name;
                olduser.Password = user.Password;
                olduser.Email = user.Email;
                olduser.Address = user.Address;
                olduser.Age = user.Age;
                olduser.PhoneNumber = user.PhoneNumber;
                context.SaveChanges();
                return View("UserHome", user);

            }
            else
            {
                return RedirectToAction("modifyUserData");
            }


        }
        public IActionResult userLogout()
        {

            return View("userLogin");
        }

        public IActionResult forgetPassword()
        {
            return View();
        }
        public ActionResult forgetpasswordconfirm(User use)
        {
            User user = context.Users.FirstOrDefault(us => us.Email == use.Email);
            if (user == null)
            {
                return View("notfound");
            }
            else
            {
                return View("modifypassword", user);
            }

        }


        public IActionResult saveModifiedPassword(User user)
        {

            User olduser = context.Users.FirstOrDefault(ad => ad.UserId == user.UserId);

            olduser.Password = user.Password;

            context.SaveChanges();

            return RedirectToAction("userLogin");
        }

    }
}
