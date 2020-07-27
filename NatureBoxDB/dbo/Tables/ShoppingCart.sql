CREATE TABLE [dbo].[ShoppingCart] (
    [Id]           INT           NOT NULL,
    [ProductName]  NVARCHAR (50) NOT NULL,
    [ProductPrice] FLOAT (53)    NOT NULL,
    [ProductType]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

