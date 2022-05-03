using System.Threading;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICreater<in CreateDto>
        where CreateDto: class
    {
        Task<int> Create(CreateDto createDto, CancellationToken token = default);
    }
}