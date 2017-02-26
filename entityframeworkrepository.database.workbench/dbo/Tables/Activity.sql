CREATE TABLE [dbo].[Activity] (
    [ActivityID]             INT          IDENTITY (1, 1) NOT NULL,
    [ActivityAction]         VARCHAR (50) NOT NULL,
    [ActivityTypeID]         INT          NOT NULL,
    [ActivityAffecterUserID] INT          NOT NULL,
    [UpdatedBy]              INT          NOT NULL,
    [CreatedBy]              INT          NOT NULL,
    [DateAdded]              DATETIME     NOT NULL,
    [DateUpdated]            DATETIME     NOT NULL,
    CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED ([ActivityID] ASC),
    CONSTRAINT [FK_Activity_Person] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Person] ([PersonID]) NOT FOR REPLICATION,
    CONSTRAINT [FK_Activity_Person1] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Person] ([PersonID]) NOT FOR REPLICATION
);

