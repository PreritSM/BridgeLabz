--create database Payroll_Service;
--use Payroll_Service;

create table Employee_Payroll(
Id int identity (1,1) primary key,
Name varchar(50) not null,
Salary float,
StartDate date
)