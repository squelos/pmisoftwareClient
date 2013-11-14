
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2013 17:06:02
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SeasonJeu'
CREATE TABLE [dbo].[SeasonJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [start] datetime  NOT NULL,
    [end] datetime  NOT NULL
);
GO

-- Creating table 'SemesterJeu'
CREATE TABLE [dbo].[SemesterJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [start] datetime  NOT NULL,
    [end] datetime  NOT NULL,
    [Season_ID] int  NOT NULL
);
GO

-- Creating table 'PaymentJeu'
CREATE TABLE [dbo].[PaymentJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [method] int  NOT NULL,
    [amount] float  NOT NULL,
    [date] datetime  NOT NULL,
    [Player_ID] int  NOT NULL
);
GO

-- Creating table 'BadgeJeu'
CREATE TABLE [dbo].[BadgeJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [number] int  NOT NULL,
    [hash] int  NOT NULL,
    [isEnabled] bit  NOT NULL,
    [isMaster] bit  NOT NULL,
    [Player_ID] int  NULL
);
GO

-- Creating table 'BookingAggregationJeu'
CREATE TABLE [dbo].[BookingAggregationJeu] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'BookingJeu'
CREATE TABLE [dbo].[BookingJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [isSpecial] bit  NOT NULL,
    [start] datetime  NOT NULL,
    [end] datetime  NOT NULL,
    [BookingAggregation_ID] int  NULL,
    [Court_ID] int  NOT NULL,
    [Player_ID] int  NOT NULL
);
GO

-- Creating table 'CourtJeu'
CREATE TABLE [dbo].[CourtJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [number] int  NOT NULL,
    [isCovered] bit  NOT NULL
);
GO

-- Creating table 'OpeningJeu'
CREATE TABLE [dbo].[OpeningJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [time] datetime  NOT NULL,
    [Court_ID] int  NULL,
    [Badge_ID] int  NOT NULL
);
GO

-- Creating table 'PlayerJeu'
CREATE TABLE [dbo].[PlayerJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [firstName] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL,
    [birthDate] datetime  NOT NULL,
    [level] int  NOT NULL,
    [ranking] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [street] nvarchar(max)  NOT NULL,
    [zipCode] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [phone1] nvarchar(max)  NOT NULL,
    [phone2] nvarchar(max)  NOT NULL,
    [status] int  NOT NULL,
    [isEnabled] bit  NOT NULL,
    [passwordHash] nvarchar(max)  NOT NULL,
    [lastLogin] datetime  NOT NULL,
    [licenceNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PreferencePeriodJeu'
CREATE TABLE [dbo].[PreferencePeriodJeu] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [beginningHour] int  NOT NULL,
    [endHour] int  NOT NULL,
    [beginningMin] int  NOT NULL,
    [endmin] int  NOT NULL,
    [Player_ID] int  NOT NULL
);
GO

-- Creating table 'PaymentSemester'
CREATE TABLE [dbo].[PaymentSemester] (
    [Payment_ID] int  NOT NULL,
    [Semester_ID] int  NOT NULL
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

-- Creating primary key on [ID] in table 'OpeningJeu'
ALTER TABLE [dbo].[OpeningJeu]
ADD CONSTRAINT [PK_OpeningJeu]
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

-- Creating primary key on [Payment_ID], [Semester_ID] in table 'PaymentSemester'
ALTER TABLE [dbo].[PaymentSemester]
ADD CONSTRAINT [PK_PaymentSemester]
    PRIMARY KEY CLUSTERED ([Payment_ID], [Semester_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [Court_ID] in table 'OpeningJeu'
ALTER TABLE [dbo].[OpeningJeu]
ADD CONSTRAINT [FK_CourtOpening]
    FOREIGN KEY ([Court_ID])
    REFERENCES [dbo].[CourtJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CourtOpening'
CREATE INDEX [IX_FK_CourtOpening]
ON [dbo].[OpeningJeu]
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

-- Creating foreign key on [Player_ID] in table 'BookingJeu'
ALTER TABLE [dbo].[BookingJeu]
ADD CONSTRAINT [FK_PlayerBooking]
    FOREIGN KEY ([Player_ID])
    REFERENCES [dbo].[PlayerJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerBooking'
CREATE INDEX [IX_FK_PlayerBooking]
ON [dbo].[BookingJeu]
    ([Player_ID]);
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

-- Creating foreign key on [Badge_ID] in table 'OpeningJeu'
ALTER TABLE [dbo].[OpeningJeu]
ADD CONSTRAINT [FK_OpeningBadge]
    FOREIGN KEY ([Badge_ID])
    REFERENCES [dbo].[BadgeJeu]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OpeningBadge'
CREATE INDEX [IX_FK_OpeningBadge]
ON [dbo].[OpeningJeu]
    ([Badge_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------