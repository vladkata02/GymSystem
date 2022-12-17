CREATE TABLE [dbo].[Users] (
    [UserId]                      INT                 NOT NULL IDENTITY,
    [Username]                    NVARCHAR(MAX)       NOT NULL,
    [Email]                       NVARCHAR(MAX)       NOT NULL,
    [PasswordHashed]              NVARCHAR(MAX)       NOT NULL,
    [HasActiveSubscription]       BIT                 NULL,

    CONSTRAINT [PK_User]          PRIMARY KEY ([UserId]),
);
GO

CREATE TABLE [dbo].[Posts] (
    [PostId]                      INT                 NOT NULL IDENTITY,
    [Description]                 NVARCHAR(MAX)       NOT NULL,
    [CreateDate]                  DATETIME2           NOT NULL,
    [UserId]                      INT                 NOT NULL,
    [ImageContent]                VARBINARY(max)      NOT NULL,

    CONSTRAINT [PK_Posts]         PRIMARY KEY ([PostId]),
    CONSTRAINT [FK_Post_User]     FOREIGN KEY ([UserId])   REFERENCES [dbo].[Users] ([UserId])
);
GO

CREATE TABLE [dbo].[Subscriptions] (
    [SubscriptionId]              INT                 NOT NULL IDENTITY,
    [UserId]                      INT                 NOT NULL,
    [DateFrom]                    DATETIME2           NOT NULL,
    [DateTo]                      DATETIME2           NOT NULL,
    [MoneyPaid]                   DECIMAL             NOT NULL,

    CONSTRAINT [PK_Subscriptions]          PRIMARY KEY ([SubscriptionId]),
    CONSTRAINT [FK_Subscriptions_User]     FOREIGN KEY ([UserId])   REFERENCES [dbo].[Users] ([UserId])
);
GO

CREATE TABLE [dbo].[Prices] (
    [PriceId]                     INT                 NOT NULL IDENTITY,
    [Months]                      INT                 NULL,
    [Amount]                      DECIMAL             NOT NULL,
    [IsDefaultPrice]              BIT                 NOT NULL,

    CONSTRAINT [PK_Prices]        PRIMARY KEY ([PriceId]),
);
GO