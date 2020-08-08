CREATE TABLE [dbo].[Accessories] (
    [AccessoryID]    NVARCHAR (50) NOT NULL,
    [AccessoryType]  NVARCHAR (50) NOT NULL,
    [AccessoryBrand] NVARCHAR (50) NOT NULL,
    [Quantity]       NVARCHAR(50) NOT NULL,
    [Price]          NVARCHAR(50) NOT NULL,
    [Date]           NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AccessoryID] ASC)
);

