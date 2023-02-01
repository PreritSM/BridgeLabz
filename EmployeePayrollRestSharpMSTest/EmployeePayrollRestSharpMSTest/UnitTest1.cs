using System.Linq.Expressions;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace EmployeePayrollRestSharpMSTest
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]

        public void setup()
        {
            try
            { client = new RestClient("http://localhost:4000"); }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public RestResponse GetAllEmployeeList()
        {
            RestResponse response;

            RestRequest request = new RestRequest("/Employees", Method.Get);
            response = client.ExecuteAsync(request).Result;
            return response;
        }
        [TestMethod]
        public void CallingGetAPIToReturnEmployees()
        {
            RestResponse response = GetAllEmployeeList();

            var jsonObj = JsonConvert.DeserializeObject<List<EmployeeModel>>(response.Content);

            //Assert.AreEqual(4, jsonObj.Count);
            foreach (var employee in jsonObj)
            {
                Console.WriteLine($"ID : {employee.Id} , Name : {employee.Name}, Salary : {employee.Salary}");
            }
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        public RestResponse AddToJson(EmployeeModel model)
        {
            RestResponse response;
            RestRequest request = new RestRequest("/Employees", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { Name = model.Name, Salary = model.Salary });
            response = client.ExecuteAsync(request).Result;
            return response;
        }

        [TestMethod]
        public void CallingPostAPIAddEmployee()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.Name = "Swapna";
            employee.Salary = "82000";

            RestResponse response = AddToJson(employee);
            var resEmp = JsonConvert.DeserializeObject<EmployeeModel>(response.Content);
            Console.WriteLine($"Id : {employee.Id} , Name : {employee.Name}, Salary : {employee.Salary}");
            Assert.AreEqual("Swapna", employee.Name);
            Assert.AreEqual("82000", employee.Salary);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            }

        [TestMethod]

        public void TestMethodForUpdateEmployee()
        {
            RestRequest request = new RestRequest("/Employees/", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { Name = "Utkarsh", Salary = "85000" });
            RestResponse response = client.ExecuteAsync(request).Result;

            var employee = JsonConvert.DeserializeObject<EmployeeModel>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Console.WriteLine($"Id : {employee.Id} , Name : {employee.Name}, Salary : {employee.Salary}");
        }

        [TestMethod]
        public void TestMethodForDeleteEmployee()
        {
            RestRequest request = new RestRequest("/Employees/6", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            RestResponse response = client.ExecuteAsync(request).Result;
            RestResponse response1 = GetAllEmployeeList();
            var jsonObj = JsonConvert.DeserializeObject<List<EmployeeModel>>(response.Content);

            foreach (var employee in jsonObj)
            {
                Console.WriteLine($"Id : {employee.Id} , Name : {employee.Name}, Salary : {employee.Salary}");
            }

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}