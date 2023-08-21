create database hmit

use hmit

--drop table tblImages
Create table tblImages(
Id int primary key identity,
Name nvarchar(255),
Size int,
ImageData varbinary(max))
Go

Create procedure spUploadImage
@Name nvarchar(255),
@Size int,
@ImageData varbinary(max),
@NewId int output
as
Begin
    Insert into tblImages
    values (@Name, @Size, @ImageData)

    Select @NewId = SCOPE_IDENTITY()
End
Go

Create procedure spGetImageById
@Id int
as
Begin
    Select ImageData
    from tblImages where Id=@Id
End
Go
--select * from tblImages;

--drop table grades;
create table grades(
grade varchar(50),
designation varchar(50),
starting_salary varchar(50),
maximum_salary varchar(50));
--select * from grades;

--drop table faculty_members;
create table faculty_members (
teacher_name varchar(50),
department varchar(50),
phone varchar(50),
t_address varchar(50),
designation varchar(50),
join_date date,
salary varchar(50),
teacher_id varchar(50),
grade varchar(50),
email varchar(50),
pass varchar(50),
imageId varchar(50));
--select * from faculty_members;

--drop table students;
create table students (
student_name varchar(50),
department varchar(50),
phone varchar(50),
father_name varchar(50),
mother_name varchar(50),
s_address varchar(50),
batch varchar(50),
student_id varchar(50),
email varchar(50),
pass varchar(50),
imageId varchar(50));
--select * from students;

--drop table courses;
create table courses (
department_id varchar(50),
running_year varchar(50),
semester varchar(50),
course_no varchar(50),
course_title varchar(50),
credit varchar(50),
teacher_id varchar(50),
teacher_name varchar(50));
--select * from courses;

--drop table registration;
create table registration (
student_id varchar(50),
department_id varchar(50),
running_year varchar(50),
semester varchar(50),
course_no varchar(50),
course_title varchar(50),
credit varchar(50),
r_status varchar(50));
select * from registration;

--drop table result;
create table result (
student_id varchar(50),
department_id varchar(50),
running_year varchar(50),
semester varchar(50),
course_no varchar(50),
course_title varchar(50),
credit varchar(50),
marks varchar(50),
grade_point varchar(50),
letter_grade varchar(50),
attempt varchar(50));
--select * from result;

-- drop table notice;
create table notice (
date_time varchar(30),
from_whom varchar(50),
to_whom varchar(50),
sub varchar(300),
msg varchar(3000));
-- select * from notice;