using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            //Get data from Repository
          var employeedata = _employeeRepository.GetEmployeeById(id);
            return MapToEmployeeDto(employeedata);
        }
        private EmployeeDto MapToEmployeeDto(EmployeeData employee)
        {
            var employeeDto = new EmployeeDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Department = employee.Department
            };
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            //Get data from Repository
           var employee= _employeeRepository.GetEmployees();
            var employeeDto = MapToEmployeesDto(employee);
            return employeeDto;
        }
        private IEnumerable<EmployeeDto> MapToEmployeesDto(IEnumerable<EmployeeData> employeeData)
        {
            var employeeDtos = new List<EmployeeDto>();
            foreach (var employee in employeeData)
            {
                var employeeDto = new EmployeeDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Department = employee.Department
                    //Age = employee.Age,
                    //Address = employee.Address,

                };
                employeeDtos.Add(employeeDto);
            }
            return employeeDtos;
        }

        public bool InsertEmployee(EmployeeDto insertion)
        {
           var employee = _employeeRepository.InsertEmployee(MapToInsertDto(insertion));
            return employee;
        }
        private EmployeeData MapToInsertDto(EmployeeDto employee)
        {
            var insertDto = new EmployeeData()
            {
                Name=employee.Name,
                Address=employee.Address,
                Age=employee.Age,
                Department=employee.Department
            };
            return insertDto;

        }
        public bool UpdateEmployee(EmployeeDto updation)
        {
            var employee = _employeeRepository.UpdateEmployee(MapToUpdateData(updation));
            return employee;
        }
        private EmployeeData MapToUpdateData(EmployeeDto employee)
        {
            var updateDto = new EmployeeData()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Department = employee.Department,
                Address=employee.Address
            };
            return updateDto;
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
                return true;
            }

            catch (Exception)
            {
                throw;

            }



        }

        public EmployeeDto GetEmployee(int id)
        {
            throw new System.NotImplementedException();
        }

      /*  public bool DeleteEmployee(int id)
        {
            throw new System.NotImplementedException();
        }*/

        /*public EmployeeDto InsertEmployee(EmployeeDto insertion)
        {
            throw new System.NotImplementedException();
        }*/

        /* EmployeeDto IEmployeeService.UpdateEmployee(EmployeeData updation)
         {
             throw new System.NotImplementedException();
         }
*/



    }
}
