CREATE TABLE [dbo].[JobBoardCredential] (
    [JobBoardCredentialID] INT           IDENTITY (1, 1) NOT NULL,
    [JobID]                INT           NOT NULL,
    [JobBoardID]           INT           NOT NULL,
    [JobBoardUserName]     VARCHAR (50)  NOT NULL,
    [JobBoardPassword]     VARCHAR (100) NOT NULL,
    [JobBoardURL]          VARCHAR (200) NOT NULL,
    [UpdatedBy]            INT           NOT NULL,
    [CreatedBy]            INT           NOT NULL,
    [DateAdded]            DATETIME      NOT NULL,
    [DateUpdated]          DATETIME      NOT NULL,
    CONSTRAINT [PK_JobBoardCredential] PRIMARY KEY CLUSTERED ([JobBoardCredentialID] ASC),
    CONSTRAINT [FK_JobBoardCredential_JobBoard] FOREIGN KEY ([JobBoardID]) REFERENCES [dbo].[JobBoard] ([JobBoardID]) NOT FOR REPLICATION
);

