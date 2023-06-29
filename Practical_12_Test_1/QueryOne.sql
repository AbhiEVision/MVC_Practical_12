create database Practical_12

use Practical_12

create table employee 
(
	Id int primary key identity,
	FirstName varchar(50) not null,
	MiddleName varchar(50) ,
	LastName varchar(50) not null,
	DOB  date not null,
	Mobile varchar(10) not null,
	Address varchar(100)
)

insert into employee values ( 'Abhi',null,'Dashadiya','2002-04-15','1234657891','morbi howsingh board');
insert into employee values ( 'Jil',null,'Patel','2002-04-17','1234567891','Anand');
insert into employee values ( 'Abhay',null,'Chotani','2001-04-14','1234567891','gondal');
insert into employee values ( 'Parthiv',null,'Hirani','2003-03-17','1234567891','rajkot');
insert into employee values ( 'Vipul',null,'Updahay','1998-07-16','1234567891','Bihar ');
insert into employee values ( 'Jay',null,'Gohel','1994-05-07','1234567891','Ahmedabad');
insert into employee values ( 'Jay',null,'Gohel','1994-05-07','1234567891','Ahmedabad');

select * from employee