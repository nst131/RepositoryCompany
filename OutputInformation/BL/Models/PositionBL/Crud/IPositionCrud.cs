using System.Threading;
using System.Threading.Tasks;
using BL.Models.PositionBL.Dto;

namespace BL.Models.PositionBL.Crud
{
    public interface IPositionCrud
    {
        Task<ResponseGetPositionDtoBL> Get(int id, CancellationToken token = default);
    }
}