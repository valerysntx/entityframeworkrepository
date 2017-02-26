CREATE TABLE [dbo].[Stage] (
    [StageID]         INT          IDENTITY (1, 1) NOT NULL,
    [ID]              INT          NULL,
    [JobFormResultID] INT          NULL,
    [NewsStageName]   VARCHAR (20) NULL,
    [DepartmentID]    INT          NULL,
    [UpdatedBy]       INT          NOT NULL,
    [CreatedBy]       INT          NOT NULL,
    [DateAdded]       DATETIME     NOT NULL,
    [DateUpdated]     DATETIME     NOT NULL,
    CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED ([StageID] ASC)
);

