using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePortal.Filters;
using EmployeePortal.Models;
using EmployeePortal.Operations;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [CustomActionFilter]
    public class EmployeesController : Controller
    {
        private readonly ICrudOperation _operation;

        public EmployeesController(ICrudOperation operation)
        {
            _operation = operation;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _operation.Create(model);
                return RedirectToAction("GetModel");
            }
            return View();
        }

        public IActionResult GetAll()
        {
            ViewBag.TotalEmployee = _operation.GetAllEmployees().Count();
            ViewData["Employees"] = _operation.GetAllEmployees();
            return View(_operation.GetAllEmployees());
        }

        public IActionResult Index()
        {
            TempData["Employee"] = "KevalKiniyara";
            return View();
        }

        public IActionResult IndexData()
        {
            if (TempData.ContainsKey("Employee"))
            {
                var userName = TempData["Employee"].ToString();
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateDetail(int id)
        {
            return View(_operation.FindById(id));
        }
        [HttpPost]
        public IActionResult UpdateDetail(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _operation.UpdateEmployee(model);
                return RedirectToAction("GetAll");
            }
            return View();
        }

        public IActionResult QueryData(EmployeeModel model)
        {
            _operation.QueryMethod(model);
            return View();
        }
    }
}