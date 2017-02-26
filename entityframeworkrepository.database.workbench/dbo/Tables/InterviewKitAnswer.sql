CREATE TABLE [dbo].[InterviewKitAnswer] (
    [InterviewKitAnswerID] INT      IDENTITY (1, 1) NOT NULL,
    [JobID]                INT      NULL,
    [UpdatedBy]            INT      NOT NULL,
    [CreatedBy]            INT      NOT NULL,
    [DateAdded]            DATETIME NOT NULL,
    CONSTRAINT [PK_InterviewKitAnswer] PRIMARY KEY CLUSTERED ([InterviewKitAnswerID] ASC)
);

