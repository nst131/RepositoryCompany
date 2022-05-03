using BL.Attributes;
using DL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace UI.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UniqueCompanyNameAtUpdateAttribute : ValidationAttribute
    {
        private readonly string idAbbreviation;
        private readonly string nameAbbreviation;

        public UniqueCompanyNameAtUpdateAttribute(string idAbbreviation, string nameAbbreviation)
        {
            this.idAbbreviation = idAbbreviation;
            this.nameAbbreviation = nameAbbreviation;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IUniqueCompanyName)validationContext.GetService(typeof(IUniqueCompanyName));

            if (service is null)
                throw new NullReferenceException($"{nameof(service)} is null check your connection");

            var id = value.GetType().GetProperty(this.idAbbreviation)?.GetValue(value);
            var name = value.GetType().GetProperty(this.nameAbbreviation)?.GetValue(value);

            if (id is null || name is null)
                return new ValidationResult("Don't correct use attribute");

            return service.IsUniqueAtUpdate<Companies>((string)name, (int)id).Result ? null : new ValidationResult($"{nameof(Companies.Name)} has existed yet");
        }
    }
}
