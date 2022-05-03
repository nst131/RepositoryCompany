using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using UI.Attributes;

namespace UI.Models.CompaniesUI.Dto
{
    [UniqueCompanyNameAtUpdate(nameof(AcceptUpdateCompaniesDtoUI.Id), nameof(AcceptUpdateCompaniesDtoUI.Name))]
    public class AcceptUpdateCompaniesDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
    }
}
