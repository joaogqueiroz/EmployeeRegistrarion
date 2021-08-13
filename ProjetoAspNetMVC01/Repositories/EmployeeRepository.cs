using Dapper;
using ProjetoAspNetMVC01.Domain.Entities;
using ProjetoAspNetMVC01.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC01.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string _connectionString;

        //Method for insert value in the attribute
        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Employee> Consult()
        {
            var query = @"
                        SELECT * FROM EMPLOYEE
                        ORDER BY NAME
                        ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Employee>(query).ToList();
            }
        }

        public Employee ConsultByID(Guid id)
        {
            var query = @"
                        SELECT * FROM EMPLOYEE
                        WHERE EMPLOYEEID = @id
                        ";

            using (var connection = new SqlConnection(_connectionString)) 
            {
                return connection.Query<Employee>(query, new { id }).FirstOrDefault();
            }
        }

        public Employee ConsultByDoc(String doc)
        {
            var query = @"
                        SELECT * FROM EMPLOYEE
                        WHERE DOC = @doc
                        ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Employee>(query, new { doc }).FirstOrDefault();
            }
        }

        public void Delete(Employee employee)
        {
            var query = @"
                        DELETE FROM EMPLOYEE
                        WHERE EMPLOYEEID = @EmployeeID
                        ";
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Execute(query, employee);
            }
        }

        public void Insert(Employee employee)
        {
            var query = @"
                    INSERT INTO EMPLOYEE(
                        EMPLOYEEID,
                        NAME,
                        DOC,
                        REGISTRATION,
                        ADMISSIONDATE)
                    VALUES(
                        NEWID(),
                        @Name,
                        @Doc,
                        @Registration,
                        @AdmissionDate)
                    ";
            using (var connection = new SqlConnection(_connectionString))
            {
                //Must be pass query and the object
                connection.Execute(query, employee);
            }
        }

        public void Update(Employee employee)
        {
            var query = @"
                    UPDATE EMPLOYEE 
                    SET
                        NAME = @Name,
                        DOC = @Doc,
                        REGISTRATION = @Registration,
                        ADMISSIONDATE = @AdmissionDate
                    WHERE
                         EMPLOYEEID = @EmployeeID
                    ";
            using (var connection = new SqlConnection(_connectionString)) 
            {
                //Must be pass query and the object
                connection.Execute(query, employee);
            }
        }
    }
}
