using System;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using BL.Models.EmployeeBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Models.EmployeeBL.Validation
{
    public class EmployeeCreateValidatorBL : IValidator<AcceptCreateEmployeeDtoBL>
    {
        private readonly IDataContext context;

        public EmployeeCreateValidatorBL(IDataContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateEmployeeDtoBL dto)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateEmployeeDtoBL)} is null");

            if(string.IsNullOrEmpty(dto.Name))
                throw new NullReferenceException($"{nameof(dto.Name)} cann't be empty");

            if (string.IsNullOrEmpty(dto.SerName))
                throw new NullReferenceException($"{nameof(dto.SerName)} cann't be empty");

            if (string.IsNullOrEmpty(dto.Patronymic))
                throw new NullReferenceException($"{nameof(dto.Patronymic)} cann't be empty");

            if (string.IsNullOrEmpty(dto.Telephone))
                throw new NullReferenceException($"{nameof(dto.Telephone)} cann't be empty");

            if (await Task.Factory.StartNew(() => !this.context.Set<Department>().AsNoTracking().ToList().Exists(x => x.Id == dto.DepartmentId)))
                throw new NullReferenceException($"{nameof(Department)} by Id not Found");

            if (await Task.Factory.StartNew(() => !this.context.Set<Position>().AsNoTracking().ToList().Exists(x => x.Id == dto.PositionId)))
                throw new NullReferenceException($"{nameof(Position)} by Id not Found");

            if (await Task.Factory.StartNew(() => !this.context.Set<Companies>().AsNoTracking().ToList().Exists(x => x.Id == dto.CompaniesId)))
                throw new NullReferenceException($"{nameof(Companies)} by Id not Found");
        }
    }
}
