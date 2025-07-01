
create table tblAdmin
(
AdminID nvarchar(50) primary key ,
[Password] nvarchar(50),
FullName nvarchar(50)

)
DELETE FROM tblAdmin;

select * from tblAdmin
declare @AdminID int;
declare @Password nvarchar(50);

select top 1 AdminID,Password,FullName from tblAdmin where AdminID=@AdminID and Password=@Password

create table tblSeller
(
SellerID int ,
SellerName nvarchar(50) Unique,
SellerAge int,
SellerPhone nvarchar(10),
SellerPass nvarchar(50)
)

select * from tblSeller
declare @SellerName int;
declare @SellerPass nvarchar(50);
select top 1 SellerName,SellerPass from tblSeller where SellerName=@SellerName and SellerPass=@SellerPass



drop table tblCategory
(
CatID int identity(1,1) primary key not null,
CategoryName nvarchar(50),
CategoryDesc nvarchar(50)
)
select * from tblCategory
declare @CategoryName nvarchar(50);
declare @CategoryDesc nvarchar(50);
insert into tblCategory (CategoryName,CategoryDesc) values(@CategoryName,@CategoryDesc);

create procedure spCatInsert
(
@CategoryName nvarchar(50),
@CategoryDesc nvarchar(50)
)
as
begin
insert into tblCategory (CategoryName,CategoryDesc) values(@CategoryName,@CategoryDesc)
end
------
select  CatID as CategoryID,CategoryName,CategoryDesc as CategoryDescription from tblCategory



create procedure spCatUpdate
(
@CatID int,
@CategoryName nvarchar(50),
@CategoryDesc nvarchar(50)
)
as
begin
update tblCategory set CategoryName=@CategoryName,CategoryDesc=@CategoryDesc where CatID=@CatID
end
-----
SELECT CatID AS CategoryID, CategoryName AS CategoryName, CategoryDesc AS CategoryDescription FROM tblCategory
select * from tblCategory;
create procedure spCatDelete
(
@CatID int 
)
as
begin
Delete from tblCategory where CatID=@CatID
end

----
select * from tblSeller


create procedure spSellerInsert
(
@SellerName nvarchar(50),
@SellerAge int, 
@SellerPhone nvarchar(50),
@SellerPass nvarchar(50)
)
as
begin
insert into tblSeller(SellerName,SellerAge,SellerPhone,SellerPass) values(@SellerName,@SellerAge,@SellerPhone,@SellerPass)
end
go
-------------
create procedure spSellerUpadte
(
@SellerID int,
@SellerName nvarchar(50),
@SellerAge int, 
@SellerPhone nvarchar(50),
@SellerPass nvarchar(50)
)
as
begin
update tblSeller set SellerName=@SellerName,SellerAge=@SellerAge,SellerPhone=@SellerPhone,SellerPass=@SellerPass where SellerID=@SellerID
end
go

----
create procedure spSellerDelete
(
@SellerID int 
)
as
begin
Delete from tblSeller where SellerID=@SellerID
end

go



select * from tblAdmin
select AdminID from tblAdmin where AdminID='coder'


create procedure spAddAdmin
(
@AdminID nvarchar(50),
@Password nvarchar(50),
@FullName nvarchar(50) 
)
as
begin
Insert into tblAdmin(AdminID,[Password],FullName) values(@AdminID,@Password,@FullName)
end
go

----
create procedure spUpdateAdmin
(
@AdminID nvarchar(50),
@Password nvarchar(50),
@FullName nvarchar(50) 
)
as
begin
update tblAdmin set [Password]=@Password,FullName=@FullName where AdminID=@AdminID
end
go

select * from tblCategory;



select * from tblAdmin
create procedure spDeleteAdmin
(
@AdminID nvarchar(50)
)
as
begin
delete tblAdmin where AdminID=@AdminID
end
go

--
create table tblProduct
(
ProdID int identity(1,1) primary key not null,
ProdName nvarchar(50),
ProdCatID int,
ProdPrice decimal(10,2),
ProdQty int,
)

create procedure spGetCategory
as
begin
set nocount on;
select CatID,CategoryName from tblCategory order by CategoryName asc
end
go

--
select * from tblProduct

create procedure spCheckDuplicateProduct
(
@ProdName nvarchar(50),
@ProdCatID int
)
as
begin
set nocount on;
select ProdName from tblProduct where ProdName=@ProdName and ProdCatID=@ProdCatID
end
go


drop procedure spInsertProduct
(
@ProdName nvarchar(50),
@ProdCatID int,
@ProdPrice decimal(10,2),
@ProdQty int
)
as
begin
 
Insert into tblProduct(ProdName,ProdCatID,ProdPrice,ProdQty) values(@ProdName,@ProdCatID,@ProdPrice,@ProdQty)
end
go

----


select * from tblCategory


select * from tblProduct

create procedure spGetAllProductList
as
begin
set nocount on;
select t1.ProdID,t1.ProdName,t2.CategoryName,t1.ProdPrice,t1.ProdQty from tblProduct as t1
inner join tblCategory as t2 on t1.ProdCatID=t2.CatID
order by t1.ProdName,t2.CategoryName asc
end
go

EXEC dbo.spGetAllProductList;
---
select * from tblProduct;
select * from tblCategory;
create procedure spUpdateProduct
(
@ProdID int,
@ProdName nvarchar(50),
@ProdCatID int,
@ProdPrice decimal(10,2),
@ProdQty int
)
as
begin
 update tblProduct set ProdName=@ProdName,ProdCatID=@ProdCatID,ProdPrice=@ProdPrice,ProdQty=@ProdQty where ProdID=@ProdID
end
go

---
create procedure spDeleteProduct
(
@ProdID Int
)
as
begin
delete from tblProduct where ProdID=@ProdID
end
go

select * from tblProduct
--
create procedure spGetAllProductList_SearchByCat
(
@ProdCatID int
)
as
begin
set nocount on;
select t1.ProdID,t1.ProdName,t2.CategoryName,t1.ProdCatID as CategoryID,t1.ProdPrice,t1.ProdQty from tblProduct as t1
inner join tblCategory as t2 on t1.ProdCatID=t2.CatID
where t1.ProdCatID=@ProdCatID
order by t1.ProdName,t2.CategoryName asc
end
go

----------------

create table tblBill
(
Bill_ID int primary key,
SellerID nvarchar(50),
SellDate nvarchar(50),
TotalAmt decimal(18,2)
)

create procedure spInsertBill
(
@Bill_ID int,
@SellerID nvarchar(50),
@SellDate nvarchar(50),
@TotalAmt decimal(18,2)
)
as
begin
insert into tblBill (Bill_ID,SellerID,SellDate,TotalAmt) values(@Bill_ID,@SellerID,@SellDate,@TotalAmt)
end
go
---

create procedure spGetBillList
as
begin
set nocount on;
select Bill_ID,SellerID,SellDate,TotalAmt from tblBill order by Bill_ID desc 
end
go
