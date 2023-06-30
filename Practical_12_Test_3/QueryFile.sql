CREATE database Practical_12_Test_3

use Practical_12_Test_3

create table Designation 
(
	Id int primary key identity,
	Designation varchar(50) not null,
)

create table employee 
(
	Id int primary key identity,
	FirstName varchar(50) not null,
	MiddleName varchar(50) ,
	LastName varchar(50) not null,
	DOB  date not null,
	Mobile varchar(10) not null,
	Address varchar(100),
	Salary decimal(18,2) not null,
	DesignationId int,
	constraint fk_designation foreign key (  DesignationId ) references Designation ( Id )
)

insert into Designation values ( 'Designation1'),('Designation2'),('Designation3')



insert into employee values ( 'Abhi','kantibhai','Dashadiya','2002-04-15','1234657891','morbi howsingh board',1238.21,1)
insert into employee values ( 'Jil','Niranjanbhai','Patel','2002-04-17','1234567891','Anand',1452.23,2);
insert into employee values ( 'Abhay','Hiteshbhai','Chotani','2001-04-14','1234567891','gondal',54454.52,3);
insert into employee values ( 'Parthiv','Vipulbhai','Hirani','2003-03-17','1234567891','rajkot',546423.55,1);
insert into employee values ( 'Jay','BhavinBhai','Gohel','1994-05-07','1234567891','Ahmedabad',654854.55,2);
insert into employee values ( 'Vipul','jaynarayan','Updahay','1998-07-16','1234567891','Bihar ',855756.23,3);


-- first
select Designation,COUNT(*) from Designation d join employee e on d.Id = e.DesignationId group by Designation


-- second

select FirstName,MiddleName,LastName,Designation from Designation d join employee e on d.Id = e.DesignationId 

-- third

create or alter view ShowData as ( select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId )

select * from ShowData

-- forth

create or alter proc InsertInDesignation ( @name varchar(50) ) as begin insert into Designation values ( @name) end

exec InsertInDesignation 'test1'

-- fifth

create proc InsertInEmployee ( @firstname varchar(50), @middlename varchar(50), @lastname varchar(50), @DOB date, @phone varchar(10), @address varchar(100), @salary decimal(18,2), @designationId int )
as begin insert into employee values ( @firstname,@middlename, @lastname, @DOB, @phone,@address,@salary,@designationId) end


-- sixth

with cte as ( select Designation,COUNT(*) as empCount from Designation d join employee e on d.Id = e.DesignationId group by Designation ) select * from cte where empCount > 1

-- seven


create or alter proc ListEmpSortByDOB as begin select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId order by DOB end


-- eight

create proc ListEmpSortByFirstName as begin select e.Id as empId, e.FirstName,e.MiddleName, e.LastName, d.Designation, e.DOB, e.Mobile, e.Address, e.Salary from Designation d join employee e on d.Id = e.DesignationId order by FirstName end

exec ListEmpSortByFirstName

-- nine

create nonclustered index index_designationID on employee ( DesignationId )

-- ten

select * from employee where Salary in ( select MAX(salary) from employee )
