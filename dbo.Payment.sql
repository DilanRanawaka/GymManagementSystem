CREATE TABLE [dbo].[Payment] (
    [PaymentID]     NVARCHAR (50) NOT NULL, 
    [CustomerID]    NVARCHAR (50) NOT NULL,
    [CustomerName]  NVARCHAR (50) NOT NULL,
    [Date]          NVARCHAR (50) NOT NULL,
    [Amount]        NVARCHAR (50) NOT NULL,
    [Paymentmethod] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([PaymentID] ASC)
);

