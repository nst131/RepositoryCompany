using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IValidator<Entity>
        where Entity : class
    {
        Task Validate(Entity dto);
    }
}
