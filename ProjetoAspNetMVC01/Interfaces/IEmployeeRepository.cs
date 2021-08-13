using ProjetoAspNetMVC01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC01.Interfaces
{
    public interface IEmployeeRepository
    {
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        
        //For consulting a list of object
        //We must use list instead  of void
        //Basically defining the return type
        //It can be list, object or variable.
        List<Employee> Consult();
        Employee ConsultByID(Guid id);
        Employee ConsultByDoc(String doc);


    }
}
