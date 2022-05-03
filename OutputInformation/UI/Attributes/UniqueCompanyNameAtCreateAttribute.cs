using System;
using System.ComponentModel.DataAnnotations;
using BL.Attributes;
using DL.Models;

namespace UI.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UniqueCompanyNameAtCreateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IUniqueCompanyName)validationContext.GetService(typeof(IUniqueCompanyName))!;

            if (service is null)
                throw new NullReferenceException($"{nameof(service)} is null check your connection");

            return service.IsUniqueAtCreate<Companies>((string) value).Result ? new ValidationResult($"{nameof(Companies.Name)} has Existed yet") : null;
        }
    }
}
