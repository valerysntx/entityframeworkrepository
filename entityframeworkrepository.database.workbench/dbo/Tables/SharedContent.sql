CREATE TABLE [dbo].[SharedContent] (
    [SharedContentID]        INT           IDENTITY (1, 1) NOT NULL,
    [JobFormResultID]        INT           NULL,
    [ShareContentTypeID]     INT           NULL,
    [AllowComment]           TINYINT       NULL,
    [ShowTimeLineEvaluation] TINYINT       NULL,
    [ShareContentMessage]    VARCHAR (100) NULL,
    [ShareContentLink]       VARCHAR (200) NULL,
    [ShareContentWith]       INT           NULL,
    [UpdatedBy]              INT           NOT NULL,
    [CreatedBy]              INT           NOT NULL,
    [DateAdded]              DATETIME      NOT NULL,
    [DateUpdated]            DATETIME      NOT NULL,
    [ShareContentWithEmail]  VARCHAR (30)  NULL,
    CONSTRAINT [PK_SharedContent] PRIMARY KEY CLUSTERED ([SharedContentID] ASC)
);

