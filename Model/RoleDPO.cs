using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp19Var.Model
{
    class RoleDPO
    {
        public int Id { get; set; }
        public string Permission { get; set; }
        public string NameRole { get; set; }
        public string Discription { get; set; }

        public RoleDPO() { }

        public RoleDPO(int id, string permition, string nameRole, string discription)
        {
            Id = id;
            Permission = permition;
            NameRole = nameRole;
            Discription = discription;
        }
    }
}
