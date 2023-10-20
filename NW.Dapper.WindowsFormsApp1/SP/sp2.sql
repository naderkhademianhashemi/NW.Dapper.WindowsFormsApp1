USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[Ten Most Expensive Products]    Script Date: 10/20/2023 12:46:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[Ten Most Expensive Products] AS
SET ROWCOUNT 10
SELECT Products.ProductName AS TenMostExpensiveProducts, Products.UnitPrice
FROM Products
ORDER BY Products.UnitPrice DESC

GO

