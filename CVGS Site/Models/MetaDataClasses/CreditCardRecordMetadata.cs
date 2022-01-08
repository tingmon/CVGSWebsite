using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CVGSValidation;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CVGS_Site.Models
{
    [ModelMetadataType(typeof(CreditCardRecordMetadata))]
    public partial class CreditCardRecord : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CVGSContext _context = validationContext.GetService<CVGSContext>();
            CardCode = StringManipulation.EmptyAndTrim(CardCode);
            CardNumber = StringManipulation.EmptyAndTrim(CardNumber);
            ExpiryDateMonth = StringManipulation.EmptyAndTrim(ExpiryDateMonth);
            ExpiryDateYear = StringManipulation.EmptyAndTrim(ExpiryDateYear);
            Cvv = StringManipulation.EmptyAndTrim(Cvv);

            //var data = _context.CreditCardRecord.ToList();
            //int month = int.Parse(ExpiryDateMonth);
            //int year = int.Parse(ExpiryDateYear);

            //if(month > 12 || month <= 0)
            //{
            //    yield return new ValidationResult("Month should be between 1 to 12", 
            //        new[] { nameof(ExpiryDateMonth) });
            //}
            //if(year < 21)
            //{
            //    yield return new ValidationResult("Year should be later than 2020",
            //        new[] { nameof(ExpiryDateYear) });
            //}

            yield return ValidationResult.Success;
        }
    }
    public class CreditCardRecordMetadata
    {
        public int CardId { get; set; }
        public int PersonId { get; set; }
        public string CardCode { get; set; }
        [CVGSCardNumber]
        public string CardNumber { get; set; }
        [CVGSExpiryDateMonth]
        public string ExpiryDateMonth { get; set; }
        [CVGSExpiryDateYear]
        public string ExpiryDateYear { get; set; }
        [CVGSCvv]
        public string Cvv { get; set; }

        public virtual CreditCard CardCodeNavigation { get; set; }
        public virtual Person Person { get; set; }
    }
}

