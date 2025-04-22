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
	Code uniqueidentifier NOT NULL
	)  ON [PRIMARY]
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
	MovementType int NOT NULL,
	CreationDate datetime NOT NULL,
	Quantity int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ProductMovement ADD CONSTRAINT
	Quantity_Should_Be_Positive CHECK (Quantity > 0)
GO
ALTER TABLE dbo.ProductMovement ADD CONSTRAINT
	Movement_Type_Should_Be_Zero_OR_One CHECK (MovementType = 0 /*Inbound*/ OR MovementType = 1 /*Outbound*/)
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
INSERT INTO Product(Name, Code) VALUES ('Product 1', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 2', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 3', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 4', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 5', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 6', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 7', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 8', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 9', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 10', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 11', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 12', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 13', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 14', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 15', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 16', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 17', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 18', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 19', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 20', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 21', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 22', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 23', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 24', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 25', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 26', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 27', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 28', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 29', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 30', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 31', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 32', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 33', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 34', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 35', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 36', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 37', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 38', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 39', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 40', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 41', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 42', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 43', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 44', NEWID())
INSERT INTO Product(Name, Code) VALUES ('Product 45', NEWID())