using Learning1.DataAccess.Data;
using Learning1.DataAccess.Repository.IRepository;
using Learning1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.DataAccess.Repository
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        private ApplicationDbContext _db;
        public DesignationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            
        }
       

        public void Update(Designation designation)
        {
            _db.designations.Update(designation);
        }
    }
}
