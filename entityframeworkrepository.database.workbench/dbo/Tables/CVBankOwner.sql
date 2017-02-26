CREATE TABLE [dbo].[CVBankOwner] (
    [CVBankOwnerID]   INT      IDENTITY (1, 1) NOT NULL,
    [CVBankID]        INT      NOT NULL,
    [JobFormResultID] INT      NOT NULL,
    [IsDeleted]       BIT      NULL,
    [UpdatedBy]       INT      NOT NULL,
    [CreatedBy]       INT      NOT NULL,
    [DateAdded]       DATETIME NOT NULL,
    [DateUpdated]     DATETIME NOT NULL,
    CONSTRAINT [PK_CVBankOwner] PRIMARY KEY CLUSTERED ([CVBankOwnerID] ASC),
    CONSTRAINT [FK_CVBankOwner_CVBank] FOREIGN KEY ([CVBankID]) REFERENCES [dbo].[CVBank] ([CVBankID]) NOT FOR REPLICATION
);

