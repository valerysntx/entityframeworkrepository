CREATE TABLE [dbo].[Dictionary] (
    [DictionaryTypeID] INT          IDENTITY (1, 1) NOT NULL,
    [DictionaryType]   VARCHAR (50) NOT NULL,
    [ID2]              INT          CONSTRAINT [DF_Dictionary_ID2] DEFAULT ((0)) NULL,
    [ID3]              INT          CONSTRAINT [DF_Dictionary_ID3] DEFAULT ((0)) NULL,
    [Description]      VARCHAR (50) NULL,
    [FullDescription]  VARCHAR (50) NULL,
    [Code]             INT          NOT NULL,
    [Hierarchy]        INT          NULL,
    [DepartmentID]     INT          CONSTRAINT [DF_Dictionary_DepartmentID] DEFAULT ((0)) NULL,
    [CompanyID]        INT          CONSTRAINT [DF_Dictionary_CompanyID] DEFAULT ((0)) NULL,
    [IsDeleted]        BIT          NULL,
    [UpdatedBy]        INT          NULL,
    [CreatedBy]        INT          NULL,
    [DateAdded]        DATETIME     NULL,
    [DateUpdated]      DATETIME     NULL,
    CONSTRAINT [PK_Dictionary] PRIMARY KEY CLUSTERED ([DictionaryTypeID] ASC)
);

