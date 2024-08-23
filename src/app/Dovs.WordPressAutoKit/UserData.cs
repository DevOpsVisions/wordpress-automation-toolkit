using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dovs.WordPressAutoKit
{
    public class UserData
    {
        public string UserName { get; }
        public string Email { get; }

        public string Membership { get; }

        public UserData(string userName, string email, string membership)
        {
            UserName = userName;
            Email = email;
            Membership = membership;
        }
    }
}
