CREATE TABLE [dbo].[CVBank] (
    [CVBankID]       INT           IDENTITY (1, 1) NOT NULL,
    [CVBankText]     VARCHAR (MAX) NULL,
    [CVBankUniqueID] VARCHAR (50)  NULL,
    [CVBankFilename] VARCHAR (100) NULL,
    [UpdatedBy]      INT           NOT NULL,
    [CreatedBy]      INT           NOT NULL,
    [DateAdded]      DATETIME      NOT NULL,
    [DateUpdated]    DATETIME      NOT NULL,
    CONSTRAINT [PK_CVBank] PRIMARY KEY CLUSTERED ([CVBankID] ASC)
);

