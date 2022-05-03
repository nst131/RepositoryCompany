using System.Threading;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IGetter<DtoGetresponse>
        where DtoGetresponse : class
    {
        Task<DtoGetresponse> Get(int id, CancellationToken token = default);
    }
}