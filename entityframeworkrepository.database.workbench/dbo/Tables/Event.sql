CREATE TABLE [dbo].[Event] (
    [EventID]         INT           IDENTITY (1, 1) NOT NULL,
    [JobFormResultID] INT           NULL,
    [EventNote]       VARCHAR (200) NULL,
    [EventTypeID]     INT           NULL,
    [EventStartDate]  DATETIME      NULL,
    [EventEndDate]    DATETIME      NULL,
    [EventAttendee]   INT           NULL,
    [UpdatedBy]       INT           NULL,
    [CreatedBy]       INT           NULL,
    [DateAdded]       DATETIME      NULL,
    [DateUpdated]     DATETIME      NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventID] ASC)
);

