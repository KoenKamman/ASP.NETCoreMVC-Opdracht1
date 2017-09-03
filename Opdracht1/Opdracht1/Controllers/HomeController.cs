using System;
using Microsoft.AspNetCore.Mvc;
using Opdracht1.Models;
using Opdracht1.Services;

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
			var birthdayService = new BirthdayService();

            if (ModelState.IsValid)
            {
                DateTime birthday = new DateTime(birthdayResponse.Year, birthdayResponse.Month, birthdayResponse.Day);
	            int daysUntilBirthday = birthdayService.GetDaysUntilBirthday(birthday);

				ViewBag.AgePlusOne = birthdayService.GetAge(birthday) + 1;
	            ViewBag.DaysUntilBirthday = birthdayService.GetDaysUntilBirthday(birthday);

	            if (daysUntilBirthday == 0)
	            {
		            return View("HappyBirthday", birthdayResponse);
	            }

				return View("Countdown", birthdayResponse);
			}
            else
            {
                //Validation error
                return View();
            }
        }

    }
}
