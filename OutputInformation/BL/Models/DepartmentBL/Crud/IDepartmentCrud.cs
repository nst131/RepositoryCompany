using System.Threading;
using System.Threading.Tasks;
using BL.Models.DepartmentBL.Dto;

namespace BL.Models.DepartmentBL.Crud
{
    public interface IDepartmentCrud
    {
        Task<ResponseGetDepartmentDtoBL> Get(int id, CancellationToken token);
    }
}