CREATE database Practical_12_Test_2

use Practical_12_Test_2

create table employee 
(
	Id int primary key identity,
	FirstName varchar(50) not null,
	MiddleName varchar(50) ,
	LastName varchar(50) not null,
	DOB  date not null,
	Mobile varchar(10) not null,
	Address varchar(100),
	Salary decimal(18,2) not null
)



insert into employee values ( 'Abhi','kantibhai','Dashadiya','2002-04-15','1234657891','morbi howsingh board',1238.21)
insert into employee values ( 'Jil','Niranjanbhai','Patel','2002-04-17','1234567891','Anand',1452.23);
insert into employee values ( 'Abhay','Hiteshbhai','Chotani','2001-04-14','1234567891','gondal',54454.52);
insert into employee values ( 'Parthiv','Vipulbhai','Hirani','2003-03-17','1234567891','rajkot',546423.55);
insert into employee values ( 'Jay','BhavinBhai','Gohel','1994-05-07','1234567891','Ahmedabad',654854.55);
insert into employee values ( 'Vipul','jaynarayan','Updahay','1998-07-16','1234567891','Bihar ',855756.23);

insert into employee values ( 'Abhi',null,'Dashadiya','2002-04-15','1234657891','morbi howsingh board',1238.21)
insert into employee values ( 'Jil',null,'Patel','2002-04-17','1234567891','Anand',1452.23);
insert into employee values ( 'Abhay',null,'Chotani','2001-04-14','1234567891','gondal',54454.52);
insert into employee values ( 'Parthiv',null,'Hirani','2003-03-17','1234567891','rajkot',546423.55);
insert into employee values ( 'Jay',null,'Gohel','1994-05-07','1234567891','Ahmedabad',654854.55);
insert into employee values ( 'Vipul',null,'Updahay','1998-07-16','1234567891','Bihar ',855756.23);






