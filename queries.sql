select * from ProductSellers order by Id desc
select * from Credentials order by id desc
select * from Products
select * from Sellers
select * from Orders order by IdOrder desc
select * from OrderDetails order by Id desc

select * from Orders as o inner join OrderDetails as od on (o.IdOrder = od.IdOrder)

select s.Usename, count(*) as CountOrders, sum(od.TotalPrice) as TotalAmount
from Orders as o inner join OrderDetails as od on (o.IdOrder = od.IdOrder)
inner join Sellers as s on (s.IdSeller = o.IdSeller)
group by s.Usename order by TotalAmount DESC

select s.Usename, count(*) as CountOrders, sum(od.TotalPrice) as TotalAmount
from Orders as o inner join OrderDetails as od on (o.IdOrder = od.IdOrder)
inner join Sellers as s on (s.IdSeller = o.IdSeller)
group by s.Usename order by CountOrders ASC

--select * from ProductSellers as ps inner join Sellers as se on (ps.IdSeller = se.IdSeller)

select se.IdSeller, count(*) as CountSells, sum(ps.Price) as TotalAmount
from ProductSellers as ps inner join Sellers as se on (ps.IdSeller = se.IdSeller)
group by se.IdSeller order by CountSells ASC

select s.Usename, count(o.IdOrder) as CountOrders, sum(od.TotalPrice) as TotalAmount
from Sellers as s 
inner join Orders as o on (s.IdSeller = o.IdSeller)
inner join OrderDetails as od on (o.IdOrder = od.IdOrder)
group by s.Usename 
order by TotalAmount ASC

