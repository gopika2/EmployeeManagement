﻿using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Providers.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers.InternalAPI
{
    [Route("api/internal/employee")]
    [ApiController]
    public class EmployeeInternalApiController : ControllerBase
    {
        private readonly IEmployeeApiClient _employeeApiClient;

        public EmployeeInternalApiController(IEmployeeApiClient employeeApiClient)
        {
            _employeeApiClient = employeeApiClient;
        }

        [HttpGet]
        [Route("{employeeId}")]
        public IActionResult GetEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                var employee = _employeeApiClient.GetEmployeeById(employeeId);

                return Ok(employee);
            }
            catch (Exception )
            {

                throw;
            }

        }

        [HttpDelete]
        [Route("deleteemployees/{employeeId}")]
        public IActionResult DeleteEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                var employee = _employeeApiClient.DeleteEmployeeById(employeeId);
                return Ok(employee);
            }
            catch (Exception )
            {

                throw;
            }
        }
       /* [HttpDelete]
        [Route("insertEmployees")]
        public IActionResult DeEmployeeById([FromRoute] int employeeId)
        {
            try
            {
                var employee = _employeeApiClient.DeleteEmployeeById(employeeId);
                return Ok(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}
