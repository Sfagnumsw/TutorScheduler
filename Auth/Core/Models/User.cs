using System.Data;
using System.Security.Principal;

namespace Auth.Core.Models
{
    public class User : Recipient
    {
        private User() { }
        public Account Account { get; set; } = null!;

        public static User Create(string name, Role role, string tgTag, Account account)
        {
            return new() { Name = name, Role = role, TGTag = tgTag, Account = account };
        }
    }
}
