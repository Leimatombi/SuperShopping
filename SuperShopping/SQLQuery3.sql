create table tblProduct
(
ProdID int identity(1,1) primary key not null,
ProdName nvarchar(50),
ProdCatID int,
ProdPrice decimal(10,2),
ProdQty int,
)

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

create procedure spInsertProduct
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

select * from tblProduct;
create procedure spDeleteProduct
(
@ProdID Int
)
as
begin
delete from tblProduct where ProdID=@ProdID
end
go


create  table tblCategory
(
CatID int identity(1,1) primary key not null ,
CategoryName nvarchar(50),
CategoryDesc nvarchar(50)
)
select * from tblCategory
declare @catID int
declare @CategoryName nvarchar(50);
declare @CategoryDesc nvarchar(50);
insert into tblCategory ( CategoryName,CategoryDesc) values( @CategoryName,@CategoryDesc) 





select  CatID as CategoryID,CategoryName,CategoryDesc as CategoryDescription from tblCategory
declare @CategoryName nvarchar(50);
declare @CatID int;
SELECT COUNT(*) FROM tblCategory WHERE CategoryName = @CategoryName AND CatID = @CatID

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

select * from tblCategory;
 
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

 create procedure spGetAllproductList
 as begin
 set nocount on;
 select t1.Prodname, t2.CategoryName, t1.ProdPrice, t1.ProdQty from tblProduct as t1
 inner join tblCategory as t2 on t1.ProdcatID= t2.CatID
 order by t1.prodname, t2.CategoryName asc
 end
 go   