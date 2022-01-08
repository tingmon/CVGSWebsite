using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CVGSValidation
{
    public class CVGSEmailAttribute : ValidationAttribute
    {
        public CVGSEmailAttribute()
        {
            ErrorMessage = "Not a valid email address";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex pattern = new Regex(@"^[\w]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase);
            string tmpValue = "";
            if (value != null)
            {
                tmpValue = value.ToString();
            }
            if (String.IsNullOrEmpty(tmpValue) | pattern.IsMatch(tmpValue))
                return ValidationResult.Success;
            return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
        }
    }
    public class CVGSPhoneAttribute : ValidationAttribute
    {
        public CVGSPhoneAttribute()
        {
            ErrorMessage = "Not a valid phone number";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex pattern = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", RegexOptions.IgnoreCase);
            string tmpValue = "";
            if (value != null)
            {
                tmpValue = value.ToString();
            }
            if (String.IsNullOrEmpty(tmpValue) | pattern.IsMatch(tmpValue))
                return ValidationResult.Success;
            return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
        }
    }
    public class CVGSCardNumberAttribute : ValidationAttribute
    {
        public CVGSCardNumberAttribute()
        {
            ErrorMessage = "Enter Only Sixteen Numbers for Card Number";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex pattern = new Regex(@"^[0-9]{16}$");
            string tmpValue = "";
            if (value != null)
            {
                tmpValue = value.ToString();
            }
            if (String.IsNullOrEmpty(tmpValue) | pattern.IsMatch(tmpValue))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
        }
    }
    public class CVGSExpiryDateMonthAttribute : ValidationAttribute
    {
        public CVGSExpiryDateMonthAttribute()
        {
            ErrorMessage = "Enter Only Two Numbers for Expiry Date";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex pattern = new Regex(@"^[0-9]{2}$");
            string tmpValue = "";
            if (value != null)
            {
                tmpValue = value.ToString();
            }
            if (String.IsNullOrEmpty(tmpValue) | pattern.IsMatch(tmpValue))
            {
                if (int.Parse(tmpValue) > 12 || int.Parse(tmpValue) <= 0 || tmpValue.Length != 2)
                {
                    ErrorMessage = "Month should be between 01 to 12";
                    return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
                }
                return ValidationResult.Success;
            }
            return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
        }
    }
    public class CVGSExpiryDateYearAttribute : ValidationAttribute
    {
        public CVGSExpiryDateYearAttribute()
        {
            ErrorMessage = "Enter Only Two Numbers for Expiry Date";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex pattern = new Regex(@"^[0-9]{2}$");
            string tmpValue = "";
            if (value != null)
            {
                tmpValue = value.ToString();
            }
            if (String.IsNullOrEmpty(tmpValue) | pattern.IsMatch(tmpValue))
            {
                if (int.Parse(tmpValue) < 21)
                {
                    ErrorMessage = "Year should be later than 2020";
                    return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
                }
                return ValidationResult.Success;
            }
            return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
        }
    }
    public class CVGSCvvAttribute : ValidationAttribute
    {
        public CVGSCvvAttribute()
        {
            ErrorMessage = "Enter Only Three Numbers for CVV";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex pattern = new Regex(@"^[0-9]{3}$");
            string tmpValue = "";
            if (value != null)
            {
                tmpValue = value.ToString();
            }
            if (String.IsNullOrEmpty(tmpValue) | pattern.IsMatch(tmpValue))
                return ValidationResult.Success;
            return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
        }
    }
    public static class StringManipulation
    {
        public static string EmptyAndTrim(string input)
        {
            if (input == null)
            {
                return "";
            }
            return input.Trim();
        }
    }
}
