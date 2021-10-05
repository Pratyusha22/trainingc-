--1..........
select FirstName,LastName 
from employees

--2.......
select *
from Customers
where Fax is not null

--3..............
select *
from Customers
where ContactName like '_u%'


--4..........
select *
from [Order Details]
where UnitPrice >10 and UnitPrice<20

--5..........
select od.OrderID,od.ProductID,od.Quantity,od.UnitPrice,od.Discount
from [Order Details] od,Orders o
where  od.OrderID=o.OrderID and o.ShippedDate is not null
order by o.ShippedDate 

--6...........
select * 
from Orders
where ShipName ='toms spezialitäten'



select *
from Orders
--7.............
select p.ProductID,p.ProductName from Products p , Suppliers s
where s.CompanyName='exotic liquids'

select * from Products
select * from Suppliers


--8...............
select p.ProductID,p.ProductName,AVG(Quantity) 'average quantity'
from [Order Details] od right outer join Products p
on p.ProductID=od.ProductID
group by p.ProductID,p.ProductName

--9.............
select od.ShipName,c.CompanyName
from Orders od inner join Customers c 
on od.CustomerId = c.CustomerId


--10..............
select e.employeeId,e.FirstName,m.FirstName'manager'
from Employees e,Employees m
where e.reportsto=m.employeeid


--11...........
select p.ProductID,p.ProductName,od.UnitPrice * Quantity-Discount 'price after discount' , c.CategoryName
from Products p inner join [Order Details] od
on p.ProductID = od.ProductID inner join Categories c
on p.CategoryID=c.CategoryID


--12................
create procedure spu_MaxOrders
as
begin
select COUNT(*),c.*
from Orders o right outer join Customers c
on c.CustomerID =o.CustomerID group by c.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle,c.Address,c.City,c.Region,c.PostalCode,c.Country,c.Phone,c.Fax
order by COUNT(*) desc
end
exec spu_MaxOrders

--13................
create procedure spu_OutofStockProducts
as
begin
select * from Products where UnitsInStock=0
end
exec spu_OutofStockProducts

