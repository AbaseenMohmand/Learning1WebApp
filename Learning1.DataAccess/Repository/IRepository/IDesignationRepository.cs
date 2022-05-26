using Learning1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.DataAccess.Repository.IRepository
{
    public interface IDesignationRepository : IRepository<Designation>
    {
        void Update(Designation designation);
        
    }
}
