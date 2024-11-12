using Microsoft.AspNetCore.Identity;

namespace TimeLogger.Domain.Entites
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
        public ICollection<CheckOut> CheckOuts { get; set; } = new List<CheckOut>();
        public ICollection<RoomBooking>? RoomBookings { get; set; }
    }
}