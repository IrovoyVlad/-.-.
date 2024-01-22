using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public WindowAssignment()
        {
            InitializeComponent();

            AssignmentViewModel vmAssignment = new AssignmentViewModel();
            RoleViewModel vmRole = new RoleViewModel();
            UserViewModel vmUser = new UserViewModel();
            List<Role> roles = vmRole.Roles.ToList();
            List<User> users = vmUser.Users.ToList();

            ObservableCollection<AssignmentDPO> assignments = new ObservableCollection<AssignmentDPO> ();

            FindUser finderUser;
            FindRole finderRole;
            foreach (var a in vmAssignment.Assignments)
            {
                finderRole = new FindRole(a.RoleId);
                Role rol = roles.Find(new Predicate<Role>(finderRole.RolePredicate));

                finderUser = new FindUser(a.UserId);
                User user = users.Find(new Predicate<User>(finderUser.UserPredicate));

                assignments.Add(new AssignmentDPO
                {
                    Id = a.Id,
                    Role = rol.NameRole,
                    User = user.UserName,
                    DateCreate = a.DateCreate
                });
            }
            lvAssignment.ItemsSource = assignments;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        { 

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
