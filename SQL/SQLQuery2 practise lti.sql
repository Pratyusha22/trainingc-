create table tblstudent(rollno int identity (1,1) primary key ,sname nvarchar(20),age int check(age>20),gender varchar(20),degree varchar(20))

create table tblcoursereg(cid int primary key ,cname varchar(20),entrancemarks int)

alter table tblcoursereg add rollno int references tblstudent(rollno)

insert into tblstudent(sname,age,gender,degree) values ('Sri',30,'male','pass'),('Anu',28,'female','pass'),('Banu',27,'female','pass'),
('Rai',28,'male','pass'),('gayathri',27,'female','pass')
insert into tblcoursereg(cid,cname,entrancemarks) values (1,'java',80),(2,'python',70),(3,'c#',85),(4,'c++',65)
update tblcoursereg set rollno =1 where  cid = 3
update tblcoursereg set rollno =2 where  cid = 2
update tblcoursereg set rollno =3 where  cid = 1
select * from tblstudent
select * from tblcoursereg
select c.cid,COUNT(s.rollno) 'no of students'
from tblstudent s, tblcoursereg c
where c.cid=s.rollno
group by c.cid

select * from tblstudent where rollno > all(select rollno from tblcoursereg where entrancemarks =
(select entrancemarks from tblcoursereg where cid =1))


create view v_Sdetails as
select s.Sname,s.age from tblstudent s