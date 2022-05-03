using System.Threading;
using System.Threading.Tasks;
using BL.Models.EmployeeBL.Dto;

namespace BL.Models.EmployeeBL.Crud
{
    public interface IEmployeeCrudBL
    {
        Task<ResponseGetEmployeeDtoBL> Get(int id, CancellationToken token = default);
        Task<int> Create(AcceptCreateEmployeeDtoBL dto, CancellationToken token = default);
        Task Update(AcceptUpdateEmployeeDtoBL dto, CancellationToken token = default);
        Task Delete(AcceptDeleteEmployeeDtoBL dto, CancellationToken token = default);
    }
}