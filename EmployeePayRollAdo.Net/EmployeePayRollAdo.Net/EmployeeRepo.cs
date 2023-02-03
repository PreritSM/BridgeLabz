using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayRollAdo.Net;

namespace EmployeeData.net
{
    class EmployeeRepository
    {
        public static string ConnectionString = @"Data Source = G72KD7T3E; Initial Catalog=Payroll_Service; Integrated Security=True;";
        public static SqlConnection sqlConnection;
        public static EmployeeModel model = new EmployeeModel(); public static void GetAllEmployees()
        {
            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllEmployeeData", sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.Id = Convert.ToInt32(reader["EmployeeId"]);
                        model.Name = reader["EmployeeName"].ToString();
                        model.Gender = Convert.ToChar(reader["Gender"]);
                        model.PhoneNumber = Convert.ToInt64(reader["PhoneNumber"]);
                        model.Salary = Convert.ToDouble(reader["Salary"]);
                    }
                }
                sqlConnection.Close();
            }
        }
    }
}