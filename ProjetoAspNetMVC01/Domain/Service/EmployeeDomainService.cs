using ProjetoAspNetMVC01.Domain.Entities;
using ProjetoAspNetMVC01.Interfaces;
using ProjetoAspNetMVC01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC01.Domain.Service 
{
    public class EmployeeDomainService
    {
        private IEmployeeRepository _employeeRepository;

        //Method for insert value in the attribute
        public EmployeeDomainService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void EmployeeRegistration(Employee employee) 
        {
            //Check if doc exists
            if (_employeeRepository.ConsultByDoc(employee.Doc) != null)
            {
                //Generating erro messege
                throw new Exception($"The document {employee.Doc} already exists, try with another.");
            }

            //Check if adimission date is greater than 30 days
            // before the actual date.
            var MinAdmissionDate = DateTime.Now.AddDays(-30);
            if (!(employee.AdmissionDate >= MinAdmissionDate))
            {
                //Generating erro messege
                throw new Exception($"Enter an admission date greater than or equal to {employee.AdmissionDate.ToString("dd/MM/yyyy")}");

            }
            _employeeRepository.Insert(employee);
        }
    }
}
