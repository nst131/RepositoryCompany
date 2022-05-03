using AutoMapper;
using BL.Models.AddressBL.Dto;
using BL.Models.CompaniesBL.Dto;
using BL.Models.DepartmentBL.Dto;
using BL.Models.EmployeeBL.Dto;
using BL.Models.PositionBL.Dto;
using UI.Models.CompaniesUI.Dto;
using UI.Models.DepartmentUI.Dto;
using UI.Models.EmployeeUI.Dto;
using UI.Models.PositionUI.Dto;

namespace UI
{
    public class MapperConfigurationUI : Profile
    {
        public MapperConfigurationUI()
        {
            //---------------------------Employee---------------------------
            //Get
            CreateMap<ResponseGetEmployeeDtoBL, ResponseGetEmployeeDtoUI>();
            //Create
            CreateMap<AcceptCreateEmployeeDtoUI, AcceptCreateAddressDtoBL>();
            CreateMap<AcceptCreateEmployeeDtoUI, AcceptCreateEmployeeDtoBL>();
            //Update
            CreateMap<AcceptUpdateEmployeeDtoUI, AcceptUpdateAddressDtoBL>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.AddressId))
                .ForMember(x => x.EmployeeId, y=> y.MapFrom(z => z.Id));
            CreateMap<AcceptUpdateEmployeeDtoUI, AcceptUpdateEmployeeDtoBL>();

            //--------------------------Compamies---------------------------
            //Get
            CreateMap<ResponseGetCompaniesDtoBL, ResponseGetCompaniesDtoUI>();
            //Create
            CreateMap<AcceptCreateCompaniesDtoUI, AcceptCreateCompaniesDtoBL>();
            //Update
            CreateMap<AcceptUpdateCompaniesDtoUI, AcceptUpdateCompaniesDtoBL>();

            //-------------------------Department----------------------------
            //Get
            CreateMap<ResponseGetDepartmentDtoBL, ResponseGetDepartmentDtoUI>();

            //-------------------------Position------------------------------
            CreateMap<ResponseGetPositionDtoBL, ResponseGetPositionDtoUI>();
        }
    }
}
