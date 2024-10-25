using Microsoft.AspNetCore.Identity;

namespace In_Out_Manager.Domain.Entites
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public ICollection<CheckIn> CheckIns { get; set; }
        public ICollection<CheckOut> CheckOuts { get; set; }
        public ICollection<RoomBooking>? RoomBookings { get; set; }
    }
}