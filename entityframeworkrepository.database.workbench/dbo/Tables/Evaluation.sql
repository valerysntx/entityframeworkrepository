CREATE TABLE [dbo].[Evaluation] (
    [EvaluationID]     INT           NULL,
    [EvaluationText]   VARCHAR (100) NULL,
    [EvaluationOption] VARCHAR (20)  NULL,
    [EvalutionTypeID]  INT           NULL,
    [JobFormResultID]  INT           NULL,
    [StageID]          INT           NULL,
    [UpdatedBy]        INT           NULL,
    [CreatedBy]        INT           NULL,
    [DateAdded]        DATETIME      NULL,
    [DateUpdated]      DATETIME      NULL
);

