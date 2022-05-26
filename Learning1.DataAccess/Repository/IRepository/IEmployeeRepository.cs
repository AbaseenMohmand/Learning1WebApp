using Learning1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employye>
    {
        void Update(Employye employ);
        IEnumerable<Employye> GetEmployeesWithDesignations();
    }
}
