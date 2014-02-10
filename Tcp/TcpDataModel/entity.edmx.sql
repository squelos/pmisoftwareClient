
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/10/2014 15:01:30
-- Generated from EDMX file: C:\Users\squelos\Documents\GitHub\pmisoftwareClient\Tcp\TcpDataModel\entity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TCP_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookingAggregationBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingJeu] DROP CONSTRAINT [FK_BookingAggregationBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingCourt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingJeu] DROP CONSTRAINT [FK_BookingCourt];
GO
IF OBJECT_ID(N'[dbo].[FK_BadgePlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BadgeJeu] DROP CONSTRAINT [FK_BadgePlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_PreferencePeriodPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreferencePeriodJeu] DROP CONSTRAINT [FK_PreferencePeriodPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingJeu] DROP CONSTRAINT [FK_PlayerBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentJeu] DROP CONSTRAINT [FK_PlayerPayment];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentSemester_Payment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentSemester] DROP CONSTRAINT [FK_PaymentSemester_Payment];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentSemester_Semester]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentSemester] DROP CONSTRAINT [FK_PaymentSemester_Semester];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerCategory_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerCategory] DROP CONSTRAINT [FK_PlayerCategory_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerCategory_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerCategory] DROP CONSTRAINT [FK_PlayerCategory_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerTrainingPreferences]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrainingPreferencesSet] DROP CONSTRAINT [FK_PlayerTrainingPreferences];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerJeu] DROP CONSTRAINT [FK_PlayerStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentMethodPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentJeu] DROP CONSTRAINT [FK_PaymentMethodPayment];
GO
IF OBJECT_ID(N'[dbo].[FK_DayPreferencePeriod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreferencePeriodJeu] DROP CONSTRAINT [FK_DayPreferencePeriod];
GO
IF OBJECT_ID(N'[dbo].[FK_DayTrainingPreferences]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrainingPreferencesSet] DROP CONSTRAINT [FK_DayTrainingPreferences];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerBallLevel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayerJeu] DROP CONSTRAINT [FK_PlayerBallLevel];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingPlayer2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingJeu] DROP CONSTRAINT [FK_BookingPlayer2];
GO
IF OBJECT_ID(N'[dbo].[FK_SeasonSemester]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SemesterJeu] DROP CONSTRAINT [FK_SeasonSemester];
GO
IF OBJECT_ID(N'[dbo].[FK_LogEntrynew_PlayerJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogEntry] DROP CONSTRAINT [FK_LogEntrynew_PlayerJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentProductQuantity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductQuantitySet] DROP CONSTRAINT [FK_PaymentProductQuantity];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductQuantityProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductQuantitySet] DROP CONSTRAINT [FK_ProductQuantityProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[SeasonJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeasonJeu];
GO
IF OBJECT_ID(N'[dbo].[SemesterJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SemesterJeu];
GO
IF OBJECT_ID(N'[dbo].[PaymentJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentJeu];
GO
IF OBJECT_ID(N'[dbo].[BadgeJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BadgeJeu];
GO
IF OBJECT_ID(N'[dbo].[BookingAggregationJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingAggregationJeu];
GO
IF OBJECT_ID(N'[dbo].[BookingJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingJeu];
GO
IF OBJECT_ID(N'[dbo].[CourtJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourtJeu];
GO
IF OBJECT_ID(N'[dbo].[PlayerJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerJeu];
GO
IF OBJECT_ID(N'[dbo].[PreferencePeriodJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PreferencePeriodJeu];
GO
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[TrainingPreferencesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrainingPreferencesSet];
GO
IF OBJECT_ID(N'[dbo].[StatusSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatusSet];
GO
IF OBJECT_ID(N'[dbo].[PaymentMethodSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentMethodSet];
GO
IF OBJECT_ID(N'[dbo].[DaySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DaySet];
GO
IF OBJECT_ID(N'[dbo].[BallLevelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BallLevelSet];
GO
IF OBJECT_ID(N'[dbo].[NewsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsSet];
GO
IF OBJECT_ID(N'[dbo].[AuthorizedTagsVersion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthorizedTagsVersion];
GO
IF OBJECT_ID(N'[dbo].[authorizedUserTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[authorizedUserTags];
GO
IF OBJECT_ID(N'[dbo].[LogEntry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogEntry];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[ProductQuantitySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductQuantitySet];
GO
IF OBJECT_ID(N'[dbo].[PaymentSemester]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentSemester];
GO
IF OBJECT_ID(N'[dbo].[PlayerCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayerCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SeasonJeu'
CREATE TABLE [dbo].[SeasonJeu] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'SemesterJeu'
CREATE TABLE [dbo].[SemesterJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [start] datetime  NOT NULL,
    [end] datetime  NOT NULL,
    [Season_ID] int  NULL
);
GO

-- Creating table 'PaymentJeu'
CREATE TABLE [dbo].[PaymentJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [amount] float  NOT NULL,
    [date] datetime  NOT NULL,
    [raison] nvarchar(max)  NOT NULL,
    [invalid] bit  NOT NULL,
    [comment] nvarchar(max)  NOT NULL,
    [Player_ID] int  NOT NULL,
    [PaymentMethod_Id] int  NOT NULL
);
GO

-- Creating table 'BadgeJeu'
CREATE TABLE [dbo].[BadgeJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [number] bigint  NOT NULL,
    [isEnabled] bit  NOT NULL,
    [isMaster] bit  NOT NULL,
    [forbidden] bit  NOT NULL,
    [Player_ID] int  NULL
);
GO

-- Creating table 'BookingAggregationJeu'
CREATE TABLE [dbo].[BookingAggregationJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookingJeu'
CREATE TABLE [dbo].[BookingJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [isSpecial] bit  NOT NULL,
    [start] datetime  NOT NULL,
    [end] datetime  NOT NULL,
    [creationDate] datetime  NOT NULL,
    [Filmed] bit  NOT NULL,
    [BookingAggregation_ID] int  NULL,
    [Court_ID] int  NOT NULL,
    [Player1_ID] int  NOT NULL,
    [Player2_ID] int  NULL
);
GO

-- Creating table 'CourtJeu'
CREATE TABLE [dbo].[CourtJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [number] nvarchar(max)  NOT NULL,
    [isCovered] bit  NOT NULL
);
GO

-- Creating table 'PlayerJeu'
CREATE TABLE [dbo].[PlayerJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [firstName] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL,
    [birthDate] datetime  NOT NULL,
    [ranking] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [street] nvarchar(max)  NOT NULL,
    [zipCode] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [phone1] nvarchar(max)  NOT NULL,
    [phone2] nvarchar(max)  NULL,
    [isEnabled] bit  NOT NULL,
    [passwordHash] nvarchar(max)  NOT NULL,
    [lastLogin] datetime  NULL,
    [licenceNumber] nvarchar(max)  NULL,
    [login] nvarchar(max)  NOT NULL,
    [salt] nvarchar(max)  NOT NULL,
    [passwordReset] nvarchar(max)  NULL,
    [passwordResetDemand] datetime  NULL,
    [Subscribed] bit  NULL,
    [Sex] bit  NOT NULL,
    [CanFilm] bit  NOT NULL,
    [Status_Id] int  NOT NULL,
    [BallLevel_Id] int  NULL
);
GO

-- Creating table 'PreferencePeriodJeu'
CREATE TABLE [dbo].[PreferencePeriodJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [beginningHour] int  NOT NULL,
    [endHour] int  NOT NULL,
    [beginningMin] int  NOT NULL,
    [endmin] int  NOT NULL,
    [Player_ID] int  NOT NULL,
    [Day_Id] int  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [categoryName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TrainingPreferencesSet'
CREATE TABLE [dbo].[TrainingPreferencesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [beginning] int  NOT NULL,
    [end] int  NOT NULL,
    [Player_ID] int  NOT NULL,
    [Day_Id] int  NOT NULL
);
GO

-- Creating table 'StatusSet'
CREATE TABLE [dbo].[StatusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [statusName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaymentMethodSet'
CREATE TABLE [dbo].[PaymentMethodSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [methodName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DaySet'
CREATE TABLE [dbo].[DaySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BallLevelSet'
CREATE TABLE [dbo].[BallLevelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ballName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NewsSet'
CREATE TABLE [dbo].[NewsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [PublishDate] datetime  NOT NULL,
    [Visibility] bit  NOT NULL
);
GO

-- Creating table 'AuthorizedTagsVersion'
CREATE TABLE [dbo].[AuthorizedTagsVersion] (
    [versionNumber] int  NOT NULL,
    [lastUpdated] datetime  NOT NULL
);
GO

-- Creating table 'authorizedUserTags'
CREATE TABLE [dbo].[authorizedUserTags] (
    [number] bigint  NOT NULL
);
GO

-- Creating table 'LogEntry'
CREATE TABLE [dbo].[LogEntry] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [timestamp] datetime  NOT NULL,
    [reader_name] nvarchar(50)  NOT NULL,
    [tag_number] int  NOT NULL,
    [reader_response] int  NOT NULL,
    [Player_ID] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'ProductQuantitySet'
CREATE TABLE [dbo].[ProductQuantitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [Payment_ID] int  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- Creating table 'PaymentSemester'
CREATE TABLE [dbo].[PaymentSemester] (
    [Payment_ID] int  NOT NULL,
    [Semester_ID] int  NOT NULL
);
GO

-- Creating table 'PlayerCategory'
CREATE TABLE [dbo].[PlayerCategory] (
    [Player_ID] int  NOT NULL,
    [Category_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'SeasonJeu'
ALTER TABLE [dbo].[SeasonJeu]
ADD CONSTRAINT [PK_SeasonJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SemesterJeu'
ALTER TABLE [dbo].[SemesterJeu]
ADD CONSTRAINT [PK_SemesterJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PaymentJeu'
ALTER TABLE [dbo].[PaymentJeu]
ADD CONSTRAINT [PK_PaymentJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BadgeJeu'
ALTER TABLE [dbo].[BadgeJeu]
ADD CONSTRAINT [PK_BadgeJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookingAggregationJeu'
ALTER TABLE [dbo].[BookingAggregationJeu]
ADD CONSTRAINT [PK_BookingAggregationJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BookingJeu'
ALTER TABLE [dbo].[BookingJeu]
ADD CONSTRAINT [PK_BookingJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CourtJeu'
ALTER TABLE [dbo].[CourtJeu]
ADD CONSTRAINT [PK_CourtJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PlayerJeu'
ALTER TABLE [dbo].[PlayerJeu]
ADD CONSTRAINT [PK_PlayerJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PreferencePeriodJeu'
ALTER TABLE [dbo].[PreferencePeriodJeu]
ADD CONSTRAINT [PK_PreferencePeriodJeu]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainingPreferencesSet'
ALTER TABLE [dbo].[TrainingPreferencesSet]
ADD CONSTRAINT [PK_TrainingPreferencesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatusSet'
ALTER TABLE [dbo].[StatusSet]
ADD CONSTRAINT [PK_StatusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentMethodSet'
ALTER TABLE [dbo].[PaymentMethodSet]
ADD CONSTRAINT [PK_PaymentMethodSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DaySet'
ALTER TABLE [dbo].[DaySet]
ADD CONSTRAINT [PK_DaySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BallLevelSet'
ALTER TABLE [dbo].[BallLevelSet]
ADD CONSTRAINT [PK_BallLevelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NewsSet'
ALTER TABLE [dbo].[NewsSet]
ADD CONSTRAINT [PK_NewsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [versionNumber], [lastUpdated] in table 'AuthorizedTagsVersion'
ALTER TABLE [dbo].[AuthorizedTagsVersion]
ADD CONSTRAINT [PK_AuthorizedTagsVersion]
    PRIMARY KEY CLUSTERED ([versionNumber], [lastUpdated] ASC);
GO

-- Creating primary key on [number] in table 'authorizedUserTags'
ALTER TABLE [dbo].[authorizedUserTags]
ADD CONSTRAINT [PK_authorizedUserTags]
    PRIMARY KEY CLUSTERED ([number] ASC);
GO

-- Creating primary key on [ID] in table 'LogEntry'
ALTER TABLE [dbo].[LogEntry]
ADD CONSTRAINT [PK_LogEntry]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductQuantitySet'
ALTER TABLE [dbo].[ProductQuantitySet]
ADD CONSTRAINT [PK_ProductQuantitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Payment_ID], [Semester_ID] in table 'PaymentSemester'
ALTER TABLE [dbo].[PaymentSemester]
ADD CONSTRAINT [PK_PaymentSemester]
    PRIMARY KEY CLUSTERED ([Payment_ID], [Semester_ID] ASC);
GO

-- Creating primary key on [Player_ID], [Category_Id] in table 'PlayerCategory'
ALTER TABLE [dbo].[PlayerCategory]
ADD CONSTRAINT [PK_PlayerCategory]
    PRIMARY KEY CLUSTERED ([Player_ID], [Category_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BookingAggregation_ID] in table 'BookingJeu'
ALTER TABLE [dbo].[BookingJeu]
ADD CONSTRAINT [FK_BookingAggregationBooking]
    FOREIGN KEY ([BookingAggregation_ID])
    REFERENCES [dbo].[BookingAggregationJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingAggregationBooking'
CREATE INDEX [IX_FK_BookingAggregationBooking]
ON [dbo].[BookingJeu]
    ([BookingAggregation_ID]);
GO

-- Creating foreign key on [Court_ID] in table 'BookingJeu'
ALTER TABLE [dbo].[BookingJeu]
ADD CONSTRAINT [FK_BookingCourt]
    FOREIGN KEY ([Court_ID])
    REFERENCES [dbo].[CourtJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingCourt'
CREATE INDEX [IX_FK_BookingCourt]
ON [dbo].[BookingJeu]
    ([Court_ID]);
GO

-- Creating foreign key on [Player_ID] in table 'BadgeJeu'
ALTER TABLE [dbo].[BadgeJeu]
ADD CONSTRAINT [FK_BadgePlayer]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BadgePlayer'
CREATE INDEX [IX_FK_BadgePlayer]
ON [dbo].[BadgeJeu]
    ([Player_ID]);
GO

-- Creating foreign key on [Player_ID] in table 'PreferencePeriodJeu'
ALTER TABLE [dbo].[PreferencePeriodJeu]
ADD CONSTRAINT [FK_PreferencePeriodPlayer]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PreferencePeriodPlayer'
CREATE INDEX [IX_FK_PreferencePeriodPlayer]
ON [dbo].[PreferencePeriodJeu]
    ([Player_ID]);
GO

-- Creating foreign key on [Player1_ID] in table 'BookingJeu'
ALTER TABLE [dbo].[BookingJeu]
ADD CONSTRAINT [FK_PlayerBooking]
    FOREIGN KEY ([Player1_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerBooking'
CREATE INDEX [IX_FK_PlayerBooking]
ON [dbo].[BookingJeu]
    ([Player1_ID]);
GO

-- Creating foreign key on [Player_ID] in table 'PaymentJeu'
ALTER TABLE [dbo].[PaymentJeu]
ADD CONSTRAINT [FK_PlayerPayment]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerPayment'
CREATE INDEX [IX_FK_PlayerPayment]
ON [dbo].[PaymentJeu]
    ([Player_ID]);
GO

-- Creating foreign key on [Payment_ID] in table 'PaymentSemester'
ALTER TABLE [dbo].[PaymentSemester]
ADD CONSTRAINT [FK_PaymentSemester_Payment]
    FOREIGN KEY ([Payment_ID])
    REFERENCES [dbo].[PaymentJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Semester_ID] in table 'PaymentSemester'
ALTER TABLE [dbo].[PaymentSemester]
ADD CONSTRAINT [FK_PaymentSemester_Semester]
    FOREIGN KEY ([Semester_ID])
    REFERENCES [dbo].[SemesterJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentSemester_Semester'
CREATE INDEX [IX_FK_PaymentSemester_Semester]
ON [dbo].[PaymentSemester]
    ([Semester_ID]);
GO

-- Creating foreign key on [Player_ID] in table 'PlayerCategory'
ALTER TABLE [dbo].[PlayerCategory]
ADD CONSTRAINT [FK_PlayerCategory_Player]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Category_Id] in table 'PlayerCategory'
ALTER TABLE [dbo].[PlayerCategory]
ADD CONSTRAINT [FK_PlayerCategory_Category]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerCategory_Category'
CREATE INDEX [IX_FK_PlayerCategory_Category]
ON [dbo].[PlayerCategory]
    ([Category_Id]);
GO

-- Creating foreign key on [Player_ID] in table 'TrainingPreferencesSet'
ALTER TABLE [dbo].[TrainingPreferencesSet]
ADD CONSTRAINT [FK_PlayerTrainingPreferences]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerTrainingPreferences'
CREATE INDEX [IX_FK_PlayerTrainingPreferences]
ON [dbo].[TrainingPreferencesSet]
    ([Player_ID]);
GO

-- Creating foreign key on [Status_Id] in table 'PlayerJeu'
ALTER TABLE [dbo].[PlayerJeu]
ADD CONSTRAINT [FK_PlayerStatus]
    FOREIGN KEY ([Status_Id])
    REFERENCES [dbo].[StatusSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerStatus'
CREATE INDEX [IX_FK_PlayerStatus]
ON [dbo].[PlayerJeu]
    ([Status_Id]);
GO

-- Creating foreign key on [PaymentMethod_Id] in table 'PaymentJeu'
ALTER TABLE [dbo].[PaymentJeu]
ADD CONSTRAINT [FK_PaymentMethodPayment]
    FOREIGN KEY ([PaymentMethod_Id])
    REFERENCES [dbo].[PaymentMethodSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentMethodPayment'
CREATE INDEX [IX_FK_PaymentMethodPayment]
ON [dbo].[PaymentJeu]
    ([PaymentMethod_Id]);
GO

-- Creating foreign key on [Day_Id] in table 'PreferencePeriodJeu'
ALTER TABLE [dbo].[PreferencePeriodJeu]
ADD CONSTRAINT [FK_DayPreferencePeriod]
    FOREIGN KEY ([Day_Id])
    REFERENCES [dbo].[DaySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DayPreferencePeriod'
CREATE INDEX [IX_FK_DayPreferencePeriod]
ON [dbo].[PreferencePeriodJeu]
    ([Day_Id]);
GO

-- Creating foreign key on [Day_Id] in table 'TrainingPreferencesSet'
ALTER TABLE [dbo].[TrainingPreferencesSet]
ADD CONSTRAINT [FK_DayTrainingPreferences]
    FOREIGN KEY ([Day_Id])
    REFERENCES [dbo].[DaySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DayTrainingPreferences'
CREATE INDEX [IX_FK_DayTrainingPreferences]
ON [dbo].[TrainingPreferencesSet]
    ([Day_Id]);
GO

-- Creating foreign key on [BallLevel_Id] in table 'PlayerJeu'
ALTER TABLE [dbo].[PlayerJeu]
ADD CONSTRAINT [FK_PlayerBallLevel]
    FOREIGN KEY ([BallLevel_Id])
    REFERENCES [dbo].[BallLevelSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerBallLevel'
CREATE INDEX [IX_FK_PlayerBallLevel]
ON [dbo].[PlayerJeu]
    ([BallLevel_Id]);
GO

-- Creating foreign key on [Player2_ID] in table 'BookingJeu'
ALTER TABLE [dbo].[BookingJeu]
ADD CONSTRAINT [FK_BookingPlayer2]
    FOREIGN KEY ([Player2_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingPlayer2'
CREATE INDEX [IX_FK_BookingPlayer2]
ON [dbo].[BookingJeu]
    ([Player2_ID]);
GO

-- Creating foreign key on [Season_ID] in table 'SemesterJeu'
ALTER TABLE [dbo].[SemesterJeu]
ADD CONSTRAINT [FK_SeasonSemester]
    FOREIGN KEY ([Season_ID])
    REFERENCES [dbo].[SeasonJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeasonSemester'
CREATE INDEX [IX_FK_SeasonSemester]
ON [dbo].[SemesterJeu]
    ([Season_ID]);
GO

-- Creating foreign key on [Player_ID] in table 'LogEntry'
ALTER TABLE [dbo].[LogEntry]
ADD CONSTRAINT [FK_LogEntrynew_PlayerJeu]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LogEntrynew_PlayerJeu'
CREATE INDEX [IX_FK_LogEntrynew_PlayerJeu]
ON [dbo].[LogEntry]
    ([Player_ID]);
GO

-- Creating foreign key on [Payment_ID] in table 'ProductQuantitySet'
ALTER TABLE [dbo].[ProductQuantitySet]
ADD CONSTRAINT [FK_PaymentProductQuantity]
    FOREIGN KEY ([Payment_ID])
    REFERENCES [dbo].[PaymentJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentProductQuantity'
CREATE INDEX [IX_FK_PaymentProductQuantity]
ON [dbo].[ProductQuantitySet]
    ([Payment_ID]);
GO

-- Creating foreign key on [Product_Id] in table 'ProductQuantitySet'
ALTER TABLE [dbo].[ProductQuantitySet]
ADD CONSTRAINT [FK_ProductQuantityProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductQuantityProduct'
CREATE INDEX [IX_FK_ProductQuantityProduct]
ON [dbo].[ProductQuantitySet]
    ([Product_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------