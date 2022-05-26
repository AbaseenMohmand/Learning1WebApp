using Learning1.DataAccess.Data;
using Learning1.DataAccess.Repository.IRepository;
using Learning1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningPractice.Areas.Admin.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DesignationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string sortBy)
        {
            ViewBag.SortNameParam = string.IsNullOrEmpty(sortBy) ? "FullName desc" : "";
            var GetAllDesignations = _unitOfWork.Designations.GetAll().AsQueryable();
            switch (sortBy)
            {
                case "FullName desc":
                    GetAllDesignations = (GetAllDesignations.OrderByDescending(x=>x.DesignationName));
                    break;
                default:
                    //Filtering
                    GetAllDesignations = (GetAllDesignations.OrderBy(x => x.DesignationName));
                    break;
            }
            return View(GetAllDesignations);
        }

        [HttpGet]
        public  IActionResult UpsertDesig(int? id)
        {
            if(id == null)
            {
                return View(new Designation());
            }
            else
            {
                return View(_unitOfWork.Designations.GetFirstOrDefault(u=>u.Id ==id));
            }
            
        }
        [HttpPost]
        public IActionResult UpsertDesig(Designation designation)
        {
            if (ModelState.IsValid)
            {
                if (designation.Id == null)
                {
                    _unitOfWork.Designations.Add(designation);
                }
                else
                {
                    _unitOfWork.Designations.Update(designation);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");

            }

            return View(designation);         

        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _unitOfWork.Designations.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Designations.Remove(employee);
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
