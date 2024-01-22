using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.Model;

namespace WpfApp19Var.ViewModel
{
    internal class AssignmentViewModel
    {
        public ObservableCollection<Assignment> Assignments { get; set; } = new ObservableCollection<Assignment>();

        public AssignmentViewModel() 
        {
            Assignments.Add(
                new Assignment()
                {
                    Id = Assignments.Count + 1,
                    RoleId = 1,
                    UserId = Assignments.Count + 1,
                    DateCreate = DateTime.Now.AddYears(-3),
                });
            Assignments.Add(
                new Assignment()
                {
                    Id = Assignments.Count + 1,
                    RoleId = 2,
                    UserId = Assignments.Count + 1,
                    DateCreate = DateTime.Now.AddYears(-2),
                });
            Assignments.Add(
                new Assignment()
                {
                    Id = Assignments.Count + 1,
                    RoleId = 2,
                    UserId = Assignments.Count + 1,
                    DateCreate = DateTime.Now.AddYears(-1),
                });
            Assignments.Add(
                new Assignment()
                {
                    Id = Assignments.Count + 1,
                    RoleId = 2,
                    UserId = Assignments.Count + 1,
                    DateCreate = DateTime.Now.AddMonths(-3),
                });
        }

        /// <summary>
        /// Нахождение максимального Id
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var item in this.Assignments)
            {
                if (max < item.Id)
                {
                    max = item.Id;
                };
            }
            return max;
        }
    }
}
