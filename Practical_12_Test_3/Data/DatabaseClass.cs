using System.Configuration;
using System.Data.SqlClient;

namespace Practical_12_Test_3.Data
{
	public class DatabaseClass
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

		public void InsertRecordsInTables()
		{
			string query = "";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}


		public void CountByDesignations()
		{

			string query = "select Designation,COUNT(*) as count from Designation d join employee e on d.Id = e.DesignationId group by Designation";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void QueryNumber3()
		{
			string query = "select FirstName,MiddleName,LastName,Designation from Designation d join employee e on d.Id = e.DesignationId ";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void CreateView()
		{
			string query = "create view ShowData as ( select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId )";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void CreateProcToStoreInDesignation()
		{
			string query = "create proc InsertInDesignation ( @name varchar(50) ) as begin insert into Designation values ( @name) end";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void CreateProcToStoreInEmployee()
		{
			string query = "create proc InsertInEmployee ( @firstname varchar(50), @middlename varchar(50), @lastname varchar(50), @DOB date, @phone varchar(10), @address varchar(100), @salary decimal(18,2), @designationId int )" +
				"as begin insert into employee values ( @firstname,@middlename, @lastname, @DOB, @phone,@address,@salary,@designationId) end";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void FetchDesignationWhoHaveMoreThanOnEmployee()
		{
			string query = "with cte as ( select Designation,COUNT(*) as empCount from Designation d join employee e on d.Id = e.DesignationId group by Designation ) select * from cte where empCount > 1";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}


		public void CreateProcWhichReturnListOrderByDOB()
		{
			string query = "create or alter proc ListEmpSortByDOB as begin select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId order by DOB end";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void CreateProcWhichReturnListOrderByFirstName()
		{
			string query = "create or alter proc ListEmpSortByFirstName as begin select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId order by FirstName end";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void CreateNonClusteredIndex()
		{
			string query = "create or alter nonclustered index index_designationID on employee ( DesignationId )";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

		public void FindEmployeeWhichHaveMaxSalary()
		{
			string query = "select * from employee where Salary in ( select MAX(salary) from employee )";

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				connection.Open();
			}
		}

	}
}