CREATE TABLE [dbo].[JobBoardCart] (
    [JobBoardCartID] INT      IDENTITY (1, 1) NOT NULL,
    [JobID]          INT      NOT NULL,
    [JobBoardID]     INT      NOT NULL,
    [UpdatedBy]      INT      NOT NULL,
    [CreatedBy]      INT      NOT NULL,
    [DateAdded]      DATETIME NOT NULL,
    [DateUpdated]    DATETIME NOT NULL,
    CONSTRAINT [PK_JobBoardCart] PRIMARY KEY CLUSTERED ([JobBoardCartID] ASC)
);

