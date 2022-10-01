using felipehilst_d7_avaliacao.Data;
using System.Collections.Generic;
using System.Linq;

namespace felipehilst_d7_avaliacao.Services
{
    public class LoginService : ILoginService
    {
        private readonly LoginAppContext context;

        public LoginService(LoginAppContext context)
        {
            this.context = context;
        }

        public bool IsValidUser(string email, string psw)
        {
            List<User>? _users = context.Users?.ToList();
            if (_users == null) return false;

            User? user = _users.FirstOrDefault(u => u.Email.Equals(email));
            if (user == null) return false;

            if (user.Password != psw) return false;
            return true;
        }
    }
}
