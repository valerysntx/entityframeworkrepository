CREATE TABLE [dbo].[JobFormResultDetail] (
    [JobFormResultDetailID] INT           IDENTITY (1, 1) NOT NULL,
    [JobFormResultID]       INT           NOT NULL,
    [CandidateID]           INT           NOT NULL,
    [SchoolName]            VARCHAR (100) NOT NULL,
    [SchoolStart]           INT           NULL,
    [SchoolEnd]             INT           NULL,
    [SchoolFieldOfStudy]    VARCHAR (100) NULL,
    [SchoolDegree]          VARCHAR (50)  NULL,
    [Company]               VARCHAR (50)  NULL,
    [Industry]              VARCHAR (50)  NULL,
    [JobTitle]              VARCHAR (50)  NULL,
    [Summary]               VARCHAR (100) NULL,
    [IsCurrentWork]         BIT           NULL,
    [ExperienceStart]       INT           NULL,
    [ExperienceEnd]         INT           NULL,
    [UpdatedBy]             INT           NOT NULL,
    [CreatedBy]             INT           NOT NULL,
    [DateAdded]             DATETIME      NOT NULL,
    [DateUpdated]           DATETIME      NOT NULL,
    CONSTRAINT [PK_JobFormResultDetail] PRIMARY KEY CLUSTERED ([JobFormResultDetailID] ASC)
);

