using BL.Interfaces;
using BL.Models.DepartmentBL.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Models.DepartmentBL.Crud
{
    public class DepartmentCrud : IDepartmentCrud
    {
        private readonly IGetter<ResponseGetDepartmentDtoBL> getter;

        public DepartmentCrud(IGetter<ResponseGetDepartmentDtoBL> getter)
        {
            this.getter = getter;
        }

        public async Task<ResponseGetDepartmentDtoBL> Get(int id, CancellationToken token = default)
            => await this.getter.Get(id, token);
    }
}
