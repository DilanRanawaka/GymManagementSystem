CREATE TABLE [dbo].[Customer] (
    [CustomerID]   NVARCHAR (50) NOT NULL,
    [CustomerName] NVARCHAR (50) NOT NULL,
    [Address]      NVARCHAR (50) NOT NULL,
    [NIC]          NVARCHAR (50) NOT NULL,
    [Email]        NVARCHAR (50) NOT NULL,
    [Phone]        NVARCHAR (50) NOT NULL,
    [Gender]       NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

