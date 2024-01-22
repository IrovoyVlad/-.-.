using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.Model;

namespace WpfApp19Var.ViewModel
{
    internal class PermissionViewModel
    {
        public ObservableCollection<Permission> Permissions { get; set; } = new ObservableCollection<Permission>();

        public PermissionViewModel() 
        {
            Permissions.Add(
                new Permission()
                {
                    Id = Permissions.Count + 1,
                    PermissionName = "Super user",
                    Discription = "for use by the administration",
                    DateCreate = DateTime.Now.AddYears(-3),
                });
            Permissions.Add(
                new Permission()
                {
                    Id = Permissions.Count + 1,
                    PermissionName = "Default user",
                    Discription = "none",
                    DateCreate = DateTime.Now.AddYears(-3),
                });
        }

        /// <summary>
        /// Нахождение максимального Id
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var item in this.Permissions)
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
