--
-- Copyright (c) 2024 karamem0
--
-- This software is released under the MIT License.
--
-- https://github.com/karamem0/japan-m365-community-conference-2024
--

CREATE TABLE [dbo].[FaqCategory] (
    [Id] INT NOT NULL,
    [Name] NVARCHAR(256) NOT NULL,
    [Created] DATETIME NOT NULL,
    [Updated] DATETIME NOT NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [PK_FaqCategory] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO

CREATE TABLE [dbo].[Faq] (
    [Id] INT NOT NULL,
    [CategoryId] INT NOT NULL,
    [Question] NVARCHAR(256) NOT NULL,
    [Answer] NVARCHAR(MAX) NOT NULL,
    [Url] NVARCHAR(MAX) NULL,
    [Created] DATETIME NOT NULL,
    [Updated] DATETIME NOT NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [PK_Faq] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Faq_FaqCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[FaqCategory] ([Id])
)
GO

CREATE VIEW [dbo].[FaqView] AS (
    SELECT
        [Faq].[Id],
        [FaqCategory].[Name] AS [Category],
        [Faq].[Question],
        [Faq].[Answer],
        [Faq].[Url],
        [Faq].[Created],
        [Faq].[Updated],
        [Faq].[RowVersion]
    FROM
        [dbo].[Faq]
    INNER JOIN
        [dbo].[FaqCategory]
    ON
        [Faq].[CategoryId] = [FaqCategory].[Id]
)
