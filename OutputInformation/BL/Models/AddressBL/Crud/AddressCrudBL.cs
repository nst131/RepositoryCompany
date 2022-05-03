using BL.Interfaces;
using BL.Models.AddressBL.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Models.AddressBL.Crud
{
    public class AddressCrudBL : IAddressCrudBL
    {
        private readonly ICreater<AcceptCreateAddressDtoBL> creater;
        private readonly IUpdater<AcceptUpdateAddressDtoBL> updater;

        public AddressCrudBL(
            ICreater<AcceptCreateAddressDtoBL> creater, 
            IUpdater<AcceptUpdateAddressDtoBL> updater)
        {
            this.creater = creater;
            this.updater = updater;
        }

        public async Task Greate(AcceptCreateAddressDtoBL dto, CancellationToken token)
            => await this.creater.Create(dto, token);

        public async Task Update(AcceptUpdateAddressDtoBL dto, CancellationToken token)
            => await this.updater.Update(dto, token);
    }
}
