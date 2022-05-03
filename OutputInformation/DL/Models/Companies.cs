using System.Collections.Generic;
using DL.Interfaces;

namespace DL.Models
{
    public class Companies : IEntity, IName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
