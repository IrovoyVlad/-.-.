using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
