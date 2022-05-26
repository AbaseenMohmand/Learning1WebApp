using Learning1.DataAccess.Data;
using Learning1.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.DataAccess.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWorkRepository(ApplicationDbContext db)
        {
            _db = db;
            Designations = new DesignationRepository(_db);
            Employees = new EmployeeRepository(_db);
        }

        public IDesignationRepository Designations { get; private set; }
        public IEmployeeRepository Employees { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
