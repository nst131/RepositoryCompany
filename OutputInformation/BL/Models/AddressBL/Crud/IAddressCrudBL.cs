using System.Threading;
using System.Threading.Tasks;
using BL.Models.AddressBL.Dto;

namespace BL.Models.AddressBL.Crud
{
    public interface IAddressCrudBL
    {
        Task Greate(AcceptCreateAddressDtoBL dto, CancellationToken token);
        Task Update(AcceptUpdateAddressDtoBL dto, CancellationToken token);
    }
}