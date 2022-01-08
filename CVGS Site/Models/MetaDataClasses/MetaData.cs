using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CVGSValidation;

namespace CVGS_Site.Models
{
    [ModelMetadataType(typeof(PersonMetaData))]
    public partial class Person :IValidatableObject
    {
        CVGSContext _context = new CVGSContext();
        string errorMessage = "";
        List<string> errorFields = new List<string>();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            #region Trim
            Surname = StringManipulation.EmptyAndTrim(Surname);
            GivenName = StringManipulation.EmptyAndTrim(GivenName);
            Street = StringManipulation.EmptyAndTrim(Street);
            City = StringManipulation.EmptyAndTrim(City);
            ProvinceCode = StringManipulation.EmptyAndTrim(ProvinceCode);
            CountryCode = StringManipulation.EmptyAndTrim(CountryCode);
            PostalCode = StringManipulation.EmptyAndTrim(PostalCode);
            LandLine = StringManipulation.EmptyAndTrim(LandLine);
            Extension = StringManipulation.EmptyAndTrim(Extension);
            Mobile = StringManipulation.EmptyAndTrim(Mobile);
            Fax = StringManipulation.EmptyAndTrim(Fax);
            Email = StringManipulation.EmptyAndTrim(Email);
            UserName = StringManipulation.EmptyAndTrim(UserName);
            #endregion

            yield return ValidationResult.Success;
        }
    }
    [ModelMetadataType(typeof(ReportMetaData))]
    public partial class Report : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ReportName = StringManipulation.EmptyAndTrim(ReportName);
            ReportBody = StringManipulation.EmptyAndTrim(ReportBody);
            yield return ValidationResult.Success;
        }

    }
    public class PersonMetaData
    {
        public int Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        [Required]
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        [CVGSPhone]
        public string LandLine { get; set; }
        public string Extension { get; set; }
        [CVGSPhone]
        public string Mobile { get; set; }
        [CVGSPhone]
        public string Fax { get; set; }
        [CVGSEmail]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual Employee Employee { get; set; }
    }
    public class ReportMetaData
    {
        [Required]
        public int ReportId { get; set; }
        [Required]
        public string ReportName { get; set; }
        [Required]
        public string ReportBody { get; set; }
        [Required]
        public int PersonId { get; set; }
    }
}
