using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.ViewModel;

namespace WpfApp19Var.Model
{
    internal class Assignment
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime DateCreate { get; set; }

        public Assignment(int id, int userId, int roleId, DateTime dateCreate)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
            DateCreate = dateCreate;
        }

        public Assignment() { }

        public Assignment CopyFromAssignmentDPO(AssignmentDPO p)
        {
            UserViewModel user = new UserViewModel();
            int userId = 0;
            foreach (var r in user.Users)
            {
                if (r.UserName == p.User)
                {
                    userId = r.Id;
                    break;
                }
            }

            RoleViewModel role = new RoleViewModel();
            int roleId = 0;
            foreach (var r in role.Roles)
            {
                if (r.NameRole == p.Role)
                {
                    roleId = r.Id;
                    break;
                }
            }

            if (userId != 0 && roleId != 0)
            {
                this.Id = p.Id;
                this.UserId = userId;
                this.RoleId = roleId;
                this.DateCreate = p.DateCreate;
            }

            return this;
        }
    }
}
