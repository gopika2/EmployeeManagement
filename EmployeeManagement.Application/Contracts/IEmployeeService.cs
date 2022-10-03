using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployeeById(int id);

        //EmployeeDto GetEmployee(int id);
        bool InsertEmployee(EmployeeDto insertion);
        bool UpdateEmployee(EmployeeDto updation);
        bool DeleteEmployee(int id);

    }
}
