using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class ServiceClient
    {
        EmployeeManagerService.EmployeeManagerClient client = new EmployeeManagerService.EmployeeManagerClient();
        public List<Employee> GetEmployees()
        {
            var list = client.GetEmployees().ToList();
            var rt = new List<Employee>();
            list.ForEach(b => rt.Add(new Employee()
            {
                EmployeeID = b.EmployeeID,
                EmployeeName = b.EmployeeName,
                Salary = (int)b.Salary,
                DepartmentID = b.Department.DepartmentID,
            }
            ));
            return rt;
        }


        public List<Department> GetDepartments()
        {
            var list = client.GetDepartments().ToList();
            var rt = new List<Department>();
            list.ForEach(b => rt.Add(new Department()
            {
                DepartmentID = b.DepartmentID,
                DepartmentName = b.DepartmentName,
            }
            )); 
            return rt;
        }

        public bool AddEmployee(Employee newEmployee)
        {
            var employee = new EmployeeManagerService.Employee()
            {
                EmployeeID = newEmployee.EmployeeID,
                EmployeeName = newEmployee.EmployeeName,
                Salary = newEmployee.Salary,
                DepartmentID = newEmployee.DepartmentID,
            };
            return client.AddEmployee(employee);
        }
        public bool AddDepartment(Department newDepartment)
        {
            var department = new EmployeeManagerService.Department()
            {
                DepartmentID = newDepartment.DepartmentID,
                DepartmentName = newDepartment.DepartmentName,
            };
            return client.AddDepartment(department);
        }
        public bool EditEmployee(Employee newEmployee)
        {
            var employee = new EmployeeManagerService.Employee()
            {
                EmployeeID = newEmployee.EmployeeID,
                EmployeeName = newEmployee.EmployeeName,
                Salary = newEmployee.Salary,
                DepartmentID = newEmployee.DepartmentID,
            };
            return client.EditEmployee(employee.EmployeeID.ToString(), employee);
        }
        public bool EditDepartment(Department newDepartment)
        {
            var department = new EmployeeManagerService.Department()
            {
                DepartmentID = newDepartment.DepartmentID,
                DepartmentName = newDepartment.DepartmentName,
            };
            return client.EditDepartment(department.DepartmentID.ToString(), department);
        }
        public bool DeleteEmployee (string id)
        {
            return client.DeleteEmployee(id);

        }
        public bool DeleteDepartment (string id)
        {
            return client.DeleteDepartment(id);

        }
    }
}