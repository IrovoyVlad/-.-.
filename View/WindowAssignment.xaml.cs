using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
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
    /// Логика взаимодействия для WindowAssignment.xaml
    /// </summary>
    public partial class WindowAssignment : Window
    {

        AssignmentViewModel viewModel;
        RoleViewModel vmRole;
        UserViewModel vmUser;
        List<Role> roles;
        List<User> users;
        ObservableCollection<AssignmentDPO> assignments;

        public WindowAssignment()
        {
            InitializeComponent();

            viewModel = new AssignmentViewModel();
            vmRole = new RoleViewModel();
            vmUser = new UserViewModel();
            roles = vmRole.Roles.ToList();
            users = vmUser.Users.ToList();

            assignments = new ObservableCollection<AssignmentDPO>();

            foreach (var a in viewModel.Assignments)
            {
                AssignmentDPO assignment = new AssignmentDPO();
                assignment = assignment.CopyFromAssignment(a);
                assignments.Add(assignment);
            }
            lvAssignment.ItemsSource = assignments;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAssignment wnModel = new WindowNewAssignment
            {
                Title = "Новое назначение прав",
                Owner = this
            };

            int maxId = viewModel.MaxId() + 1;
            AssignmentDPO model = new AssignmentDPO
            {
                Id = maxId
            };

            wnModel.DataContext = model;
            wnModel.CbUser.ItemsSource = users;
            wnModel.CbRole.ItemsSource = roles;
            if (wnModel.ShowDialog() == true)
            {
                Role p = (Role)wnModel.CbRole.SelectedValue;
                model.Role = p.NameRole;
                User u = (User)wnModel.CbUser.SelectedValue;
                model.User = u.UserName;
                assignments.Add(model);

                Assignment assignment = new Assignment();
                assignment = assignment.CopyFromAssignmentDPO(model);
                viewModel.Assignments.Add(assignment);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewAssignment wnModel = new WindowNewAssignment
            {
                Title = "Редактирование назначения прав",
                Owner = this
            };

            AssignmentDPO model = (AssignmentDPO)lvAssignment.SelectedValue;
            AssignmentDPO assignmentTemp;
            if (model != null)
            {
                assignmentTemp = model.ShallowCopy();
                wnModel.DataContext = assignmentTemp;
                wnModel.CbUser.ItemsSource = users;
                wnModel.CbRole.ItemsSource = roles;
                wnModel.CbRole.Text = assignmentTemp.Role;
                wnModel.CbUser.Text = assignmentTemp.User;

                if (wnModel.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    User user = wnModel.CbUser.SelectedValue as User;
                    Role role = wnModel.CbRole.SelectedValue as Role;
                    model.Role = role.NameRole;
                    model.User = user.UserName;
                    model.DateCreate = assignmentTemp.DateCreate;

                    lvAssignment.ItemsSource = null;
                    lvAssignment.ItemsSource = assignments;

                    // перенос данных из класса отображения данных в класс Assignment
                    FindAssignment finder = new FindAssignment(model.Id);
                    List<Assignment> listRole = viewModel.Assignments.ToList();
                    Assignment p = listRole.Find(new Predicate<Assignment>(finder.AssignmentPredicate));
                    p = p.CopyFromAssignmentDPO(model);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать назначение прав для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            AssignmentDPO model = (AssignmentDPO)lvAssignment.SelectedItem;
            if (model != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить право: " +
                model.Role + "  у пользователя: " + model.User, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    //удаление данных в списке отображения данных
                    assignments.Remove(model);

                    // удаление данных в списке классов ListAssignment<Assignment>
                    Assignment assignment = new Assignment();
                    assignment = assignment.CopyFromAssignmentDPO(model);
                    viewModel.Assignments.Remove(assignment);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать назначение прав для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
