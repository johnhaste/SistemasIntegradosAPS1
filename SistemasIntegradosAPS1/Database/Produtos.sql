CREATE TABLE [dbo].[Produtos]
(
	[ProdutoID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Descricao] VARCHAR(255) NULL, 
    [Preco] FLOAT NULL
)
