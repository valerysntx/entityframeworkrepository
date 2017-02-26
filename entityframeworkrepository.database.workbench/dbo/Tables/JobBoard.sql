CREATE TABLE [dbo].[JobBoard] (
    [JobBoardID]          INT           IDENTITY (1, 1) NOT NULL,
    [JobBoardName]        VARCHAR (50)  NOT NULL,
    [JobBoardLogo]        VARCHAR (100) NOT NULL,
    [JobBoardTypeID]      INT           NOT NULL,
    [JobBoardDescription] VARCHAR (100) NULL,
    [UpdatedBy]           INT           NOT NULL,
    [CreatedBy]           INT           NOT NULL,
    [DateAdded]           DATETIME      NOT NULL,
    [DateUpdated]         DATETIME      NOT NULL,
    CONSTRAINT [PK_JobBoard] PRIMARY KEY CLUSTERED ([JobBoardID] ASC)
);

