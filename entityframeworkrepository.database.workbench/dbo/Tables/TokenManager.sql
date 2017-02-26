CREATE TABLE [dbo].[TokenManager] (
    [TokenId]     INT          IDENTITY (1, 1) NOT NULL,
    [Token]       VARCHAR (50) NULL,
    [Email]       VARCHAR (50) NULL,
    [IPAddress]   VARCHAR (20) NULL,
    [TypeId]      INT          NOT NULL,
    [UpdatedBy]   INT          NOT NULL,
    [CreatedBy]   INT          NOT NULL,
    [DateAdded]   DATETIME     NULL,
    [DateUpdated] DATETIME     NOT NULL,
    CONSTRAINT [PK_[TokenManager] PRIMARY KEY CLUSTERED ([TokenId] ASC)
);

