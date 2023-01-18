Create Database EmployeeIS
use EmployeeIS
create table Employee(
Employee_id bigint not null identity,
Emp_Name nvarchar(100) not null,
DOB date not null,
Gender char(1) not null,
Salary decimal not null,
Entry_by nvarchar(100) not null,
Entry_date datetime not null,
Primary Key(Employee_id)
);
create table QualificationList(
Q_id bigint not null identity,
Q_Name nvarchar(15) not null,
Primary Key(Q_id)
);

create table EMP_QUALIFICATION(
Employee_id bigint not null,
Q_id  bigint not null,
Marks decimal(5,2) not null,
CONSTRAINT Emp_Emp_Q_FK Foreign Key (Employee_id) references Employee(Employee_id) ,
CONSTRAINT Quali_Emp_Q_FK Foreign Key (Q_id) references QualificationList(Q_id),
Primary Key(Employee_id,Q_id)
);

Insert into QualificationList
values('SLC'),('Intermediate'),('BE'),('ME'),('PHD')