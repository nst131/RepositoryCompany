using System.Collections.Generic;
using DL.Interfaces;

namespace DL.Models
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
