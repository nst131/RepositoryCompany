using BL.Attributes;
using BL.BaseCrud;
using BL.Interfaces;
using BL.Models.AddressBL.Crud;
using BL.Models.AddressBL.Dto;
using BL.Models.AddressBL.Validation;
using BL.Models.CompaniesBL.Crud;
using BL.Models.CompaniesBL.Dto;
using BL.Models.CompaniesBL.Fetchers;
using BL.Models.CompaniesBL.Validation;
using BL.Models.DepartmentBL.Crud;
using BL.Models.DepartmentBL.Dto;
using BL.Models.DepartmentBL.Fetchers;
using BL.Models.EmployeeBL.Crud;
using BL.Models.EmployeeBL.Dto;
using BL.Models.EmployeeBL.Fetchers;
using BL.Models.EmployeeBL.Validation;
using BL.Models.PositionBL.Crud;
using BL.Models.PositionBL.Dto;
using BL.Models.PositionBL.Fetchers;
using DL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public static class ServiceRegistrationBL
    {
        public static void AddRegistrationBL(this IServiceCollection services)
        {
            //Attributes
            services.AddScoped<IUniqueCompanyName, UniqueCompanyName>();

            //Employee
            services.AddScoped<IEmployeeCrudBL, EmployeeCrudBL>();
            services.AddScoped<IEmployeeFetchersBL, EmployeeFetchersBL>();
            services.AddScoped<IGetter<ResponseGetEmployeeDtoBL>, Getter<Employee, ResponseGetEmployeeDtoBL>>();
            services.AddScoped<ICreater<AcceptCreateEmployeeDtoBL>, Creater<Employee, AcceptCreateEmployeeDtoBL>>();
            services.AddScoped<IValidator<AcceptCreateEmployeeDtoBL>, EmployeeCreateValidatorBL>();
            services.AddScoped<IUpdater<AcceptUpdateEmployeeDtoBL>, Updater<Employee, AcceptUpdateEmployeeDtoBL>>();
            services.AddScoped<IValidator<AcceptUpdateEmployeeDtoBL>, EmployeeUpdateValidatorBL>();
            services.AddScoped<IRemover<AcceptDeleteEmployeeDtoBL>, Remover<Employee, AcceptDeleteEmployeeDtoBL>>();

            //Address
            services.AddScoped<IAddressCrudBL, AddressCrudBL>();
            services.AddScoped<ICreater<AcceptCreateAddressDtoBL>, Creater<Address, AcceptCreateAddressDtoBL>>();
            services.AddScoped<IValidator<AcceptCreateAddressDtoBL>, AddressCreateValidatorBL>();
            services.AddScoped<IUpdater<AcceptUpdateAddressDtoBL>, Updater<Address, AcceptUpdateAddressDtoBL>>();
            services.AddScoped<IValidator<AcceptUpdateAddressDtoBL>, AddressUpdateValidatorBL>();

            //Companies
            services.AddScoped<ICompaniesCrud, CompaniesCrud>();
            services.AddScoped<ICompaniesFetchers, CompaniesFetchers>();
            services.AddScoped<IGetter<ResponseGetCompaniesDtoBL>, Getter<Companies, ResponseGetCompaniesDtoBL>>();
            services.AddScoped<ICreater<AcceptCreateCompaniesDtoBL>, Creater<Companies, AcceptCreateCompaniesDtoBL>>();
            services.AddScoped<IValidator<AcceptCreateCompaniesDtoBL>, CompaniesCreateValidatorBL>();
            services.AddScoped<IUpdater<AcceptUpdateCompaniesDtoBL>, Updater<Companies, AcceptUpdateCompaniesDtoBL>>();
            services.AddScoped<IValidator<AcceptUpdateCompaniesDtoBL>, CompaniesUpdateValidatorBL>();
            services.AddScoped<IRemover<AcceptDeleteCompaniesDtoBL>, Remover<Companies, AcceptDeleteCompaniesDtoBL>>();

            //Departments
            services.AddScoped<IDepartmentCrud, DepartmentCrud>();
            services.AddScoped<IDepartmentFetchers, DepartmentFetchers>();
            services.AddScoped<IGetter<ResponseGetDepartmentDtoBL>, Getter<Department, ResponseGetDepartmentDtoBL>>();

            //Position
            services.AddScoped<IPositionCrud, PositionCrud>();
            services.AddScoped<IPositionFetchers, PositionFetchers>();
            services.AddScoped<IGetter<ResponseGetPositionDtoBL>, Getter<Position, ResponseGetPositionDtoBL>>();
        }
    }
}
