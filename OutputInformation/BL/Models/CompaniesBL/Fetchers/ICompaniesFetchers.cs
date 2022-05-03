using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BL.Models.CompaniesBL.Dto;

namespace BL.Models.CompaniesBL.Fetchers
{
    public interface ICompaniesFetchers
    {
        Task<ICollection<ResponseGetCompaniesDtoBL>> GetAll(CancellationToken token = default);
    }
}