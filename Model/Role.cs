using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp19Var.Model
{
    internal class Role
    {
        public int Id { get; set; }
        public int PermitionId { get; set; }
        public string NameRole { get; set; }
        public string Discription { get; set; }

        public Role() { }

        public Role(int id, int permitionId, string nameRole, string discription)
        {
            Id = id;
            PermitionId = permitionId;
            NameRole = nameRole;
            Discription = discription;
        }
    }
}
