
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.dailyDBimport


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	--Include in schema??????
drop table DimosPay.dbo.tempImported
CREATE TABLE DimosPay.dbo.tempImported (
    vat nvarchar(100),
    first_name nvarchar(100),
    last_name nvarchar(100),
	email nvarchar(100),
	phone nvarchar(100),
	addressi nvarchar(100), 
	county nvarchar(100),
	bill_id nvarchar(100),
	Billdescription nvarchar(100),
	amount nvarchar(100),
	date_due date
);


--select *
--into #BillArch
--from DimosPay.dbo.Bills


IF OBJECT_ID('tempdb..#DirectoryTree') IS NOT NULL
      DROP TABLE #DirectoryTree;

CREATE TABLE #DirectoryTree (
       id int IDENTITY(1,1)
      ,subdirectory nvarchar(512)
      ,depth int
      ,isfile bit);

INSERT #DirectoryTree (subdirectory,depth,isfile)
EXEC master.sys.xp_dirtree 'C:\Users\Nubi\Desktop\dimos\unprocessed',0,1;

declare @path nvarchar(250) = 'Users\Nubi\Desktop\dimos\unprocessed\' ;
declare @pathfile nvarchar (520);
declare @NoOfFiles int = (select count(*) as indd from #DirectoryTree where isfile=1);
declare @cnt int =0;

WHILE @cnt < @NoOfFiles
BEGIN
     SET @cnt = @cnt + 1;
	 SET @pathfile=@path+(select subdirectory  from #DirectoryTree where id=@cnt and isfile=1);
	 

Exec( 'BULK INSERT dimospay.dbo.tempImported 
   FROM ''C:\'+@pathfile+'''
   WITH 
      (
         FIELDTERMINATOR ='';'',
         ROWTERMINATOR =''\n'',
		 FIRSTROW = 2,
		TABLOCK
      )'
      )


select * 
into #uniqueInsertedUsers
from (
select vat ,first_name,last_name,email,phone,addressi,county 
,ROW_NUMBER() over (partition by vat order by bill_id) as rw
from DimosPay.dbo.tempImported 
)a
where rw=1

select i.*, 1 as FirstLogin
into #newUsers
from  #uniqueInsertedUsers i
left join DimosPay.dbo.users u
on u.UserID=i.vat
where u.UserID is null

drop table #uniqueInsertedUsers


insert into DimosPay.dbo.Users (UserID,Email,FirstLogin,FirstName,LastName,Phone)
						select vat,email,FirstLogin,first_name,last_name,phone from #newUsers
insert into DimosPay.dbo.AddressInfo(Address,County,UserID)
						select addressi,county,vat from #newUsers


insert into DimosPay.dbo.Bills (BillID,Amount,Description,DueDate,Status,UserID)
select bill_id, cast ((REPLACE([amount], ',', '.')) as float) as amount,Billdescription,date_due,'Pending' as Status, vat
from DimosPay.dbo.tempImported 


TRUNCATE TABLE DimosPay.dbo.tempImported;
drop table #newUsers


END;

--select *
--from DimosPay.dbo.Users

--select *
--from DimosPay.dbo.bills


--drop table #BillArch ---How to handle history
--tRUNCATE TABLE DimosPay.dbo.addressinfo;
--DELETE FROM  dimospay.dbo.users
--WHERE FirstLogin=1;
--DELETE FROM  dimospay.dbo.Bills
--WHERE Status='pending';



END
GO
