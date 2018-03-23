CREATE TABLE [dbo].[DetalhesPedido]
(
	[NroPedido] INT NOT NULL PRIMARY KEY, 
    [ProdutoID] UNIQUEIDENTIFIER NULL, 
    [Qtde] INT NULL, 
    [Preco] FLOAT NULL,
	CONSTRAINT [FK_DetalhesPedido_Pedidos] FOREIGN KEY (NroPedido) REFERENCES Pedidos(NroPedido),
	CONSTRAINT [FK_DetalhesPedido_Produtos] FOREIGN KEY (ProdutoID) REFERENCES Produtos(ProdutoID)

)
