using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.Utility.HelperMethods
{
    public class Helpers
    {
        public static string Added = "Employee added successfully.";
        public static string EmployeeUpdated = "Employee updated successfully.";
        public static string EmployeeDeleted = "Employee deleted successfully.";


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
