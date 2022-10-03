using EmployeeManagement.API.Models;
using EmployeeManagement.Application.Contracts;
using EmployeeManagement.Application.Models;
using EmployeeManagement.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                /// get employee by calling GetEmployeeById() in IEmployeeService and store it in a variable and Map that variable to EmployeeDetailedViewModel.  
                var  employeeById = _employeeService.GetEmployeeById(employeeId);
                return Ok(MapToemployeeById(employeeById));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private EmployeeDetailedViewModel MapToemployeeById(EmployeeDto employee)
        {
            var employeeById = new EmployeeDetailedViewModel();
           {
                employeeById.Id = employee.Id;
                employeeById.Name = employee.Name;
                employeeById.Department = employee.Department;
                employeeById.Age = employee.Age;
                employeeById.Address = employee.Address;
            }
            return employeeById;
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetEmployees()
        {
            /* get employees by calling GetEmployees() in IEmployeeService and store it in a variable and Map that variable to EmployeeDetailedViewModel. 
            return Ok(listOfEmployeeViewModel);*/
            try
            {
                var listOfEmployeeViewModel = _employeeService.GetEmployees();
                return Ok(listOfEmployeeViewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        //Create Employee Insert, Update and Delete Endpoint here
        [HttpPost]
        [Route("insert-employee")]

        public IActionResult InsertEmployee([FromBody] EmployeeDetailedViewModel insertion)
        {
            try
            {
                var isInserted = _employeeService.InsertEmployee(MapToInsertEmployeeDto(insertion));
                return Ok(isInserted);
                //return Ok(MapToEmployeeDto(insertEmployee));
                /*if (isInserted)
                {
                    return Ok(isInserted);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to insert employee details");
                }*/
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private EmployeeDto MapToInsertEmployeeDto(EmployeeDetailedViewModel employeeInsertion)
        {
            var employeeInsert = new EmployeeDto();
            {

                employeeInsert.Name = employeeInsertion.Name;
                employeeInsert.Department = employeeInsertion.Department;
                employeeInsert.Age = employeeInsertion.Age;
                employeeInsert.Address = employeeInsertion.Address;
            }
            return employeeInsert;
        }
        [HttpPut]
        [Route("update-employee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailedViewModel updation)
        {
            try
            {
                var isUpdated = _employeeService.UpdateEmployee(MapToUpdateDto(updation));
                if(isUpdated)
                {
                    return Ok(isUpdated);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,"Failed to update employee details");
                }
               
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private EmployeeDto MapToUpdateDto(EmployeeDetailedViewModel employeeUpdation)
        {
            var employeeUpdate = new EmployeeDto();
            {
                employeeUpdate.Id = employeeUpdation.Id;
                employeeUpdate.Name = employeeUpdation.Name;
                employeeUpdate.Department = employeeUpdation.Department;
                employeeUpdate.Age = employeeUpdation.Age;
                employeeUpdate.Address = employeeUpdation.Address;
            };
            return employeeUpdate;

        }
        [HttpDelete]
        [Route("deleteEmployee/{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            try
            {
                _employeeService.DeleteEmployee(employeeId);
                return Ok();
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
       

    }
}
