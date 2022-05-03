using System.Threading.Tasks;
using DL.Interfaces;

namespace BL.Attributes
{
    public interface IUniqueCompanyName
    {
        Task<bool> IsUniqueAtCreate<T>(string name) where T : class, IName;
        Task<bool> IsUniqueAtUpdate<T>(string name, int exceptId) where T : class, IEntity, IName;
    }
}