CREATE TABLE [dbo].[JobFormResultQA] (
    [JobFormResultQAID] INT           IDENTITY (1, 1) NOT NULL,
    [JobFormResultID]   INT           NOT NULL,
    [CandidateID]       INT           NOT NULL,
    [QuestionAnswerXML] VARCHAR (MAX) NULL,
    [UpdatedBy]         INT           NOT NULL,
    [CreatedBy]         INT           NOT NULL,
    [DateAdded]         DATETIME      NOT NULL,
    [DateUpdated]       DATETIME      NOT NULL,
    [Question]          VARCHAR (50)  NULL,
    [QuestionUniqueID]  VARCHAR (36)  NULL,
    [QuestionWeight]    INT           NULL,
    [IsAnswer]          BIT           NULL,
    CONSTRAINT [PK_JobFormResultQA] PRIMARY KEY CLUSTERED ([JobFormResultQAID] ASC)
);

