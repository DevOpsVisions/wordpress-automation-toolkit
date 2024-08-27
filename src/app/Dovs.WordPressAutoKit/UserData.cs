using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dovs.WordPressAutoKit
{
    /// <summary>
    /// Represents user data including username, email, and membership level.
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Gets the email of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the membership level of the user.
        /// </summary>
        public string Membership { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="membership">The membership level of the user.</param>
        public UserData(string userName, string email, string membership)
        {
            UserName = userName;
            Email = email;
            Membership = membership;
        }
    }
}