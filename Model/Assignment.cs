using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
