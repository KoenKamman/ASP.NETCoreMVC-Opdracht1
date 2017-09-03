using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht1.Services
{
    public class BirthdayService
    {

	    public int GetAge(DateTime birthday)
	    {
			int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
		    int dob = int.Parse(birthday.ToString("yyyyMMdd"));

		    //Get the difference and drop the last 4 digits to get the age
		    int age = (now - dob) / 10000;

		    return age;
	    }

	    public int GetDaysUntilBirthday(DateTime birthday)
	    {
			DateTime today = DateTime.Today;
		    DateTime next = birthday.AddYears(today.Year - birthday.Year);

		    if (next < today)
		    {
			    next = next.AddYears(1);
		    }

		    int numDays = (next - today).Days;

		    return numDays;
	    }

    }
}
