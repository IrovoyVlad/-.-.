using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.Model;

namespace WpfApp19Var.ViewModel
{
    internal class UserViewModel
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public UserViewModel() 
        {
            Users.Add(
                new User()
                {
                    Id = Users.Count + 1,
                    UserName = "Иван Иванов",
                    Password = "54as51644",
                    Email = "ivan@mail.ru",
                    Status = UserStatus.Online
                });
            Users.Add(
                new User()
                {
                    Id = Users.Count + 1,
                    UserName = "Петр Петров",
                    Password = "54as51644",
                    Email = "peter@mail.ru",
                    Status = UserStatus.Offline
                });
            Users.Add(
                new User()
                {
                    Id = Users.Count + 1,
                    UserName = "Виктор Викторов",
                    Password = "54as51644",
                    Email = "viktor@mail.ru",
                    Status = UserStatus.Online
                });
            Users.Add(
                new User()
                {
                    Id = Users.Count + 1,
                    UserName = "Сидор Сидоров",
                    Password = "54as51644",
                    Email = "sidor@mail.ru",
                    Status = UserStatus.Offline
                });
        }
    }
}
