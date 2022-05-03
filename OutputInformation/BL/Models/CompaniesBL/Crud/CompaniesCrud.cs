using System.Threading;
using System.Threading.Tasks;
using BL.Interfaces;
using BL.Models.CompaniesBL.Dto;

namespace BL.Models.CompaniesBL.Crud
{
    public class CompaniesCrud : ICompaniesCrud
    {
        private readonly IGetter<ResponseGetCompaniesDtoBL> getter;
        private readonly ICreater<AcceptCreateCompaniesDtoBL> creater;
        private readonly IUpdater<AcceptUpdateCompaniesDtoBL> updater;
        private readonly IRemover<AcceptDeleteCompaniesDtoBL> remover;
        public CompaniesCrud(
            IGetter<ResponseGetCompaniesDtoBL> getter,
            ICreater<AcceptCreateCompaniesDtoBL> creater,
            IUpdater<AcceptUpdateCompaniesDtoBL> updater,
            IRemover<AcceptDeleteCompaniesDtoBL> remover)
        {
            this.getter = getter;
            this.creater = creater;
            this.updater = updater;
            this.remover = remover;
        }

        public async Task<ResponseGetCompaniesDtoBL> Get(int id, CancellationToken token = default)
            => await this.getter.Get(id, token);

        public async Task Create(AcceptCreateCompaniesDtoBL dto, CancellationToken token = default)
            => await this.creater.Create(dto, token);

        public async Task Update(AcceptUpdateCompaniesDtoBL dto, CancellationToken token = default)
            => await this.updater.Update(dto, token);

        public async Task Delete(AcceptDeleteCompaniesDtoBL dto, CancellationToken token = default)
            => await this.remover.Remove(dto, token);
    }
}
