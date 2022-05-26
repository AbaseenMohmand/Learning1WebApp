using Learning1.DataAccess.Data;
using Learning1.DataAccess.Repository.IRepository;
using Learning1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employye>, IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Employye employ)
        {
            var objFromDb = _db.employyes.FirstOrDefault(x => x.EmployeeId == employ.EmployeeId);
            if (objFromDb != null)
            {
                objFromDb.FullName = employ.FullName;
                objFromDb.EmpCode = employ.EmpCode;
                objFromDb.OfficeLocation= employ.OfficeLocation;
                objFromDb.DesignationId = employ.DesignationId;
            }
        }

        public IEnumerable<Employye> GetEmployeesWithDesignations()
        {
            return _db.employyes.Include(x => x.Designation).ToList();
        }
    }
}
