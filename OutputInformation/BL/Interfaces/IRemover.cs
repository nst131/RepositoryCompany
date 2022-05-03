using System.Threading;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IRemover<in AcceptDto> where AcceptDto : class, IRemoverDto
    {
        Task<int> Remove(AcceptDto dto, CancellationToken token = default);
    }
}