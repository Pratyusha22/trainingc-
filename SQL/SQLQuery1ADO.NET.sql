create database StudentInfo
use StudentInfo

create table Course
(
id int primary key ,
name varchar(20),
duration int
)

select * from Course
insert into Course values(10,'C',6),(2,'C#',7),(3,'C++',6),(4,'Java',8)

create proc sp_AddCourse
@id int,
@name varchar(20),
@duration int
as
insert into course values(@id,@name,@duration)


create proc sp_Update
@id int
as
begin
update Course
Set id = @id,
 name = 'Python',
 duration=5
 where id = 4
end

create proc sp_Delete
@id int
as
begin
delete from Course
 where id = 4
end