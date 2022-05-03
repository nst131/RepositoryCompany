using System.Threading;
using System.Threading.Tasks;
using BL.Models.CompaniesBL.Dto;

namespace BL.Models.CompaniesBL.Crud
{
    public interface ICompaniesCrud
    {
        Task<ResponseGetCompaniesDtoBL> Get(int id, CancellationToken token = default);
        Task Create(AcceptCreateCompaniesDtoBL dto, CancellationToken token = default);
        Task Update(AcceptUpdateCompaniesDtoBL dto, CancellationToken token = default);
        Task Delete(AcceptDeleteCompaniesDtoBL dto, CancellationToken token = default);
    }
}