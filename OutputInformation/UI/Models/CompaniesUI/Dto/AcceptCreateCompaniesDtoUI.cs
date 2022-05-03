using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using UI.Attributes;

namespace UI.Models.CompaniesUI.Dto
{
    public class AcceptCreateCompaniesDtoUI
    {
        [UniqueCompanyNameAtCreate]
        [JsonProperty(PropertyName = "name", Order = 0, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
    }
}
