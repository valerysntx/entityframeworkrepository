CREATE TABLE [dbo].[Department] (
    [DepartmentID] INT      IDENTITY (1, 1) NOT NULL,
    [CompanyID]    INT      NOT NULL,
    [PersonID]     INT      NOT NULL,
    [UpdatedBy]    INT      NOT NULL,
    [CreatedBy]    INT      NOT NULL,
    [DateAdded]    DATETIME NOT NULL,
    [DateUpdated]  DATETIME NOT NULL,
    CONSTRAINT [PK_Department_1] PRIMARY KEY CLUSTERED ([CompanyID] ASC, [PersonID] ASC),
    CONSTRAINT [FK_Department_Company] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[Company] ([CompanyID]) NOT FOR REPLICATION,
    CONSTRAINT [FK_Department_Person] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID])
);

