CREATE TABLE [dbo].[Enderecos]
(
	[ClienteID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [EnderecoID] UNIQUEIDENTIFIER NULL, 
    [Rua] VARCHAR(255) NULL, 
    [Cidade] VARCHAR(255) NULL, 
    [Estado] VARCHAR(255) NULL,
	CONSTRAINT [FK_Enderecos_Clientes] FOREIGN KEY (ClienteID) REFERENCES [Clientes](ClienteID)

)
