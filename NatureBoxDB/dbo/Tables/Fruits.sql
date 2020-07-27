CREATE TABLE [dbo].[Fruits] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [ProductName]     VARCHAR (50)   NOT NULL,
    [ProductPrice]    FLOAT (53)     NOT NULL,
    [ProductBenefits] VARCHAR (100)  NOT NULL,
    [ProductAbout]    VARCHAR (MAX)  NOT NULL,
    [ProductImage]    NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

