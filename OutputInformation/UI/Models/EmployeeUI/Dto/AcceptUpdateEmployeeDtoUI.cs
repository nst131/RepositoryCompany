﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace UI.Models.EmployeeUI.Dto
{
    public class AcceptUpdateEmployeeDtoUI
    {
        [JsonProperty(PropertyName = "id", Order = 0, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name", Order = 1, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "serName", Order = 2, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SerName { get; set; }

        [JsonProperty(PropertyName = "patronymic", Order = 3, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Patronymic { get; set; }

        [JsonProperty(PropertyName = "telephone", Order = 4, Required = Required.Always)]
        [RegularExpression(@"[0-9]{2} [0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Не правильный номер телефона")]
        public string Telephone { get; set; }

        [JsonProperty(PropertyName = "positionId", Order = 5, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int PositionId { get; set; }

        [JsonProperty(PropertyName = "departmentId", Order = 6, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int DepartmentId { get; set; }

        [JsonProperty(PropertyName = "addressId", Order = 7, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int AddressId { get; set; }

        [JsonProperty(PropertyName = "street", Order = 8, Required = Required.Always)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "house", Order = 9, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int House { get; set; }

        [JsonProperty(PropertyName = "flat", Order = 10, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int Flat { get; set; }

        [JsonProperty(PropertyName = "companiesId", Order = 11, Required = Required.Always)]
        [Range(1, int.MaxValue, ErrorMessage = "Значение вышло за пределы допустимого диапозона")]
        public int CompaniesId { get; set; }
    }
}
