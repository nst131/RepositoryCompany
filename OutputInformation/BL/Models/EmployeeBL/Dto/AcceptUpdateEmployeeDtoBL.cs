namespace BL.Models.EmployeeBL.Dto
{
    public class AcceptUpdateEmployeeDtoBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public int CompaniesId { get; set; }
    }
}
