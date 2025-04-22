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
	Code varchar(50) NOT NULL
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
INSERT INTO Product(Name, Code) VALUES ('Product 1', 'Prod1')
INSERT INTO Product(Name, Code) VALUES ('Product 2', 'Prod2')
INSERT INTO Product(Name, Code) VALUES ('Product 3', 'Prod3')
INSERT INTO Product(Name, Code) VALUES ('Product 4', 'Prod4')
INSERT INTO Product(Name, Code) VALUES ('Product 5', 'Prod5')
INSERT INTO Product(Name, Code) VALUES ('Product 6', 'Prod6')
INSERT INTO Product(Name, Code) VALUES ('Product 7', 'Prod7')
INSERT INTO Product(Name, Code) VALUES ('Product 8', 'Prod8')
INSERT INTO Product(Name, Code) VALUES ('Product 9', 'Prod9')
INSERT INTO Product(Name, Code) VALUES ('Product 10', 'Prod10')
INSERT INTO Product(Name, Code) VALUES ('Product 11', 'Prod11')
INSERT INTO Product(Name, Code) VALUES ('Product 12', 'Prod12')
INSERT INTO Product(Name, Code) VALUES ('Product 13', 'Prod13')
INSERT INTO Product(Name, Code) VALUES ('Product 14', 'Prod14')
INSERT INTO Product(Name, Code) VALUES ('Product 15', 'Prod15')
INSERT INTO Product(Name, Code) VALUES ('Product 16', 'Prod16')
INSERT INTO Product(Name, Code) VALUES ('Product 17', 'Prod17')
INSERT INTO Product(Name, Code) VALUES ('Product 18', 'Prod18')
INSERT INTO Product(Name, Code) VALUES ('Product 19', 'Prod19')
INSERT INTO Product(Name, Code) VALUES ('Product 20', 'Prod20')
INSERT INTO Product(Name, Code) VALUES ('Product 21', 'Prod21')
INSERT INTO Product(Name, Code) VALUES ('Product 22', 'Prod22')
INSERT INTO Product(Name, Code) VALUES ('Product 23', 'Prod23')
INSERT INTO Product(Name, Code) VALUES ('Product 24', 'Prod24')
INSERT INTO Product(Name, Code) VALUES ('Product 25', 'Prod25')
INSERT INTO Product(Name, Code) VALUES ('Product 26', 'Prod26')
INSERT INTO Product(Name, Code) VALUES ('Product 27', 'Prod27')
INSERT INTO Product(Name, Code) VALUES ('Product 28', 'Prod28')
INSERT INTO Product(Name, Code) VALUES ('Product 29', 'Prod29')
INSERT INTO Product(Name, Code) VALUES ('Product 30', 'Prod30')
INSERT INTO Product(Name, Code) VALUES ('Product 31', 'Prod31')
INSERT INTO Product(Name, Code) VALUES ('Product 32', 'Prod32')
INSERT INTO Product(Name, Code) VALUES ('Product 33', 'Prod33')
INSERT INTO Product(Name, Code) VALUES ('Product 34', 'Prod34')
INSERT INTO Product(Name, Code) VALUES ('Product 35', 'Prod35')
INSERT INTO Product(Name, Code) VALUES ('Product 36', 'Prod36')
INSERT INTO Product(Name, Code) VALUES ('Product 37', 'Prod37')
INSERT INTO Product(Name, Code) VALUES ('Product 38', 'Prod38')
INSERT INTO Product(Name, Code) VALUES ('Product 39', 'Prod39')
INSERT INTO Product(Name, Code) VALUES ('Product 40', 'Prod40')
INSERT INTO Product(Name, Code) VALUES ('Product 41', 'Prod41')
INSERT INTO Product(Name, Code) VALUES ('Product 42', 'Prod42')
INSERT INTO Product(Name, Code) VALUES ('Product 43', 'Prod43')
INSERT INTO Product(Name, Code) VALUES ('Product 44', 'Prod44')
INSERT INTO Product(Name, Code) VALUES ('Product 45', 'Prod45')