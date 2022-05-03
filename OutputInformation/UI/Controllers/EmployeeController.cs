using AutoMapper;
using BL.Models.AddressBL.Crud;
using BL.Models.AddressBL.Dto;
using BL.Models.EmployeeBL.Crud;
using BL.Models.EmployeeBL.Dto;
using BL.Models.EmployeeBL.Fetchers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using UI.BaseModels;
using UI.Models.EmployeeUI.Dto;

namespace UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly IEmployeeCrudBL employeeCrud;
        private readonly IAddressCrudBL addressCrud;
        private readonly IEmployeeFetchersBL employeeFetchers;
        private readonly IMapper mapper;
        private readonly HttpClient httpClient;

        public EmployeeController(
            IEmployeeCrudBL employeeCrud,
            IAddressCrudBL addressCrud,
            IEmployeeFetchersBL employeeFetchers,
            IMapper mapper, HttpClient httpClient,
            IWebHostEnvironment environment)
        {
            this.employeeCrud = employeeCrud;
            this.addressCrud = addressCrud;
            this.employeeFetchers = employeeFetchers;
            this.mapper = mapper;
            this.httpClient = httpClient;
            this.environment = environment;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ICollection<ResponseGetEmployeeDtoUI>>> GetAll(CancellationToken token)
        {
            var employeeBL = await this.employeeFetchers.GetAll(token);

            if (employeeBL is null)
                throw new NullReferenceException($"{nameof(ICollection<ResponseGetEmployeeDtoBL>)} is not exist");

            var emploeeUI = employeeBL.Select(x => this.mapper.Map<ResponseGetEmployeeDtoUI>(x)).ToList();
            return new JsonResult(emploeeUI);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<FileResult> GetFileJsonAllEmployes(CancellationToken token)
        {
            var pathJson = Path.Combine(this.environment.ContentRootPath, nameof(File) + FileExtensions.json);

            if (System.IO.File.Exists(pathJson))
                System.IO.File.Delete(pathJson);

            var employeesBL = await this.employeeFetchers.GetAll(token);
            var emploeesUI = employeesBL.Select(x => this.mapper.Map<ResponseGetEmployeeDtoUI>(x)).ToList();

            await using (var file = new FileStream(pathJson, FileMode.OpenOrCreate))
            {
                await using (var writer = new StreamWriter(file, Encoding.UTF8))
                {
                    await writer.WriteAsync(JsonSerializer.Serialize(emploeesUI));
                }
            }
            var binary = await System.IO.File.ReadAllBytesAsync(pathJson, token);

            return File(binary, "multipart/form-data", $"JsonFile{FileExtensions.json}");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<FileResult> GetWordFileEmployesByCompanyAndDepartment(
            AcceptGetEmpoyesByCompAndDepartDtoUI dto,
            CancellationToken token)
        {
            var emloyesssBL = await this.employeeFetchers.GetEmployeeByCompanyAndDepartment(dto.CompanyId, dto.DepartmentId, token);

            if (emloyesssBL is null)
                throw new NullReferenceException($"{nameof(ICollection<ResponseGetEmployeeDtoBL>)} is not exist");

            var employeeUI = emloyesssBL.Select(x => this.mapper.Map<ResponseGetEmployeeDtoUI>(x)).ToList();

            var employeeUIJson = JsonSerializer.Serialize(employeeUI);

            var request = new StringContent(employeeUIJson, Encoding.UTF8, ContentTypeApplication.ApplicationJson);
            var response = await this.httpClient.PostAsync("https://localhost:5001/File/GetBytesListOfEmployee", request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(token);
            var binary = JsonSerializer.Deserialize<byte[]>(content);

            return File(binary, "multipart/form-data", $"WordFile{FileExtensions.docx}");
        }

        [HttpGet]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<ResponseGetEmployeeDtoUI>> Get([FromRoute] AcceptGetEmployeeDtoUI dto, CancellationToken token)
        {
            var employeeBL = await this.employeeCrud.Get(dto.Id, token);

            if (employeeBL is null)
                throw new NullReferenceException($"{nameof(AcceptGetEmployeeDtoUI)} is not exist");

            var employeeUI = this.mapper.Map<ResponseGetEmployeeDtoUI>(employeeBL);
            return new JsonResult(employeeUI);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<string>> Create([FromBody] AcceptCreateEmployeeDtoUI dto, CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptCreateEmployeeDtoBL)} is null");

            var employeeId = await this.employeeCrud.Create(this.mapper.Map<AcceptCreateEmployeeDtoBL>(dto) , token);
            var addressBL = this.mapper.Map<AcceptCreateAddressDtoBL>(dto);
            addressBL.EmployeeId = employeeId;
            await this.addressCrud.Greate(addressBL, token);
            return new JsonResult("Success");
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<string>> Update([FromBody] AcceptUpdateEmployeeDtoUI dto, CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptUpdateEmployeeDtoBL)} is null");

            await this.addressCrud.Update(this.mapper.Map<AcceptUpdateAddressDtoBL>(dto), token);
            var updateEmployeeBL = this.mapper.Map<AcceptUpdateEmployeeDtoBL>(dto);

            await this.employeeCrud.Update(updateEmployeeBL, token);
            return new JsonResult("Success");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<ActionResult<string>> Delete([FromRoute] AcceptDeleteEmployeeDtoUI dto,
            CancellationToken token)
        {
            if (dto is null)
                throw new NullReferenceException($"{nameof(AcceptDeleteEmployeeDtoUI)} is null");

            await this.employeeCrud.Delete(new AcceptDeleteEmployeeDtoBL() {Id = dto.Id}, token);
            return new JsonResult("Success");
        }
    }
}
