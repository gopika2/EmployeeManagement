using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using System.Collections.Generic;

namespace EmployeeManagement.UI.Providers.Contracts
{
    public interface IEmployeeApiClient
    {
        IEnumerable<EmployeeViewModel> GetAllEmployee();
        EmployeeDetailedViewModel GetEmployeeById(int employeeId);
        bool DeleteEmployeeById(int employeeId);
        bool InsertEmployee(EmployeeViewModel employee);
        bool UpdateEmployee(EmployeeViewModel employee);
    }
}
