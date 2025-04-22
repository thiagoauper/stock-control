/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Product
	(
	Id INT NOT NULL IDENTITY (1, 1),
	Name varchar(50) NOT NULL,
	Code uniqueidentifier NOT NULL,
	Quantity INT NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Product ADD CONSTRAINT
	Product_Quantity_Not_Negative CHECK (Quantity >= 0)
GO
ALTER TABLE dbo.Product ADD CONSTRAINT
	PK_Product PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX Unique_Product_Code ON dbo.Product
	(
	Code
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Product SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.ProductMovement
	(
	Id int NOT NULL IDENTITY (1, 1),
	ProductId int NOT NULL,
	CreationDate datetime NOT NULL,
	TotalInbound int NULL,
	TotalOutbound int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ProductMovement ADD CONSTRAINT
	Allow_ProductMovement_Inbound_OR_Outbound CHECK ((TotalInbound > 0 AND TotalOutbound IS NULL) OR (TotalInbound IS NULL AND TotalOutbound > 0))
GO
ALTER TABLE dbo.ProductMovement ADD CONSTRAINT
	PK_ProductMovement PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ProductMovement ADD CONSTRAINT
	FK_ProductMovement_Product FOREIGN KEY
	(
	ProductId
	) REFERENCES dbo.Product
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ProductMovement SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO


-- PLEASE NOTE THAT I COULD'VE MADE A LOOP HERE, BUT DIDN'T WANT TO WASTE TIME ON IT
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 1', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 2', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 3', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 4', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 5', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 6', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 7', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 8', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 9', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 10', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 11', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 12', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 13', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 14', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 15', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 16', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 17', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 18', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 19', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 20', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 21', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 22', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 23', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 24', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 25', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 26', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 27', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 28', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 29', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 30', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 31', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 32', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 33', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 34', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 35', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 36', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 37', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 38', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 39', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 40', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 41', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 42', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 43', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 44', NEWID(), 0)
INSERT INTO Product(Name, Code, Quantity) VALUES ('Product 45', NEWID(), 0)