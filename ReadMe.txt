1. Skapa upp Databas i SqlServer localhost

CREATE DATABASE [DHTest]

GO

2. Skapa tabell 

USE [DHTest]

GO

CREATE TABLE [TodoItems] 
(
[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[Name] [nvarchar](500) NOT NULL,
[IsComplete] [bit] NOT NULL DEFAULT 0
)

insert into [DHTest].[dbo].[TodoItems]
(Name) values ('Bli frisk från covid')
insert into [DHTest].[dbo].[TodoItems]
(Name) values ('Beställa Maxi-påse')
insert into [DHTest].[dbo].[TodoItems]
(Name) values ('Hämta Maxi-påse')
insert into [DHTest].[dbo].[TodoItems]
(Name) values ('Hämta ved')

3. Klona hem repot och bygg. Se till att både CoreTaskWeb och CoreWebApi startar upp och bygger Api:t först. 
