using Microsoft.AspNetCore.Identity;

namespace TimeLogger.Domain.Entites
{
    /// <summary>
    /// Represents a user with associated check-ins, check-outs, and room bookings.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// The user's first name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The user's surname.
        /// </summary>
        public string Surname { get; set; } = string.Empty;


        /// <summary>
        /// The collection of check-in records associated with the user.
        /// </summary>
        public ICollection<CheckIn> CheckIns { get; set; } = new List<CheckIn>();

        /// <summary>
        /// The collection of check-out records associated with the user.
        /// </summary>
        public ICollection<CheckOut> CheckOuts { get; set; } = new List<CheckOut>();

        /// <summary>
        /// The collection of room bookings made by the user.
        /// </summary>
        public ICollection<RoomBooking>? RoomBookings { get; set; }
    }
}