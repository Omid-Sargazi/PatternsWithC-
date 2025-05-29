USE AdventureWorksLT2019;
GO

EXEC sp_fkeys @pktable_name = 'SalesOrderHeader', @pktable_owner = 'SalesLT';
GO
