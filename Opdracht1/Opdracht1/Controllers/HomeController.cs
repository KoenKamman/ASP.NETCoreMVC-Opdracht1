using System;
using Microsoft.AspNetCore.Mvc;
using Opdracht1.Models;

namespace Opdracht1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Date = DateTime.Today.ToString("d MMMM yyyy");
            return View();
        }

        [HttpGet]
        public ViewResult BirthdayForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult BirthdayForm(BirthdayResponse birthdayResponse)
        {
            //Validation
            if (ModelState.IsValid)
            {
                DateTime today = DateTime.Today;
                DateTime birthday = new DateTime(birthdayResponse.Year, birthdayResponse.Month, birthdayResponse.Day);
                DateTime next = birthday.AddYears(today.Year - birthday.Year);

                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(birthday.ToString("yyyyMMdd"));

                //Calculate age by dropping the last 4 digits
                int age = (now - dob) / 10000;
                ViewBag.AgePlusOne = age + 1;

                if (next < today)
                {
                    next = next.AddYears(1);
                }

                if (next == today)
                {
                    return View("HappyBirthday", birthdayResponse);
                }
                else
                {

                    int numDays = (next - today).Days;

                    if (numDays == 1)
                    {
                        ViewBag.DaysUntilBirthday = numDays + " dag";
                    }
                    else
                    {
                        ViewBag.DaysUntilBirthday = numDays + " dagen";
                    }

                    return View("Countdown", birthdayResponse);
                }
            }
            else
            {
                //Validation error
                return View();
            }
        }

    }
}
