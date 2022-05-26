using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning1.Models
{
    public class Employye
    {
		[Key]
		public int EmployeeId { get; set; }

		[Column(TypeName = "nvarchar(250)")]
		[Required(ErrorMessage = "This field is required.")]
		[DisplayName("Full Name")]
		public string FullName { get; set; }

		[Column(TypeName = "varchar(10)")]
		[DisplayName("Emp. Code")]
		public string EmpCode { get; set; }

		[Column(TypeName = "varchar(100)")]
		[DisplayName("Office Location")]
		public string OfficeLocation { get; set; }


		[ValidateNever]
        [ForeignKey("Designation")]
        [DisplayName("Postion")]
        public int DesignationId { get; set; }
       
        public Designation? Designation { get; set; }
    }
}
