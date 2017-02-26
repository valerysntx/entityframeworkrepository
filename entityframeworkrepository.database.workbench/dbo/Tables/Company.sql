CREATE TABLE [dbo].[Company] (
    [CompanyID]        INT           IDENTITY (1, 1) NOT NULL,
    [CompanyName]      VARCHAR (200) NOT NULL,
    [CompanyURL]       VARCHAR (200) NULL,
    [CompanySubDomain] VARCHAR (200) NULL,
    [CompanyLogo]      VARCHAR (200) NULL,
    [CompanyProfile]   VARCHAR (200) NOT NULL,
    [CompanyTelephone] VARCHAR (20)  NULL,
    [CompanyTheme]     VARCHAR (100) NULL,
    [FirstName]        VARCHAR (20)  NULL,
    [LastName]         VARCHAR (20)  NULL,
    [VATNo]            VARCHAR (50)  NULL,
    [Address]          VARCHAR (200) NULL,
    [PostCode]         VARCHAR (20)  NULL,
    [IsDeleted]        INT           NULL,
    [CountryID]        INT           NULL,
    [City]             INT           NOT NULL,
    [UpdatedBy]        INT           NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [DateAdded]        DATETIME      NOT NULL,
    [DateUpdated]      DATETIME      NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);

