using System.Threading;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUpdater<in UpdateDto>
        where UpdateDto: class
    {
        Task Update(UpdateDto updateDto, CancellationToken token = default);
    }
}