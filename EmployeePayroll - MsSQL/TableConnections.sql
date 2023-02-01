Create Table Company(
CompanyId int Identity(1,1) Primary Key,
CompanyName Varchar(50)
);

Create Table Department(
DepartmentId int Identity(1,1) Primary Key,
DepartmentName Varchar(50),
);

Create Table Employee(
EmployeeId int Identity(1,1) Primary Key,
CompanyId int Foreign Key references Company(CompanyId),
EmployeeName Varchar(50),
PhoneNumber bigint,
EmployeeAddress Varchar(50),
StartDate date,
Gender char(1)
);

Create Table Payroll(
EmployeeId int Foreign Key references Employee(EmployeeId),
BasicPay float,
TaxablePay float,
IncomeTax float,
NetPay float,
Deductions float
);

Create table EmpDepartment(
EmployeeId int foreign key references Employee(EmployeeId),
DepartmentId int foreign key references Department(DepartmentId)
);