CREATE TABLE [dbo].[Tag] (
    [TagID]           INT          IDENTITY (1, 1) NOT NULL,
    [TagName]         VARCHAR (20) NOT NULL,
    [JobFormResultID] INT          NOT NULL,
    [UpdatedBy]       INT          NOT NULL,
    [CreatedBy]       INT          NOT NULL,
    [DateAdded]       DATETIME     NOT NULL,
    [DateUpdated]     DATETIME     NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([TagID] ASC)
);

