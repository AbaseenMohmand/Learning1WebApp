using Learning1.DataAccess.Data;
using Learning1.DataAccess.Repository.IRepository;
using Learning1.Models;
using Learning1.Models.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LearningPractice.Areas.Admin.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index(string sortBy, string searchString,string currentFilter, int? pageNumber)
        {
            ViewBag.SortNameParam = string.IsNullOrEmpty(sortBy) ? "FullName desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var GetAllEmp =  _employeeRepository.GetEmployeesWithDesignations();

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            if (!String.IsNullOrEmpty(searchString))
            {

                GetAllEmp = _employeeRepository.GetEmployeesWithDesignations().Where(x=>x.FullName.Contains(searchString)).ToList();
            }

            switch (sortBy)
            {
                case "FullName desc":
                    GetAllEmp = (GetAllEmp.OrderByDescending(x=>x.FullName));
                    break;
                default:
                    //Filtering
                    GetAllEmp = (GetAllEmp.OrderBy(x => x.FullName));
                    break;
            }

            int pageSize = 3;

            return View(Learning1.Utility.HelperMethods.PaginatedList<Employye>.CreateAsync(GetAllEmp, pageNumber?? 1,pageSize));
            
            
        }

        [HttpGet]
        public  IActionResult UpsertEmp(int? id)
        {
            EmployyeVM employyeVM = new()
            {
                Employye = new(),
                DesignationList = _unitOfWork.Designations.GetAll().Select(x => new SelectListItem
                {
                    Text = x.DesignationName,
                    Value = x.Id.ToString()
                }),

            };

            

            if(id == null || id == 0)
            {
                
                return View( employyeVM);
            }
            else
            {
                employyeVM.Employye = _unitOfWork.Employees.GetFirstOrDefault(u => u.EmployeeId == id);
                return View(employyeVM);
            }
            
        }
        [HttpPost]
        public IActionResult UpsertEmp(EmployyeVM emp)
        {
            if (ModelState.IsValid)
            {
                if (emp.Employye.EmployeeId == 0)
                {
                    _unitOfWork.Employees.Add(emp.Employye);
                }
                else
                {
                    _unitOfWork.Employees.Update(emp.Employye);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");

            }

            return View(emp);         

        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _unitOfWork.Employees.GetFirstOrDefault(u => u.EmployeeId == id);
            _unitOfWork.Employees.Remove(employee);
            _unitOfWork.Save();
            //TempData["Message"] = HelperMethods.Helper.EmployeeDeleted;
            return RedirectToAction("Index");
        }

        //Filters
        //Action Filter
        [Authorize]

        public IActionResult Details()
        {

            return View();
        }
    }
}
