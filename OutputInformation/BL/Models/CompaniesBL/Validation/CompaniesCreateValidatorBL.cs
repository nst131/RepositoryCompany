using BL.Interfaces;
using BL.Models.CompaniesBL.Dto;
using System;
using System.Threading.Tasks;

namespace BL.Models.CompaniesBL.Validation
{
    public class CompaniesCreateValidatorBL : IValidator<AcceptCreateCompaniesDtoBL>
    {
        public async Task Validate(AcceptCreateCompaniesDtoBL dto)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateCompaniesDtoBL)} is null");

            if (string.IsNullOrEmpty(dto.Name))
                throw new NullReferenceException($"{nameof(dto.Name)} cann't be empty");

            await Task.CompletedTask;
        }
    }
}
