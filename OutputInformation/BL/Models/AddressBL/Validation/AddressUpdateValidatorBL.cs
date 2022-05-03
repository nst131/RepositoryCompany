using BL.Interfaces;
using BL.Models.AddressBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Models.AddressBL.Validation
{
    public class AddressUpdateValidatorBL : IValidator<AcceptUpdateAddressDtoBL>
    {
        private readonly IDataContext context;

        public AddressUpdateValidatorBL(IDataContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateAddressDtoBL dto)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateAddressDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !this.context.Set<Address>().AsNoTracking().ToList().Exists(x => x.Id == dto.Id)))
                throw new NullReferenceException($"{nameof(Address)} by Id not Found");

            if (string.IsNullOrEmpty(dto.Street))
                throw new NullReferenceException($"{nameof(dto.Street)} cann't be empty");

            if (string.IsNullOrEmpty(dto.Street))
                throw new NullReferenceException($"{nameof(dto.House)} cann't be empty");

            if (string.IsNullOrEmpty(dto.Street))
                throw new NullReferenceException($"{nameof(dto.Flat)} cann't be empty");

            await Task.CompletedTask;
        }
    }
}
