using Newtonsoft.Json;

namespace UI.Models.EmployeeUI.Dto
{
    public class ResponseGetEmployeeDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "serName", Order = 2, Required = Required.Always)]
        public string SerName { get; set; }

        [JsonProperty(PropertyName = "patronymic", Order = 3, Required = Required.Always)]
        public string Patronymic { get; set; }

        [JsonProperty(PropertyName = "telephone", Order = 4, Required = Required.Always)]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "addressId", Order = 5, Required = Required.Always)]
        public int AddressId { get; set; }

        [JsonProperty(PropertyName = "fullAddress", Order = 6, Required = Required.Always)]
        public string FullAddress { get; set; }

        [JsonProperty(PropertyName = "positionName", Order = 7, Required = Required.Always)]
        public string PositionName { get; set; }

        [JsonProperty(PropertyName = "departmentName", Order = 8, Required = Required.Always)]
        public string DepartmentName { get; set; }

        [JsonProperty(PropertyName = "companiesName", Order = 9, Required = Required.Always)]
        public string CompaniesName { get; set; }
    }
}
