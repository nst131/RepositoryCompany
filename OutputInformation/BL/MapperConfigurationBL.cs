using AutoMapper;
using BL.Models.AddressBL.Dto;
using BL.Models.CompaniesBL.Dto;
using BL.Models.DepartmentBL.Dto;
using BL.Models.EmployeeBL.Dto;
using BL.Models.PositionBL.Dto;
using DL.Models;

namespace BL
{
    public class MapperConfigurationBL : Profile
    {
        public MapperConfigurationBL()
        {
            //---------------------------------------Empoyee-----------------------------------------
            //Get
            CreateMap<Employee, ResponseGetEmployeeDtoBL>()
                .ForMember(x => x.FullAddress, y => y.MapFrom(x => "Street:" + x.Address.Street + " House:" + x.Address.House + " Flat:" + x.Address.Flat))
                .ForMember(x => x.PositionName, y => y.MapFrom(z => z.Position.Name))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name))
                .ForMember(x => x.AddressId, y => y.MapFrom(z => z.Address.Id))
                .ForMember(x => x.CompaniesName, y => y.MapFrom(z => z.Companies.Name));
            //Create
            CreateMap<AcceptCreateEmployeeDtoBL, Employee>();
            //Update
            CreateMap<AcceptUpdateEmployeeDtoBL, Employee>();

            //---------------------------------------Address-----------------------------------------
            //Create
            CreateMap<AcceptCreateAddressDtoBL, Address>();
            //Update
            CreateMap<AcceptUpdateAddressDtoBL, Address>();

            //-------------------------------------Companies-----------------------------------------
            //Get
            CreateMap<Companies, ResponseGetCompaniesDtoBL>();
            //Create
            CreateMap<AcceptCreateCompaniesDtoBL, Companies>();
            //Update
            CreateMap<AcceptUpdateCompaniesDtoBL, Companies>();

            //-----------------------------------Department-------------------------------------------
            //Get
            CreateMap<Department, ResponseGetDepartmentDtoBL>();

            //-----------------------------------Position----------------------------------------------
            CreateMap<Position, ResponseGetPositionDtoBL>();
        }
    }
}
