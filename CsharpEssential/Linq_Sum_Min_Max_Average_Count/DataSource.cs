﻿
namespace Linq_Sum_Min_Max_Average_Count
{
    public class DataSource
    {
        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee(){EmployeeID = 101, EmployeeName = "Henry", Job = "Designer" , Salary = 5000},
                new Employee(){EmployeeID = 102, EmployeeName = "Jack", Job = "Developer" , Salary = 4000},
                new Employee(){EmployeeID = 103, EmployeeName = "Gabriel", Job = "Analyst" , Salary = 4100},
                new Employee(){EmployeeID = 104, EmployeeName = "William", Job = "Manager" , Salary = 7000},
                new Employee(){EmployeeID = 105, EmployeeName = "Alexa", Job = "Manager" , Salary = 3500},
                new Employee(){EmployeeID = 106, EmployeeName = "Adam", Job = "Developer" , Salary = 5500},
                new Employee(){EmployeeID = 107, EmployeeName = "Jessica", Job = "Manager" , Salary = 1200},
            };
        }
    }
}
