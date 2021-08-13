using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC01.Domain.Entities
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public String Name { get; set; }
        public String Doc { get; set; }
        public String Registration { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
