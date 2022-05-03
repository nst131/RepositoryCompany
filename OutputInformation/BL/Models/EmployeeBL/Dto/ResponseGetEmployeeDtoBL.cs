namespace BL.Models.EmployeeBL.Dto
{
    public class ResponseGetEmployeeDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public int AddressId { get; set; }
        public string FullAddress { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public string CompaniesName { get; set; }
    }
}
