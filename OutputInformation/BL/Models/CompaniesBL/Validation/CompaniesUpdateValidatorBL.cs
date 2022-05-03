using System;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using BL.Models.CompaniesBL.Dto;
using BL.Models.EmployeeBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Models.CompaniesBL.Validation
{
    public class CompaniesUpdateValidatorBL : IValidator<AcceptUpdateCompaniesDtoBL>
    {
        private readonly IDataContext context;

        public CompaniesUpdateValidatorBL(IDataContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateCompaniesDtoBL dto)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptUpdateCompaniesDtoBL)} is null");

            if (string.IsNullOrEmpty(dto.Name))
                throw new NullReferenceException($"{nameof(dto.Name)} cann't be empty");

            if (await Task.Factory.StartNew(() => !this.context.Set<Companies>().AsNoTracking().ToList().Exists(x => x.Id == dto.Id)))
                throw new NullReferenceException($"{nameof(Companies)} by Id not Found");
        }
    }
}
