using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Learning1.Models.ViewModel
{
    public class EmployyeVM
    {
        public Employye Employye { get; set; }

        [ValidateNever]
        
        public IEnumerable<SelectListItem>? DesignationList { get; set; }
    }
}
