namespace BL.Models.AddressBL.Dto
{
    public class AcceptUpdateAddressDtoBL
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
    }
}
