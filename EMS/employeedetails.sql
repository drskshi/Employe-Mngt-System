
Create Table UserTable
(
UserID int identity (1,1) primary key,
UserName varchar (100) not null unique,
password varchar (100) not null
)

Create Table employeeTable
(
employeeId int identity(1,1) primary key,
employeeName varchar(100) not null,
address varchar(200),
contact varchar (20),
gender varchar(20),
email varchar (200) not null unique,
dateofbirth date not null,
department varchar (100) not null,
designation varchar (100) not null
)