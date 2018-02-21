using System;
using System.ComponentModel.DataAnnotations;

namespace UsersAchievements.Helpers
{
    internal sealed class BirthdateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthdate = DateTime.Parse(value.ToString());

            if (birthdate > DateTime.Today)
            {
                return new ValidationResult("Birthdate should be equal or lesser than current date");
            }

            if (birthdate < DateTime.Today.AddYears(-150))
            {
                return new ValidationResult($"Birthdate should be greater than {DateTime.Today.AddYears(-150)}");
            }

            return ValidationResult.Success;
        }
    }
}