using EmployeeManagement.DataAccess.Contracts;
using EmployeeManagement.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess.Repository
{
    /// <summary>
    /// Connect To Database and Perforum CRUD operations
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private SqlConnection _sqlConnection;
        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection("data source = (localdb)\\mssqllocaldb; database = training2022;");
        }

        public EmployeeData GetEmployeeById(int id)
        {
            //Take data from Table By Id
            try
            {
                _sqlConnection.Open();
                var SqlCommand = new SqlCommand(cmdText: "select * from EMPLOYEE where ID=@id", _sqlConnection);
                SqlCommand.Parameters.AddWithValue("ID", id);
                var SqlDataReader = SqlCommand.ExecuteReader();

                var employee = new EmployeeData();

                while (SqlDataReader.Read())
                {

                    employee.Id = (int)SqlDataReader["ID"];
                    employee.Name = (string)SqlDataReader["NAME"];
                    employee.Department = (string)SqlDataReader["DEPARTMENT"];
                    employee.Age = (int)SqlDataReader["AGE"];
                    employee.Address = (string)SqlDataReader["ADDRESS"];
                }

                return employee;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }

            finally
            {
                _sqlConnection.Close();
            }

           
        }

        public IEnumerable<EmployeeData> GetEmployees()
        {
            try
            {
                _sqlConnection.Open();
                var sqlCommand = new SqlCommand(cmdText: "select * from EMPLOYEE", _sqlConnection);
                var SqlDataReader = sqlCommand.ExecuteReader();

                var listOfEmployees = new List<EmployeeData>();

                while (SqlDataReader.Read())
                {
                    listOfEmployees.Add(new EmployeeData()
                    {
                        Id = (int)SqlDataReader["ID"],
                        Name = (string)SqlDataReader["NAME"],
                        Department = (string)SqlDataReader["DEPARTMENT"],
                      
                       // Address = (string)SqlDataReader["ADDRESS"]*/

                    });

                }

                return listOfEmployees;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
            finally
            {
                _sqlConnection.Close();
            }

            //Create Methods For Table insert, update and Delete Here
        }
        public bool InsertEmployee(EmployeeData insertion)
        {
            try
            {
                _sqlConnection.Open();
                var SqlCommand = new SqlCommand(cmdText: "INSERT INTO EMPLOYEE(NAME,DEPARTMENT,AGE,ADDRESS)values(@name, @department,@age,@address)", _sqlConnection);
                SqlCommand.Parameters.AddWithValue("NAME", insertion.Name);
                SqlCommand.Parameters.AddWithValue("DEPARTMENT", insertion.Department);
                SqlCommand.Parameters.AddWithValue("AGE", insertion.Age);
                SqlCommand.Parameters.AddWithValue("ADDRESS", insertion.Address);

                SqlCommand.ExecuteNonQuery();
                return true;

            }
            catch
            {

                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public bool UpdateEmployee(EmployeeData updation)
        {
            try
            {
                _sqlConnection.Open();
                var SqlCommand = new SqlCommand(cmdText: "UPDATE EMPLOYEE SET NAME=@name,DEPARTMENT=@department,AGE=@age,ADDRESS=@address WHERE ID=@id", _sqlConnection);
                SqlCommand.Parameters.AddWithValue("id", updation.Id);
                SqlCommand.Parameters.AddWithValue("name", updation.Name);
                SqlCommand.Parameters.AddWithValue("department", updation.Department);
                SqlCommand.Parameters.AddWithValue("age", updation.Age);
                SqlCommand.Parameters.AddWithValue("address", updation.Address);

                SqlCommand.ExecuteNonQuery();
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public bool DeleteEmployee(int id)
        {
            try
            {
                _sqlConnection.Open();
                var SqlCommand = new SqlCommand(cmdText: "DELETE EMPLOYEE WHERE ID=@id", _sqlConnection);
                SqlCommand.Parameters.AddWithValue("ID", id);
                SqlCommand.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }

            finally
            {
                _sqlConnection.Close();
            }
        }

        /*bool IEmployeeRepository.InsertEmployee(EmployeeData insertion)
        {
            throw new NotImplementedException();
        }*/
    }
}
