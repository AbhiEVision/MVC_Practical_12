using Practical_12_Test_1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Practical_12_Test_1.Data
{
	public class DatabaseConnection
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString; // "Data Source=SF-CPU-523;Initial Catalog=Practical_12;User Id =sa;Password=Abhi@15042002";

		public List<Employee> FetchDataFromDB()
		{
			List<Employee> employees = new List<Employee>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand selectQuert = new SqlCommand("select * from employee", connection);

				connection.Open();

				SqlDataReader reader = selectQuert.ExecuteReader();

				while (reader.Read())
				{
					Employee employee = new Employee();
					employee.Id = Convert.ToInt32(reader["Id"]);
					employee.FirstName = reader["FirstName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.DOB = Convert.ToDateTime(reader["DOB"]);
					employee.MobileNo = reader["Mobile"].ToString();
					employee.Address = reader["Address"].ToString();
					employee.Salary = Convert.ToDouble(reader["Salary"]);
					employees.Add(employee);
				}

			}

			return employees;

		}

		public double FindTotalSalaries()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("select sum(Salary) from employee", connection);

				connection.Open();

				double salary = Convert.ToDouble(command.ExecuteScalar());

				return salary;
			}
		}

		public List<Employee> FetchDataWhoHaveNeededRequriement()
		{
			List<Employee> employees = new List<Employee>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand selectQuert = new SqlCommand("select * from employee where DOB < '2000-01-01'", connection);

				connection.Open();

				SqlDataReader reader = selectQuert.ExecuteReader();

				while (reader.Read())
				{
					Employee employee = new Employee();
					employee.Id = Convert.ToInt32(reader["Id"]);
					employee.FirstName = reader["FirstName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.DOB = Convert.ToDateTime(reader["DOB"]);
					employee.MobileNo = reader["Mobile"].ToString();
					employee.Address = reader["Address"].ToString();
					employee.Salary = Convert.ToDouble(reader["Salary"]);
					employees.Add(employee);
				}

			}

			return employees;

		}

		public int TotalNull()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("select COUNT(*) from employee where MiddleName is null", connection);

				connection.Open();

				int salary = Convert.ToInt32(command.ExecuteScalar());

				return salary;
			}
		}
	}
}