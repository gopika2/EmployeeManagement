using EmployeeManagement.UI.Models;
using EmployeeManagement.UI.Models.Provider;
using EmployeeManagement.UI.Providers.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployeeManagement.UI.Providers.ApiClients
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _httpClient;

        public EmployeeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<EmployeeViewModel>GetAllEmployee()
        {
            //Consume /employee endpoint in the EmployeeManagementApi using _httpClient
            using (var response = _httpClient.GetAsync("https://localhost:5001/api/employee/get-all").Result)
            {
                var employee = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(response.Content.ReadAsStringAsync().Result);

                return employee;
            }

        }
        public EmployeeDetailedViewModel GetEmployeeById(int employeeId)
        {
            using (var response = _httpClient.GetAsync("https://localhost:5001/api/employee/" + employeeId).Result)
            {
                var employee = JsonConvert.DeserializeObject<EmployeeDetailedViewModel>(response.Content.ReadAsStringAsync().Result);

                return employee;
            }
        }

        public bool DeleteEmployeeById(int employeeId)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(employeeId));

            using (var response = _httpClient.DeleteAsync("https://localhost:5001/api/employee/deleteEmployee/" + employeeId).Result)
            {
                return true;
            }
        }

        public bool InsertEmployee(EmployeeViewModel employee)
        {
            var json = JsonConvert.SerializeObject(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
           
            using (var response = _httpClient.PostAsync("https://localhost:5001/api/employee/insert-employee", data).Result)
            {
                if(response.StatusCode.ToString()=="OK")
                { 
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
        }
        public bool UpdateEmployee(EmployeeViewModel employee)
        {
            var json = JsonConvert.SerializeObject(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = _httpClient.PutAsync("https://localhost:5001/api/employee/update-employee", data).Result)
            {
                if (response.StatusCode.ToString() == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }

       /* public bool UpdateEmployee(EmployeeViewModel employee)
        {
            throw new System.NotImplementedException();
        }*/
    }

}
