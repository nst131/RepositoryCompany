using BL.Interfaces;
using BL.Models.AddressBL.Dto;
using System;
using System.Threading.Tasks;

namespace BL.Models.AddressBL.Validation
{
    internal class AddressCreateValidatorBL : IValidator<AcceptCreateAddressDtoBL>
    {
        public async Task Validate(AcceptCreateAddressDtoBL dto)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateAddressDtoBL)} is null");

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
