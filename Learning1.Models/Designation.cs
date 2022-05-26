using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string DesignationName { get; set; }
        public ICollection<Employye> Employyes { get; set; }
    }
}
