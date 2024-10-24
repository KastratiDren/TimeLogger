using Microsoft.AspNetCore.Identity;

namespace In_Out_Manager.Domain.Entites
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Stores the first name of the user.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Stores the last name of the user.
        /// </summary>
        public string Surename { get; set; } = string.Empty;
    }
}
