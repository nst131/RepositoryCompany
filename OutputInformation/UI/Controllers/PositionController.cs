using AutoMapper;
using BL.Models.PositionBL.Crud;
using BL.Models.PositionBL.Dto;
using BL.Models.PositionBL.Fetchers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UI.Models.PositionUI.Dto;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionCrud crud;
        private readonly IPositionFetchers fetch;
        private readonly IMapper mapper;

        public PositionController(IMapper mapper, IPositionFetchers fetch, IPositionCrud crud)
        {
            this.mapper = mapper;
            this.fetch = fetch;
            this.crud = crud;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetPositionDtoUI>>> GetAll(CancellationToken token)
        {
            var positionBL = await this.fetch.GetAll(token);

            if (positionBL is null)
                throw new NullReferenceException($"{nameof(ICollection<ResponseGetPositionDtoBL>)} is not exist");

            var positionUI = positionBL.Select(x => this.mapper.Map<ResponseGetPositionDtoUI>(x)).ToList();
            return new JsonResult(positionUI);
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetPositionDtoUI>> Get([FromRoute] AcceptGetPositionDtoUI dto, CancellationToken token)
        {
            var positionBL = await this.crud.Get(dto.Id, token);

            if (positionBL is null)
                throw new NullReferenceException($"{nameof(AcceptGetPositionDtoUI)} is not exist");

            var positionUI = this.mapper.Map<ResponseGetPositionDtoUI>(positionBL);
            return new JsonResult(positionUI);
        }
    }
}
