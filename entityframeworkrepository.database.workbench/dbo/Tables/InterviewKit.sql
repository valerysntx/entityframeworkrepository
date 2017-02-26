CREATE TABLE [dbo].[InterviewKit] (
    [InterviewKitID]          INT           IDENTITY (1, 1) NOT NULL,
    [InterviewKitTypeID]      INT           NULL,
    [InterviewKitTitle]       VARCHAR (50)  NULL,
    [InterviewKitRequirement] VARCHAR (50)  NULL,
    [InterviewQuestions]      VARCHAR (200) NULL,
    [JobID]                   INT           NULL,
    [UpdatedBy]               INT           NOT NULL,
    [CreatedBy]               INT           NOT NULL,
    [DateAdded]               DATETIME      NOT NULL,
    [DateUpdated]             DATETIME      NOT NULL,
    CONSTRAINT [PK_InterviewKit] PRIMARY KEY CLUSTERED ([InterviewKitID] ASC)
);

