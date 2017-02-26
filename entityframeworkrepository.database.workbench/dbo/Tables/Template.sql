CREATE TABLE [dbo].[Template] (
    [TemplateID]         INT           IDENTITY (1, 1) NOT NULL,
    [TemplateName]       VARCHAR (50)  NULL,
    [TemplateText]       VARCHAR (MAX) NULL,
    [TemplateAttachment] VARCHAR (100) NULL,
    [IsDeleted]          TINYINT       NULL,
    [SortOrder]          INT           NULL,
    [CompanyID]          INT           NULL,
    [DepartmentID]       INT           NULL,
    [UpdatedBy]          INT           NOT NULL,
    [CreatedBy]          INT           NOT NULL,
    [DateAdded]          DATETIME      NOT NULL,
    [DateUpdated]        DATETIME      NOT NULL,
    CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED ([TemplateID] ASC),
    CONSTRAINT [FK_Template_Person] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Person] ([PersonID]),
    CONSTRAINT [FK_Template_Person2] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Person] ([PersonID]) NOT FOR REPLICATION
);

