using System.Windows;
using WpfApp19Var.Model;
using WpfApp19Var.ViewModel;

namespace WpfApp19Var.View
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        UserViewModel viewModel;

        public WindowUser()
        {
            InitializeComponent();
            viewModel = new UserViewModel();
            lvUser.ItemsSource = viewModel.Users;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewUser wnNewModel = new WindowNewUser
            {
                Title = "Новый пользователь",
                Owner = this
            };

            int maxId = viewModel.MaxId() + 1;
            User model = new User
            {
                Id = maxId
            };

            wnNewModel.DataContext = model;
            if (wnNewModel.ShowDialog() == true)
            {
                viewModel.Users.Add(model);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewUser wnModel = new WindowNewUser
            {
                Title = "Редактирование пользователя",
                Owner = this
            };

            User model = lvUser.SelectedItem as User;
            if (model != null)
            {
                User tempUser = model.ShallowCopy();
                wnModel.DataContext = tempUser;


                if (wnModel.ShowDialog() == true)
                {
                    model.UserName = tempUser.UserName;
                    model.Password = tempUser.Password;
                    model.Status = tempUser.Status;
                    model.Email = tempUser.Email;

                    lvUser.ItemsSource = null;
                    lvUser.ItemsSource = viewModel.Users;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать пользователя для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            User model = (User)lvUser.SelectedItem;
            if (model != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные о пользователе: " +
                model.UserName, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    viewModel.Users.Remove(model);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать пользователя для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
