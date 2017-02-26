CREATE TABLE [dbo].[PricePackage] (
    [PricePackageID]   INT          IDENTITY (1, 1) NOT NULL,
    [PricePackageName] VARCHAR (50) NOT NULL,
    [Price]            MONEY        NOT NULL,
    [ForDay]           INT          NOT NULL,
    [IsDelete]         BIT          CONSTRAINT [DF__PricePack__IsDel__7849DB76] DEFAULT ((0)) NOT NULL,
    [Description]      VARCHAR (50) NULL,
    [Description2]     VARCHAR (50) NULL,
    [Discount]         MONEY        NULL,
    [UpdatedBy]        INT          NOT NULL,
    [CreatedBy]        INT          NOT NULL,
    [DateAdded]        DATETIME     NOT NULL,
    [DateUpdated]      DATETIME     NOT NULL,
    CONSTRAINT [PK_PricePackage] PRIMARY KEY CLUSTERED ([PricePackageID] ASC)
);

