using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

        RoleViewModel viewModel;
        PermissionViewModel vmPermission;
        List<Permission> permissions;
        ObservableCollection<RoleDPO> roles;

        public WindowRole()
        {
            InitializeComponent();
            viewModel = new RoleViewModel();
            vmPermission = new PermissionViewModel();
            permissions = vmPermission.Permissions.ToList();

            roles = new ObservableCollection<RoleDPO>();

            foreach (var r in viewModel.Roles)
            {
                RoleDPO roleDPO = new RoleDPO();
                roleDPO = roleDPO.CopyFromRole(r);
                roles.Add(roleDPO);
            }
            lvRole.ItemsSource = roles;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRole wnModel = new WindowNewRole
            {
                Title = "Новая роль",
                Owner = this
            };

            int maxId = viewModel.MaxId() + 1;
            RoleDPO model = new RoleDPO
            {
                Id = maxId
            };

            wnModel.DataContext = model;
            wnModel.CbPremission.ItemsSource = permissions;

            if (wnModel.ShowDialog() == true)
            {
                Permission p = (Permission)wnModel.CbPremission.SelectedValue;
                model.Permission = p.PermissionName;
                roles.Add(model);

                Role Role = new Role();
                Role = Role.CopyFromRoleDPO(model);
                viewModel.Roles.Add(Role);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewRole wnModel = new WindowNewRole
            {
                Title = "Редактирование роли",
                Owner = this
            };

            RoleDPO model = (RoleDPO)lvRole.SelectedValue;
            RoleDPO RoleTemp;
            if (model != null)
            {
                RoleTemp = model.ShallowCopy();
                wnModel.DataContext = RoleTemp;
                wnModel.CbPremission.ItemsSource = permissions;
                wnModel.CbPremission.Text = RoleTemp.Permission;

                if (wnModel.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    Permission permission = wnModel.CbPremission.SelectedValue as Permission;
  
                    model.Permission = permission.PermissionName;
   
                    model.NameRole = RoleTemp.NameRole;
                    model.Discription = RoleTemp.Discription;

                    lvRole.ItemsSource = null;
                    lvRole.ItemsSource = roles;

                    // перенос данных из класса отображения данных в класс Role
                    FindRole finder = new FindRole(model.Id);
                    List<Role> listPerson = viewModel.Roles.ToList();
                    Role p = listPerson.Find(new Predicate<Role>(finder.RolePredicate));
                    p = p.CopyFromRoleDPO(model);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать роль для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            RoleDPO model = (RoleDPO)lvRole.SelectedItem;
            if (model != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные о роли: " +
                model.NameRole, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    //удаление данных в списке отображения данных
                    roles.Remove(model);

                    // удаление данных в списке классов ListRole<Role>
                    Role Role = new Role();
                    Role = Role.CopyFromRoleDPO(model);
                    viewModel.Roles.Remove(Role);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать роль для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
