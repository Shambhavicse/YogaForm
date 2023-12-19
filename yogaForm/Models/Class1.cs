using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yogaForm.Models
{
    public class Class1
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName{ get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string PhoneNo { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [CustomValidation(typeof(Class1), "ValidateAge")]
        public DateTime Dob { get; set; }
        [Required]
        [Display(Name = "Preferred Batch")]
        public string Batch { get; set; }
        [Display(Name = "Enroll for 500 Rs")]
        public bool EnrollFor500Rs { get; set; }
        public static ValidationResult ValidateAge(DateTime dob, ValidationContext context)
        {
            var minDate = DateTime.Now.AddYears(-65);
            var maxDate = DateTime.Now.AddYears(-18);

            if (dob < minDate || dob > maxDate)
            {
                return new ValidationResult("Only people within the age limit of 18-65 can enroll.");
            }

            return ValidationResult.Success;
        }
    }
}