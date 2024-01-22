using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.Model;

namespace WpfApp19Var.Helper
{
    internal class FindAssignment
    {
        int id;
        public FindAssignment(int id)
        {
            this.id = id;
        }
        public bool AssignmentPredicate(Assignment a)
        {
            return a.Id == id;
        }
    }
}
