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
					employees.Add(employee);
				}

			}

			return employees;

		}

		public int AddDataInDataBase(Employee employee)
		{
			string query = $"insert into employee values " +
				$"( '{employee.FirstName}'," +
				$"'{employee.MiddleName}'," +
				$"'{employee.LastName}'," +
				$"'{employee.DOB.Year}-{employee.DOB.Month}-{employee.DOB.Day}'," +
				$"'{employee.MobileNo}'," +
				$"'{employee.Address}')";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				connection.Open();

				int result = command.ExecuteNonQuery();

				return result;
			}

		}

		public void UpdateFirstNameToSQLPerson()
		{
			string query = "update employee set FirstName = 'SQLPerson' where Id = (select top 1 Id from employee)";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				connection.Open();

				command.ExecuteNonQuery();

			}
		}

		public void UpdateMiddleNameToI()
		{
			string query = "update employee set MiddleName = 'I'";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				connection.Open();

				command.ExecuteNonQuery();


			}
		}

		public void DeleteDataWhichHaveLessThanTwoId()
		{
			string query = "delete employee where Id < 2";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				connection.Open();

				command.ExecuteNonQuery();


			}

		}

		public void TruncateTable()
		{
			string query = "truncate table employee";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				connection.Open();

				command.ExecuteNonQuery();


			}

		}

		public void AddDummyData()
		{
			string query = " insert into employee values ( 'Abhi','kantibhai','Dashadiya','2002-04-15','1234657891','morbi howsingh board');" +
				"insert into employee values ( 'Jil','Niranjanbhai','Patel','2002-04-17','1234567891','Anand');" +
				"insert into employee values ( 'Abhay','Hiteshbhai','Chotani','2001-04-14','1234567891','gondal');" +
				"insert into employee values ( 'Parthiv','Vipulbhai','Hirani','2003-03-17','1234567891','rajkot');" +
				"insert into employee values ( 'Vipul','jaynarayan','Updahay','1998-07-16','1234567891','Bihar ');" +
				"insert into employee values ( 'Jay','BhavinBhai','Gohel','1994-05-07','1234567891','Ahmedabad');";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				connection.Open();

				command.ExecuteNonQuery();


			}
		}

	}
}