using DL.Interfaces;

namespace DL.Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public Address Address { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int CompaniesId { get; set; }
        public Companies Companies { get; set; }
    }
}
