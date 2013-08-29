CREATE TABLE [dbo].[DemoDatas] (
    [IntegerData]  INT             IDENTITY (1, 1) NOT NULL DEFAULT 1,
    [DateTimeData] DATETIME        NOT NULL DEFAULT 01/01/1900,
    [StringData]   NVARCHAR (MAX)  NOT NULL DEFAULT Adam,
    [StringData2]  NVARCHAR (MAX)  NOT NULL DEFAULT Phil,
    [NumData]      DECIMAL (18, 2) NOT NULL DEFAULT 100.52,
    CONSTRAINT [PK_dbo.DemoDatas] PRIMARY KEY CLUSTERED ([IntegerData] ASC)
);

