using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp19Var.Helper;
using WpfApp19Var.Model;
using WpfApp19Var.ViewModel;

namespace WpfApp19Var.View
{
    /// <summary>
    /// Логика взаимодействия для WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        public WindowRole()
        {
            InitializeComponent();
            RoleViewModel vmRole = new RoleViewModel();
            PermissionViewModel vmPermission = new PermissionViewModel();
            UserViewModel vmUser = new UserViewModel();
            List<Permission> Permissions = vmPermission.Permissions.ToList();


            ObservableCollection<RoleDPO> Roles = new ObservableCollection<RoleDPO>();

            FindUser finderUser;
            FindPermission finderPermission;
            foreach (var r in vmRole.Roles)
            {
                finderPermission = new FindPermission(r.PermissionId);
                Permission permission = Permissions.Find(new Predicate<Permission>(finderPermission.PermissionPredicate));

                Roles.Add(new RoleDPO
                {
                    Id = r.Id,
                    Permission = permission.PermissionName,
                    NameRole = r.NameRole,
                    Discription = r.Discription
                });
            }
            lvRole.ItemsSource = Roles;
        }
    }
}
