ALTER TABLE [dbo].[Posts]  DROP COLUMN [ImageContent]
GO

ALTER TABLE [dbo].[Posts]  ADD  [ImageLink]    NVARCHAR(MAX)    NOT NULL
GO