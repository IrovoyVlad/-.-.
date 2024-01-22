using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.ViewModel;

namespace WpfApp19Var.Model
{
    class AssignmentDPO
    {
        public int Id { get; set; }

        public string User { get; set; }
        public string Role { get; set; }
        public DateTime DateCreate { get; set; }

        public AssignmentDPO(int id, string user, string role, DateTime dateCreate)
        {
            Id = id;
            User = user;
            Role = role;
            DateCreate = dateCreate;
        }

        public AssignmentDPO() { }

        public AssignmentDPO CopyFromAssignment(Assignment assignment)
        {
            AssignmentDPO assignmetDPO = new AssignmentDPO();
            UserViewModel user = new UserViewModel();
            string userName = string.Empty;
            foreach (var p in user.Users)
            {
                if (p.Id == assignment.UserId)
                {
                    userName = p.UserName;
                    break;
                }
            }

            RoleViewModel document = new RoleViewModel();
            string doc = string.Empty;
            foreach (var d in document.Roles)
            {
                if (d.Id == assignment.RoleId)
                {
                    doc = d.NameRole;
                    break;
                }
            }

            if (userName != string.Empty && doc != string.Empty)
            {
                assignmetDPO.Id = assignment.Id;
                assignmetDPO.User = userName;
                assignmetDPO.Role = doc;
                assignmetDPO.DateCreate = assignment.DateCreate;
            }
            return assignmetDPO;
        }

        public AssignmentDPO ShallowCopy()
        {
            return (AssignmentDPO)this.MemberwiseClone();
        }
    }
}
