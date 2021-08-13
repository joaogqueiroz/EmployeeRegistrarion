using Microsoft.AspNetCore.Mvc;
using ProjetoAspNetMVC01.Domain.Entities;
using ProjetoAspNetMVC01.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC01.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDomainService _employeeDomainService;

        public EmployeeController(EmployeeDomainService employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost] //method that recive post from form(submit)
        public IActionResult Registration(string name, string document, string registration, DateTime admissionDate)
        {
            try
            {
                var employee = new Employee();
                employee.Name = name;
                employee.Doc = document;
                employee.Registration = registration;
                employee.AdmissionDate = admissionDate;
                _employeeDomainService.EmployeeRegistration(employee);

                TempData["Message"] = "Employee registred successfully";

            }
            catch (Exception e) 
            {
                TempData["Message"] = $"[ERROR] Employee not registred   { e.Message}";
            }
            return View();
        }
    }
}
