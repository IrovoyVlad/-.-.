using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.Model;

namespace WpfApp19Var.ViewModel
{
    internal class RoleViewModel
    {
        public ObservableCollection<Role> Roles { get; set; } = new ObservableCollection<Role>();

        public RoleViewModel() 
        {
            Roles.Add(
                new Role()
                {
                    Id = Roles.Count + 1,
                    PermissionId = 1,
                    NameRole = "Admin",
                    Discription = "Super user"
                });
            Roles.Add(
                new Role()
                {
                    Id = Roles.Count + 1,
                    PermissionId = 2,
                    NameRole = "User",
                    Discription = "Default user"
                });

        }

        /// <summary>
        /// Нахождение максимального Id
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var item in this.Roles)
            {
                if (max < item.Id)
                {
                    max = item.Id;
                };
            }
            return max;
        }
    }
}
