CREATE TABLE [dbo].[TBLivro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Titulo] NCHAR(50) NOT NULL, 
    [Tema] NCHAR(50) NOT NULL, 
    [Autor] NCHAR(50) NOT NULL, 
    [Volume] INT NOT NULL, 
    [DataPublicacao] DATETIME NOT NULL, 
    [Disponibilidade] BIT NOT NULL
)
