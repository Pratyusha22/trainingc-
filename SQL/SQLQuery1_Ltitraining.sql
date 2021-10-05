create database DbOrganization
--create department table
--primary key id cant be null
create table tblDepartment(Did int identity(100,1) primary key,Dname nvarchar(20),Yearofestablishment date)

sp_help tblDepartment
select * from tblDepartment
insert into tblDepartment(Dname,Yearofestablishment) values ('HR','2012-01-02'),('Finance','2012-02-02'),('UI','2013-10-02'),('Development','2013-10-02')
--drop table tblEmployee
create table tblEmployee(Eid int primary key,Ename nvarchar(30) unique not null,age int check(age>18),salary int,gender varchar(20))
insert into tblEmployee(Eid,Ename,age,salary,gender) values (11,'Sri',30,55000,'male'),(12,'Anu',28,30000,'female'),(13,'Banu',27,28000,'female'),(14,'Rai',28,50000,'male'),(15,'gayathri',27,27000,'female')
--error primary key
insert into tblEmployee(Eid,Ename,age,salary,gender) values (11,'Jamuna',30,55000,'female')
--default
insert into tblEmployee(Eid,Ename,age,salary,gender) values (16,'Jamuna',30,55000,'female')
select * from tblEmployee
--check constraint violation error
insert into tblEmployee(Eid,Ename,age,salary,gender) values (17,'Sasi',17,'male')
insert into tblEmployee(Eid,Ename,age,salary,gender) values (17,'Sasi',19,'male')
-- create a table with primary key with user defined constraint name
create table Test (Tid int, Tname varchar(20),constraint pk_test primary key(Tid))
insert into Test (Tid ,Tname) values (1,'Java'),(2,'c#')
sp_help Test

--drop constraint
alter table test drop constraint pk_test
--add constraint
alter table test add constraint pk_t primary key(Tid)


--adding foreign key
--should a primary key of another table
alter table tblEmployee add DeptId int references tblDepartment(Did)
select * from tblEmployee
--foreign key violation
select * from tblDepartment

insert into tblEmployee(Eid,Ename,age,salary,DeptId) values (18,'Varun',28,30000,102)

update tblEmployee set DeptId =101 where  Eid in (11,13,15)
update tblEmployee set DeptId =102 where  Eid in (12,14,16)
update tblEmployee set DeptId =103 where  Eid = 13

--group by
--select selectlist from tablename group by column1,...columnN order by column1,...columnN
--display deptname and max salary from each dept

select d.Dname , MAX(e.salary) 'Maximum salary'
from tblDepartment d, tblEmployee e
where d.Did = e.DeptId
group by Dname
order by 'Maximum salary' desc

--display the no of males and females in organization
select distinct(gender),count(gender) 'no of gender'
from tblEmployee
group by gender

--display the no of employees getting same salary

--adding mgrid in tblemp
alter table tblemployee add mgrid int references tblemployee(Eid)
select * from tblEmployee

select distinct(salary), count(salary) 'no of employees'
from tblEmployee
group by salary

--update tblemp with mgrid
update tblEmployee set mgrid =11 where  Eid in (11,13,15)
update tblEmployee set mgrid =12 where  Eid in (12,14,16)
update tblEmployee set mgrid =13 where  Eid = 13

select * from tblEmployee

--having
--error
select * from tblEmployee where salary>MIN(salary)

--select selectlist from table where condition group by columns having condition order by column

--display deptname min salary of dept having>=10000
select d.Dname , MIN(e.salary) 'Minimum salary'
from tblDepartment d, tblEmployee e
where d.Did = e.DeptId
group by Dname
having MIN(e.salary)>=10000
order by 'Minimum salary' desc

--display the mgrid who has more than  or =2 employees
select mgrid ,count(Eid) 'no of employees'
from tblEmployee
group by mgrid
having count(Eid)>=2

--rename for table
--sp_rename 'oldtablename','newtablename'
sp_rename 'dbo.Test' ,'dbo.Sample'

sp_rename '[dbo].[dbo.Sample]','Testdata'

select * from Testdata

--rename column
sp_rename '[dbo].[Testdata].Tname','Testname','column'


--joins
--helps us to combine two or more table
--inner join
--outer join 1.Left outer join 2.Right outer join
select * from tblEmployee
select * from tblDepartment

insert into tblEmployee(Eid,Ename,age,salary,gender) values (19,'Rekha',29,35700,'female'),(20,'Guna',27,25700,'male')

--select selectlist from tbl1 join tbl2 on condition 
--inner join

select e.Ename,e.salary,d.Dname,d.Yearsofestablishment
from tblEmployee e
inner join tblDepartment d
on e.DeptId=d.Did

--left join or left outer join
select e.Ename,e.salary,d.Dname,d.Yearsofestablishment
from tblEmployee e
left join tblDepartment d
on e.DeptId=d.Did

--right join or right outer join
select e.Ename,e.salary,d.Dname,d.Yearsofestablishment
from tblEmployee e
right join tblDepartment d
on e.DeptId=d.Did

--full outer join
select e.Ename,e.salary,d.Dname,d.Yearsofestablishment
from tblEmployee e
full outer join tblDepartment d
on e.DeptId=d.Did


--self join
--display the managername and no of employees under each manager

select m.Ename 'Manager name' , COUNT(e.Eid)
from tblEmployee e 
left join tblEmployee m
on e.mgrid = m.Eid
where m.Ename is not null
group by (m.Ename)

--display the employee name and their manager name
--cross joins
select e.Ename , d.Dname
from tblEmployee e cross join tblDepartment d

select m.Ename,e.Ename 'Mname'
from tblEmployee e left join tblEmployee m
on e.Eid = m.mgrid
where m.Ename is not null



--view
--virtual table
--abstraction
/* create view view_name as
select column from table*/

create view v_Empdetails as
select e.Ename,e.age,e.gender from tblEmployee e

select * from v_Empdetails

select gender, count(gender)
from v_Empdetails group by gender

--group by works in view
create view v_Empdetails gender as
select gender, count(gender) as 'count'
from v_Empdetails group by gender

select * from v_Empdetails_gender

--alter view
alter view v_Empdetails_gender as 
select gender, count(gender)
from v_Empdetails group by gender
having count(gender)>2

--order by will not work in view
alter view v_Empdetails_gender as 
select gender, count(gender)
from v_Empdetails group by gender
having count(gender)>2
order by gender desc

--view with condition
create view v_emp as
select * from tblEmployee
where age >23

select * from v_emp
select * from tblEmployee

--insert record in view
insert into v_emp(Eid,Ename,age,salary,gender) values (21,'Ram',20,23000,'male')

--with check option
alter view v_emp as
select * from tblEmployee
where age>23 with check option


--error
insert into v_emp(Eid,Ename,age,salary,gender) values (22,'AAA',20,23000,'male')
--accepts in both table
insert into v_emp(Eid,Ename,age,salary,gender) values (22,'AAA',24,23000,'male')

create view v_join as
select e.Ename,e.salary,d.Dname,d.Yearofestablishment
from tblEmployee e
left join tblDepartment d
on e.DeptId =d.Did

select * from v_join

--view or function 'v_sample' is not updatable because the modification affects multiple base tables.

create view v_sample
as select e.Ename,d.Dname
from tblEmployee e, tblDepartment d

insert into v_emp(Ename,Dname) values ('ppp','XYZ')

--drop
drop view v_sample

--subqueries
--single row subquery =,>,<,>=,<=!=
--display the ename and salary whose salary is equal to the salary of eid=17

select * from tblDepartment
select * from tblEmployee

select * from tblEmployee where salary =
(select salary from tblEmployee where Eid=17) and Eid != 17

update tblEmployee set DeptId =103 where Eid = 19

--delete the emp whose deptname = development
delete from tblEmployee where DeptId = (select Did from tblDepartment where Dname = 'development')


--display employee deatils whose salary in >  thanavg salary of dept 102
select * from tblEmployee where salary =
(select avg(salary) from tblEmployee where DeptId =102)

--multiple row subquery All,Any,In
--display the emp details whose salary is equal to one of the salary of emp in dept 101
select * from tblEmployee where salary  in
(select salary from tblEmployee where DeptId =101) and DeptId != 101

select * from tblEmployee where salary > all
(select salary from tblEmployee where DeptId =101)

select * from tblEmployee where salary > any
(select salary from tblEmployee where DeptId =101)



--DAY 3

--T SQL
--ex 1

declare @a int =10
declare @b int =20,@result int
set @result=@a+@b
print @result

--ex 2
declare @num1 int = 90 ,@num2 int = 30
Begin
if(@num1>@num2)
print 'num1 is greater'
else
print 'num 2 is greater'
End

--ex 3
declare @n1 int =20, @n2 int =30
Begin
while(@n1>@n2)
print @n1+1

print @n2+1 
End


--stored procedure
--set of sql statements ddl,dml,dql,tcl,
/*create procedure or proc procedure name
declaration
as
begin
set  of sql statements
end

*/
--ex 1 Procedure without parameters
create procedure spu_dept
as
begin
select * from tblDepartment
end

--to execute
exec spu_dept

--ex 2 procedure with parameters

create procedure spu_Insertdept(@deptname varchar(30),@yoe date)
as
begin
insert into tblDepartment(Dname,Yearofestablishment) values (@deptname,@yoe)
end

exec spu_Insertdept @deptname='CSE' ,@yoe='2015-05-10'

select * from tblDepartment

--ex 3
create procedure spu_selfjoin
as
begin
select m.Ename 'Manager name' , COUNT(e.Eid)
from tblEmployee e 
left join tblEmployee m
on e.mgrid = m.Eid
where m.Ename is not null
group by (m.Ename)
end

exec spu_selfjoin

--ex 4 :with return value
--display no of departments
create procedure spu_returnvalue
as
begin
return (select COUNT(did) 'no of dept' from tblDepartment)
end

declare @c int
exec @c=spu_returnvalue
select @c 'no of dept'

--ex 5
--when making changes in existing procedure
--when use return statement in procedure it should return single value
alter procedure spu_returnvalue
as
begin
return (select did from tblDepartment)
end

declare @d int 
exec  @d =spu_returnvalue
select @d

--ex 6
--storeprocedure with return will return only the integers not other datatype
create procedure spu_returnvalue1(@deptid int)
as
begin
return (select Dname from tblDepartment where did = @deptid)
end

declare @d varchar(30) 
exec  @d =spu_returnvalue1 @deptid=101
select @d

--ex 7 stored procedure with out parameter
--display the no of departments established in 2013-03-10
create procedure spu_NEmp(@yoe date , @noofdept int output)
as
begin
set @noofdept = (select COUNT(did) from tblDepartment where Yearofestablishment =@yoe)
end

declare @count int
exec spu_NEmp @yoe ='2013-10-02' ,@noofdept = @count output
if(@count>0)
 print @count
else
  print 'no dept!!!'


alter proc spu_NEmp(@id int ,@name varchar(30) output)
as
begin
if(@id is not null and @id>0)
 set @name=(select ename from tblEmployee where eid =@id)
else
 set @name = 'id is null or id is 0'
end

declare @empname varchar(30)
exec spu_NEmp @id=13,@name=@empname output
print @empname

--create procedure to display ename , salary and dname
create procedure spu_Emp
as
begin
select e.salary ,e.ename,d.dname
from tblemployee e join tbldepartment d
on e.DeptId=d.did
end

exec spu_Emp

drop procedure spu_Emp

create procedure spu_Emp
as
begin
select e.Ename,e.salary ,d.dname
from tblemployee e join tbldepartment d
on e.DeptId=d.did
end
 exec spu_Emp

 --can we call aprocedure from another procedure??yessss
 create proc spu_calEmp
 as
 begin
 exec spu_Emp
 end

 exec spu_calEmp


 --functions
 --user defined functions 1.scalar function 2.tablevalued function
 --functiom cant return text,ntext,image,cursor,and timestamp
 /*create function functionname(parameter list)
 returns datatype
 begin
 sql-statement
 return value
 end*/
 --ddl,dml statements cant be used inside function
 --dql is used in function


 --ex 1
 create function fun_BonusCalculation(@id int)
 returns float
 as
 begin
 return (select salary*0.2 from tblEmployee where eid=@id)
 end


 --execute
 select dbo.fun_BonusCalculation(12) 'bonus'

 select Eid,Ename,salary,dbo.fun_BonusCalculation(Eid)'Bonus amount' from tblEmployee

 --can we call a function inside stored procedure??yesss

 create procedure spu_callfun
 as
 begin
 select Eid,Ename,salary,dbo.fun_BonusCalculation(Eid)'Bonus amount' from tblEmployee
 end

--ex 2
create function fun_TaxCalculation(@id int)
returns float
as
begin
declare @Annualsal int,@Taxamount float
set @Annualsal=(select salary*12 from tblEmployee where eid=@id)
if(@Annualsal>=500000)
set @Taxamount=@Annualsal*0.1
else
set @Taxamount=0
return @Taxamount
end

select ename,salary,dbo.fun_TaxCalculation(eid) 'tx amount' from tblEmployee


--Tablevalued functions
/*
create function functionname(param list)
returns table
as
return statement
*/

create  function fun_TEmp()
returns table
as
return(select e.ename,e.salary,d.dname,d.Yearofestablishment
from tblEmployee e
right join tblDepartment d
on e.DeptId=d.Did)

--to execute
select * from fun_TEmp()

--date function-Inbuild function

select GETDATE() 'current date and time'

select CONVERT (date,GETDATE()) 'date'

select DATEPART(day,getdate()) 'date'

select DATEPART(MONTH,getdate()) 'month'

select DATEPART(YEAR,getdate()) 'year'

select DATEADD(day,7,getdate()) 'adding 7 days with today'

select(CONVERT(date,DATEADD(day,7,getdate()))) 'adding 7 days with today'

--mathematical function

select CEILING(126.90) --rounds to next higher value
select floor(126.90)
select ABS(126.90)

--create a function to find the year of birth of employee 
--create a function to find the age of department

--diff between table valued function and views

create function fun_Boe(@yob int)
returns int
as
begin
return (select (2021-age) from tblEmployee where Eid=@yob)
end

select dbo.fun_Boe(eid) 'yob of employee' from tblEmployee


create function fun_Aod(@age int)
returns int
as
begin
return (select (2021- DATEPART(year,yearofestablishment)) from tblDepartment where Did=@age)
end

select dbo.fun_Aod(did) 'age of dept' from tblDepartment


--alter function functionname
--statements

--to drop function
drop function dbo.fun_TaxCalculation

--TCL  - transaction control language
--save,rollback,commit

select * from tblDepartment

begin transaction
insert into  tblDepartment (Dname,Yearofestablishment) values('ECE','2018-02-10')
update tblDepartment set Yearofestablishment = '2013-10-30' where Did=104
save transaction s1
delete from tblDepartment where did = 103
select * from tblDepartment
save transaction s2
rollback transaction s1


--commit
--dont use rollback in commit
begin transaction t1
delete from tblDepartment where did=106
select * from tblDepartment
commit
rollback transaction t1


--integrity constraint
create table movie (mid nvarchar(10) primary key, moviename nvarchar(20))
insert into movie(mid,moviename) values ('M001' , 'AAA'),('M002','BBB'),('M003','CCC')

create table booking(bid int , username nvarchar(20),movieid nvarchar(10) references movie(mid)
on delete cascade
on update cascade)

insert into booking(bid,username,movieid) values (1,'Anitha','M001'),(2,'Ram','M001'),(3,'Sunil','M002'),(4,'Rinky','M003')

select * from movie
select * from booking

delete from movie where  mid ='M003'
update movie set mid='MM02' where moviename='BBB'


--non equi join <,>,<=,>=,etc
select e.Ename 'employee name',m.Ename 'manager name'
from tblEmployee e
inner join tblEmployee m
on e.mgrid = m.Eid and e.salary<m.salary


--corelated queries :exists

--index








