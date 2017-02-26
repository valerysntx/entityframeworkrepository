CREATE TABLE [dbo].[Reminder] (
    [ReminderID]      INT      IDENTITY (1, 1) NOT NULL,
    [JobFormResultID] INT      NOT NULL,
    [ReminderDate]    DATETIME NOT NULL,
    [UpdatedBy]       INT      NOT NULL,
    [CreatedBy]       INT      NOT NULL,
    [DateAdded]       DATETIME NOT NULL,
    [DateUpdated]     DATETIME NOT NULL,
    CONSTRAINT [PK_Reminder] PRIMARY KEY CLUSTERED ([ReminderID] ASC)
);

