using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht1.Models
{
    public class BirthdayResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression(@" ^[a - zA - Z] + $",
            ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a day")]
        [Range(1, 31, ErrorMessage = "Please enter a valid day")]
        public int Day { get; set; }

        [Required(ErrorMessage = "Please enter a month")]
        [Range(1, 12, ErrorMessage = "Please enter a valid month")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1900, 3000, ErrorMessage = "Please enter a valid year")]
        public int Year { get; set; }
    }
}
