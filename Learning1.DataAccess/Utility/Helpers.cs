using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.DataAccess.Utility

{
    public static class Helpers
    {
        public static string Admin = "Admin";
        public static string Employee = "Employee";
        
        public static List<SelectListItem> GetDropDownForRoles()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = Helpers.Admin, Text = Helpers.Admin},
                new SelectListItem{Value = Helpers.Employee, Text = Helpers.Employee},
            };
        }
    }
}
