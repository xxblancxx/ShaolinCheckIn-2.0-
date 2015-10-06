
CREATE TABLE [dbo].[Club]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL
)
CREATE TABLE [dbo].[Team]
(
[Id] INT NOT NULL PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[Club] INT NOT NULL,
 CONSTRAINT [FK_CLUB] FOREIGN KEY ([Club]) REFERENCES [Club]([Id])
)
CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL,
	[Image] VARBINARY(MAX) NULL,
	[Team] INT NOT NULL, 
    CONSTRAINT [FK_TEAM] FOREIGN KEY ([Team]) REFERENCES [Team]([Id])
)
CREATE TABLE [dbo].[Registration]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TimeStamp] DATE NOT NULL, 
    [Student] INT NOT NULL, 
    CONSTRAINT [FK_STUDENT] FOREIGN KEY ([Student]) REFERENCES [Student]([Id])
)


----INSERT INTO dbo.Registration ( Student, TimeStamp) VALUES ('2', GETDATE());
--INSERT INTO dbo.Registration ( Student, TimeStamp) VALUES ( '3', GETDATE());
--INSERT INTO dbo.Registration ( Student, TimeStamp) VALUES ( '4', GETDATE());
--INSERT INTO dbo.Registration (Student, TimeStamp) VALUES ( '2', ('2015-10-05'));
--INSERT INTO dbo.Registration ( Student, TimeStamp) VALUES ('3', ('2015-10-05'));

