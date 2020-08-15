CREATE TABLE [dbo].[Attendance] (
    [AttendanceID] NVARCHAR (50) NOT NULL,
    [CustomerID]   NVARCHAR (50) NOT NULL,
    [CustomerName] NVARCHAR (50) NOT NULL,
    [Date]         NVARCHAR (50) NOT NULL,
    [ArrivalTime]  NVARCHAR (50) NOT NULL,
    [DepTime]      NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([AttendanceID] ASC)
);

