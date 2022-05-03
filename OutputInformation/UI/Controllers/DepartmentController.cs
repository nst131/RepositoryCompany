using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models.DepartmentBL.Crud;
using BL.Models.DepartmentBL.Dto;
using BL.Models.DepartmentBL.Fetchers;
using Microsoft.AspNetCore.Mvc;
using UI.Models.DepartmentUI.Dto;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentCrud crud;
        private readonly IDepartmentFetchers fetch;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentCrud crud, IMapper mapper, IDepartmentFetchers fetch)
        {
            this.crud = crud;
            this.mapper = mapper;
            this.fetch = fetch;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetDepartmentDtoUI>>> GetAll(CancellationToken token)
        {
            var departmentBL = await this.fetch.GetAll(token);

            if (departmentBL is null)
                throw new NullReferenceException($"{nameof(ICollection<ResponseGetDepartmentDtoBL>)} is not exist");

            var departmentUI = departmentBL.Select(x => this.mapper.Map<ResponseGetDepartmentDtoUI>(x)).ToList();
            return new JsonResult(departmentUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetDepartmentDtoUI>> Get([FromRoute] AcceptGetDepartmentDtoUI dto, CancellationToken token)
        {
            var departmentBL = await this.crud.Get(dto.Id, token);

            if (departmentBL is null)
                throw new NullReferenceException($"{nameof(AcceptGetDepartmentDtoUI)} is not exist");

            var departmentUI = this.mapper.Map<ResponseGetDepartmentDtoUI>(departmentBL);
            return new JsonResult(departmentUI);
        }
    }
}
