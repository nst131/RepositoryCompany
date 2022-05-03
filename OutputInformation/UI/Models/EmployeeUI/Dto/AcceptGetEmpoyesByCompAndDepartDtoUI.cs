using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace UI.Models.EmployeeUI.Dto
{
    public class AcceptGetEmpoyesByCompAndDepartDtoUI
    {
        [JsonProperty(PropertyName = "companyId", Order = 0, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int CompanyId { get; set; }

        [JsonProperty(PropertyName = "departmentId", Order = 1, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int DepartmentId { get; set; }
    }
}
