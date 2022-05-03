using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BL.Models.DepartmentBL.Dto;

namespace BL.Models.DepartmentBL.Fetchers
{
    public interface IDepartmentFetchers
    {
        Task<ICollection<ResponseGetDepartmentDtoBL>> GetAll(CancellationToken token = default);
    }
}