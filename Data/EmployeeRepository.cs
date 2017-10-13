using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCore.Models;

namespace ApiCore.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext empContext;
        public EmployeeRepository(EmployeeContext _empContext)
        {
            empContext = _empContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return empContext.Employees.ToList();
        }
        public Employee GetEmployee(int EmpId)
        {
            return empContext.Employees.Where(e => e.EmployeeId == EmpId).FirstOrDefault();
        }
        public void AddEmployee(Employee emp)
        {
            empContext.Employees.Add(emp);
            empContext.SaveChanges();
        }
        public void UpdateEmployee(int EmpId, Employee emp)
        {
            Employee empObj = empContext.Employees.Where(e => e.EmployeeId == EmpId).FirstOrDefault();
            empObj.FirstName = emp.FirstName;
            empObj.Title = emp.Title;

            empContext.Employees.Update(empObj);
            empContext.SaveChanges();
        }
        public void DeleteEmployee(int EmpId)
        {
            Employee emp = empContext.Employees.Where(e => e.EmployeeId == EmpId).FirstOrDefault();
            empContext.Employees.Remove(emp);
            empContext.SaveChanges();
        }
        //Test
    }
}
