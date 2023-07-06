create database hmit

use hmit

--drop table notice;
--drop table result;
--drop table registration;
--drop table departments;
--drop table courses;
--drop table students;
--drop table faculty_members;

create table faculty_members (
imageUrl varchar(300) not null,
teacher_name varchar(50) not null,
department varchar(50) not null,
phone varchar(20) not null,
t_address varchar(50),
designation varchar(30) not null,
salary int not null,
teacher_id char(4) primary key,
grade varchar(2) not null,
email varchar(50) not null,
pass varchar(32) not null);

create table students (
imageUrl varchar(300) not null,
student_name varchar(50) not null,
department varchar(50) not null,
phone char(11) not null,
father_name varchar(50) not null,
mother_name varchar(50) not null,
s_address varchar(50),
student_id char(7) primary key,
advisor_name varchar(50) not null,
email varchar(50) not null,
pass varchar(32) not null);

create table courses (
course_no char(4) primary key,
course_title varchar(50) not null,
credit float not null);

create table departments (
department_name varchar(50) not null,
department_id char(2) primary key,
running_year char(1) not null,
semester char(1) not null,
course_no char(4) not null,
course_title varchar(50) not null,
teacher_id char(4) not null,
teacher_name varchar(50) not null,
foreign key(course_no) references courses,
foreign key(teacher_id) references faculty_members);

create table registration (
student_id char(7) not null,
department_id char(2) not null,
running_year char(1) not null,
semester char(1) not null,
course_no char(4) not null,
course_title varchar(50) not null,
credit float not null,
primary key (student_id, course_no),
foreign key(student_id) references students);

create table result (
student_id char(7) primary key,
course_no char(4) not null,
course_title varchar(50) not null,
credit float not null,
grade_point float not null,
letter_grade varchar(2) not null,
foreign key(student_id, course_no) references registration);

create table notice (
for_whom varchar(50) not null,
date_time timestamp primary key,
sub varchar(300) not null,
imageUrl varchar(300) not null);