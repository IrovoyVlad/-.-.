using System.Windows;
using WpfApp19Var.Model;
using WpfApp19Var.ViewModel;

namespace WpfApp19Var.View
{
    /// <summary>
    /// Логика взаимодействия для WindowPermission.xaml
    /// </summary>
    public partial class WindowPermission : Window
    {
        PermissionViewModel viewModel;

        public WindowPermission()
        {
            InitializeComponent();
            viewModel = new PermissionViewModel();
            lvPermisson.ItemsSource = viewModel.Permissions;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPermission wnNewModel = new WindowNewPermission
            {
                Title = "Новые права",
                Owner = this
            };

            int maxId = viewModel.MaxId() + 1;
            Permission model = new Permission
            {
                Id = maxId
            };

            wnNewModel.DataContext = model;
            if (wnNewModel.ShowDialog() == true)
            {
                viewModel.Permissions.Add(model);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPermission wnModel = new WindowNewPermission
            {
                Title = "Редактирование прав",
                Owner = this
            };

            Permission model = lvPermisson.SelectedItem as Permission;
            if (model != null)
            {
                Permission tempPermission = model.ShallowCopy();
                wnModel.DataContext = tempPermission;


                if (wnModel.ShowDialog() == true)
                {
                    model.PermissionName = tempPermission.PermissionName;
                    model.DateCreate = tempPermission.DateCreate;
                    model.Discription = tempPermission.Discription;

                    lvPermisson.ItemsSource = null;
                    lvPermisson.ItemsSource = viewModel.Permissions;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать права для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Permission model = (Permission)lvPermisson.SelectedItem;
            if (model != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные прав: " +
                model.PermissionName, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    viewModel.Permissions.Remove(model);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать права для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
