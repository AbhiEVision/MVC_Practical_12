using Practical_12_Test_3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Practical_12_Test_3.Data
{
	public class DatabaseClass
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

		public void InsertRecordsInTables()
		{
			string query = "insert into Designation values ( 'Designation1'),('Designation2'),('Designation3');" +
				"insert into employee values ( 'Abhi','kantibhai','Dashadiya','2002-04-15','1234657891','morbi howsingh board',1238.21,1);" +
				"insert into employee values ( 'Jil','Niranjanbhai','Patel','2002-04-17','1234567891','Anand',1452.23,2);" +
				"insert into employee values ( 'Abhay','Hiteshbhai','Chotani','2001-04-14','1234567891','gondal',54454.52,3);" +
				"insert into employee values ( 'Parthiv','Vipulbhai','Hirani','2003-03-17','1234567891','rajkot',546423.55,1);" +
				"insert into employee values ( 'Jay','BhavinBhai','Gohel','1994-05-07','1234567891','Ahmedabad',654854.55,2);" +
				"insert into employee values ( 'Vipul','jaynarayan','Updahay','1998-07-16','1234567891','Bihar ',855756.23,3);";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				cmd.ExecuteNonQuery();

			}
		}

		public void Truncate()
		{
			string query = "truncate table employee";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				cmd.ExecuteNonQuery();

			}

		}

		public List<Employee> FetchTheEmployees()
		{
			string query = "select * from employee";

			List<Employee> employees = new List<Employee>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Employee employee = new Employee();

					employee.FirstName = reader["FirstName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.Address = reader["Address"].ToString();
					employee.DOB = Convert.ToDateTime(reader["DOB"]);
					employee.DesignationId = Convert.ToInt32(reader["DesignationId"]);
					employee.MobileNo = reader["Mobile"].ToString();
					employee.Salary = Convert.ToDouble(reader["Salary"]);

					employees.Add(employee);
				}

			}

			return employees;


		}

		public List<DesignationCounts> CountByDesignations()
		{

			string query = "select Designation,COUNT(*) as count from Designation d join employee e on d.Id = e.DesignationId group by Designation";

			List<DesignationCounts> designations = new List<DesignationCounts>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					DesignationCounts count = new DesignationCounts();

					count.Designation = reader["Designation"].ToString();
					count.Count = Convert.ToInt32(reader["count"]);
					designations.Add(count);
				}


			}

			return designations;
		}

		public List<EmployeeJoin> QueryNumber3()
		{
			string query = "select FirstName,MiddleName,LastName,Designation from Designation d join employee e on d.Id = e.DesignationId ";

			List<EmployeeJoin> employees = new List<EmployeeJoin>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					EmployeeJoin employee = new EmployeeJoin();
					employee.FirstName = reader["FirstName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.DesignationName = reader["Designation"].ToString();

					employees.Add(employee);

				}

			}

			return employees;
		}

		public List<EmployeeJoin> CreateView()
		{
			string query = "create or alter view ShowData as ( select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId )";

			List<EmployeeJoin> employees = new List<EmployeeJoin>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				cmd.ExecuteNonQuery();

				cmd.CommandText = "select * from ShowData";

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					EmployeeJoin employee = new EmployeeJoin();
					employee.Id = Convert.ToInt32(reader["empId"]);
					employee.FirstName = reader["FirstName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.DesignationName = reader["Designation"].ToString();
					employee.DOB = Convert.ToDateTime(reader["DOB"]);
					employee.MobileNo = reader["Mobile"].ToString();
					employee.Address = reader["Address"].ToString();
					employee.Salary = Convert.ToDouble(reader["Salary"]);
					employees.Add(employee);
				}
			}

			return employees;
		}

		public void CreateProcToStoreInDesignation()
		{
			string query = "create or alter proc InsertInDesignation ( @name varchar(50) ) as begin insert into Designation values ( @name) end";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				cmd.ExecuteNonQuery();

				cmd.CommandText = "InsertInDesignation";

				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				SqlParameter sqlParameter = new SqlParameter("@name", "Test1");

				cmd.Parameters.Add(sqlParameter);

				cmd.ExecuteNonQuery();
			}
		}

		public void CreateProcToStoreInEmployee()
		{
			string query = "create or alter proc InsertInEmployee ( @firstname varchar(50), @middlename varchar(50), @lastname varchar(50), @DOB date, @phone varchar(10), @address varchar(100), @salary decimal(18,2), @designationId int )" +
				"as begin insert into employee values ( @firstname,@middlename, @lastname, @DOB, @phone,@address,@salary,@designationId) end";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();


				cmd.ExecuteNonQuery();

				cmd.CommandText = "InsertInEmployee";

				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				cmd.Parameters.Add("@firstname", "Divyesh");
				cmd.Parameters.Add("@middlename", "Kumar");
				cmd.Parameters.Add("@lastname", "Dashadiya");
				cmd.Parameters.Add("@DOB", "1998-07-16");
				cmd.Parameters.Add("@phone", "9913418671");
				cmd.Parameters.Add("@address", "Test1");
				cmd.Parameters.Add("@salary", 123456.12);
				cmd.Parameters.Add("@designationId", 1);

				cmd.ExecuteNonQuery();
			}
		}

		public List<DesignationCounts> FetchDesignationWhoHaveMoreThanOnEmployee()
		{
			string query = "with cte as ( select Designation,COUNT(*) as empCount from Designation d join employee e on d.Id = e.DesignationId group by Designation ) select * from cte where empCount > 1";

			List<DesignationCounts> counts = new List<DesignationCounts>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					DesignationCounts count = new DesignationCounts();

					count.Count = Convert.ToInt32(reader["empCount"]);
					count.Designation = reader["Designation"].ToString();

					counts.Add(count);
				}

			}

			return counts;
		}


		public List<EmployeeJoin> CreateProcWhichReturnListOrderByDOB()
		{
			string query = "create or alter proc ListEmpSortByDOB as begin select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId order by DOB end";

			List<EmployeeJoin> employees = new List<EmployeeJoin>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				cmd.ExecuteNonQuery();

				cmd.CommandText = "ListEmpSortByDOB";

				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					EmployeeJoin employee = new EmployeeJoin();
					employee.Id = Convert.ToInt32(reader["empId"]);
					employee.FirstName = reader["FirstName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.DesignationName = reader["Designation"].ToString();
					employee.DOB = Convert.ToDateTime(reader["DOB"]);
					employee.MobileNo = reader["Mobile"].ToString();
					employee.Address = reader["Address"].ToString();
					employee.Salary = Convert.ToDouble(reader["Salary"]);
					employees.Add(employee);
				}
			}

			return employees;
		}

		public List<EmployeeJoin> CreateProcWhichReturnListOrderByFirstName()
		{
			string query = "create or alter proc ListEmpSortByFirstName as begin select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId order by FirstName end";

			List<EmployeeJoin> employees = new List<EmployeeJoin>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				cmd.ExecuteNonQuery();

				cmd.CommandText = "ListEmpSortByFirstName";
				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					EmployeeJoin employee = new EmployeeJoin();
					employee.Id = Convert.ToInt32(reader["empId"]);
					employee.FirstName = reader["FirstName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.DesignationName = reader["Designation"].ToString();
					employee.DOB = Convert.ToDateTime(reader["DOB"]);
					employee.MobileNo = reader["Mobile"].ToString();
					employee.Address = reader["Address"].ToString();
					employee.Salary = Convert.ToDouble(reader["Salary"]);
					employees.Add(employee);
				}

			}

			return employees;
		}

		public void CreateNonClusteredIndex()
		{
			string query = "create or alter nonclustered index index_designationID on employee ( DesignationId )";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				cmd.ExecuteNonQuery();
			}
		}

		public List<Employee> FindEmployeeWhichHaveMaxSalary()
		{
			string query = "select * from employee where Salary in ( select MAX(salary) from employee )";

			List<Employee> employees = new List<Employee>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Employee employee = new Employee();

					employee.FirstName = reader["FirstName"].ToString();
					employee.MiddleName = reader["MiddleName"].ToString();
					employee.LastName = reader["LastName"].ToString();
					employee.Address = reader["Address"].ToString();
					employee.DOB = Convert.ToDateTime(reader["DOB"]);
					employee.DesignationId = Convert.ToInt32(reader["DesignationId"]);
					employee.MobileNo = reader["Mobile"].ToString();
					employee.Salary = Convert.ToDouble(reader["Salary"]);

					employees.Add(employee);
				}

			}

			return employees;
		}

	}
}