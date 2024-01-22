using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp19Var.Model
{
    enum UserStatus
    {
        Offline,
        Online
    }

    internal class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }

        public User() { }

        public User(int id, string userName, string password, string email, UserStatus status)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Email = email;
            Status = status;
        }
    }
}
