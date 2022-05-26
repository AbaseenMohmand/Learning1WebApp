﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDesignationRepository Designations { get; }
        IEmployeeRepository Employees { get; }
        void Save();
    }
}
