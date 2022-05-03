using AutoMapper;
using BL.Models.CompaniesBL.Crud;
using BL.Models.CompaniesBL.Dto;
using BL.Models.CompaniesBL.Fetchers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UI.Models.CompaniesUI.Dto;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompaniesCrud crud;
        private readonly ICompaniesFetchers fetch;
        private readonly IMapper mapper;

        public CompanyController(ICompaniesCrud crud, ICompaniesFetchers fetch, IMapper mapper)
        {
            this.crud = crud;
            this.fetch = fetch;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetCompaniesDtoUI>>> GetAll(CancellationToken token)
        {
            var companiesBL = await this.fetch.GetAll(token);

            if (companiesBL is null)
                throw new NullReferenceException($"{nameof(ICollection<ResponseGetCompaniesDtoBL>)} is not exist");

            var companiesUI = companiesBL.Select(x => this.mapper.Map<ResponseGetCompaniesDtoUI>(x)).ToList();
            return new JsonResult(companiesUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetCompaniesDtoUI>> Get([FromRoute] AcceptGetCompaniesDtoUI dto, CancellationToken token)
        {
            var companyBL = await this.crud.Get(dto.Id, token);

            if (companyBL is null)
                throw new NullReferenceException($"{nameof(AcceptGetCompaniesDtoUI)} is not exist");

            var companyUI = this.mapper.Map<ResponseGetCompaniesDtoUI>(companyBL);
            return new JsonResult(companyUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<string>> Create([FromBody] AcceptCreateCompaniesDtoUI dto, CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateCompaniesDtoUI)} is null");

            await this.crud.Create(this.mapper.Map<AcceptCreateCompaniesDtoBL>(dto), token);
            return new JsonResult("Success");
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<string>> Update([FromBody] AcceptUpdateCompaniesDtoUI dto, CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptUpdateCompaniesDtoUI)} is null");

            await this.crud.Update(this.mapper.Map<AcceptUpdateCompaniesDtoBL>(dto), token);
            return new JsonResult("Success");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteCompaniesDtoUI dto,
            CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptDeleteCompaniesDtoUI)} is null");

            await this.crud.Delete(new AcceptDeleteCompaniesDtoBL() { Id = dto.Id }, token);
            return new JsonResult("Success");
        }
    }
}
