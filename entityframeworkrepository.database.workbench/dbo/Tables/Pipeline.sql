CREATE TABLE [dbo].[Pipeline] (
    [PipelineID]  INT      IDENTITY (1, 1) NOT NULL,
    [StageID]     INT      NOT NULL,
    [CandidateID] INT      NOT NULL,
    [JobID]       INT      NOT NULL,
    [UpdatedBy]   INT      NULL,
    [CreatedBy]   INT      NOT NULL,
    [DateAdded]   DATETIME NOT NULL,
    [DateUpdated] DATETIME NOT NULL,
    [IsDeclined]  BIT      NOT NULL,
    CONSTRAINT [PK_Pipeline] PRIMARY KEY CLUSTERED ([PipelineID] ASC),
    CONSTRAINT [FK_Pipeline_Stage] FOREIGN KEY ([StageID]) REFERENCES [dbo].[Stage] ([StageID]) NOT FOR REPLICATION
);

