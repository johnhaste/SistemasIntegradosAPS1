CREATE TABLE [dbo].[Pedidos]
(
	[ClienteID] UNIQUEIDENTIFIER NOT NULL , 
    [NroPedido] INT NOT NULL, 
    [Data] DATETIME NOT NULL,
	CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY ([CLienteID]) REFERENCES Clientes(ClienteID), 
    PRIMARY KEY ([NroPedido])
)
