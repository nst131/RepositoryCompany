using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace UI.Models.CompaniesUI.Dto
{
    public class AcceptDeleteCompaniesDtoUI
    {
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        public int Id { get; set; }
    }
}
