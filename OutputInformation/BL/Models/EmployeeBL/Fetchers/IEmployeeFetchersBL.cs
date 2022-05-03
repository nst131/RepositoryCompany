using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BL.Models.EmployeeBL.Dto;

namespace BL.Models.EmployeeBL.Fetchers
{
    public interface IEmployeeFetchersBL
    {
        Task<ICollection<ResponseGetEmployeeDtoBL>> GetAll(CancellationToken token);
        Task<ICollection<ResponseGetEmployeeDtoBL>> GetEmployeeByCompanyAndDepartment(int companyId, int departmentId, CancellationToken token);
    }
}