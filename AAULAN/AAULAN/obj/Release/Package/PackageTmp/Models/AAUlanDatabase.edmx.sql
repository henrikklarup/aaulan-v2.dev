
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2013 19:45:15
-- Generated from EDMX file: C:\Users\Henrik Klarup\documents\visual studio 2012\Projects\AAULAN\AAULAN\Models\AAUlanDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AAULAN];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Event_Games]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_Games];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_LAN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_LAN];
GO
IF OBJECT_ID(N'[dbo].[FK_SeatSeatingPlan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Seat] DROP CONSTRAINT [FK_SeatSeatingPlan];
GO
IF OBJECT_ID(N'[dbo].[FK_SeatingPlanLAN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeatingPlan] DROP CONSTRAINT [FK_SeatingPlanLAN];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSeat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Seat] DROP CONSTRAINT [FK_UserSeat];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamMemberUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamMemberSet] DROP CONSTRAINT [FK_TeamMemberUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamMemberTeam_TeamMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamMemberTeam] DROP CONSTRAINT [FK_TeamMemberTeam_TeamMember];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamMemberTeam_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamMemberTeam] DROP CONSTRAINT [FK_TeamMemberTeam_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_EventTeam_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventTeam] DROP CONSTRAINT [FK_EventTeam_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventTeam_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventTeam] DROP CONSTRAINT [FK_EventTeam_Team];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event];
GO
IF OBJECT_ID(N'[dbo].[Games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Games];
GO
IF OBJECT_ID(N'[dbo].[LAN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LAN];
GO
IF OBJECT_ID(N'[dbo].[Mad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mad];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Seat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Seat];
GO
IF OBJECT_ID(N'[dbo].[SeatingPlan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeatingPlan];
GO
IF OBJECT_ID(N'[dbo].[PizzaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PizzaSet];
GO
IF OBJECT_ID(N'[dbo].[TeamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamSet];
GO
IF OBJECT_ID(N'[dbo].[TeamMemberSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamMemberSet];
GO
IF OBJECT_ID(N'[dbo].[TeamMemberTeam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamMemberTeam];
GO
IF OBJECT_ID(N'[dbo].[EventTeam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventTeam];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Event'
CREATE TABLE [dbo].[Event] (
    [StartTime] datetime  NOT NULL,
    [Name] nchar(50)  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [ID] int  NOT NULL,
    [LANID] int  NOT NULL,
    [GAMEID] int  NULL,
    [Description] nchar(300)  NULL,
    [Rules] nchar(300)  NULL,
    [FoodID] int  NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [ID] int  NOT NULL,
    [Description] nchar(300)  NOT NULL,
    [DL_Link] nchar(300)  NULL,
    [Name] nchar(300)  NOT NULL
);
GO

-- Creating table 'LAN'
CREATE TABLE [dbo].[LAN] (
    [ID] int  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [Description] nchar(300)  NULL,
    [Location] nchar(100)  NULL
);
GO

-- Creating table 'Mad'
CREATE TABLE [dbo].[Mad] (
    [Name] nchar(25)  NOT NULL,
    [Paid] bit  NOT NULL,
    [Note] nchar(50)  NULL,
    [Number] int  NOT NULL,
    [ID] int  NOT NULL,
    [EVENTID] int  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Username] nchar(25)  NOT NULL,
    [Password] nchar(50)  NOT NULL,
    [Role] nchar(15)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Seat'
CREATE TABLE [dbo].[Seat] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Taken] bit  NOT NULL,
    [SeatingPlanId] int  NOT NULL,
    [User_Username] nchar(25)  NULL
);
GO

-- Creating table 'SeatingPlan'
CREATE TABLE [dbo].[SeatingPlan] (
    [Id] int  NOT NULL,
    [LANID] int  NOT NULL
);
GO

-- Creating table 'PizzaSet'
CREATE TABLE [dbo].[PizzaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] int  NOT NULL,
    [Price] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'TeamSet'
CREATE TABLE [dbo].[TeamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [StandaloneTeam] bit  NOT NULL
);
GO

-- Creating table 'TeamMemberSet'
CREATE TABLE [dbo].[TeamMemberSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TeamId] int  NOT NULL,
    [User_Username] nchar(25)  NOT NULL
);
GO

-- Creating table 'TeamMemberTeam'
CREATE TABLE [dbo].[TeamMemberTeam] (
    [TeamMember_Id] int  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- Creating table 'EventTeam'
CREATE TABLE [dbo].[EventTeam] (
    [Event_ID] int  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Event'
ALTER TABLE [dbo].[Event]
ADD CONSTRAINT [PK_Event]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LAN'
ALTER TABLE [dbo].[LAN]
ADD CONSTRAINT [PK_LAN]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Mad'
ALTER TABLE [dbo].[Mad]
ADD CONSTRAINT [PK_Mad]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Username] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [Id] in table 'Seat'
ALTER TABLE [dbo].[Seat]
ADD CONSTRAINT [PK_Seat]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SeatingPlan'
ALTER TABLE [dbo].[SeatingPlan]
ADD CONSTRAINT [PK_SeatingPlan]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PizzaSet'
ALTER TABLE [dbo].[PizzaSet]
ADD CONSTRAINT [PK_PizzaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamSet'
ALTER TABLE [dbo].[TeamSet]
ADD CONSTRAINT [PK_TeamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamMemberSet'
ALTER TABLE [dbo].[TeamMemberSet]
ADD CONSTRAINT [PK_TeamMemberSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TeamMember_Id], [Team_Id] in table 'TeamMemberTeam'
ALTER TABLE [dbo].[TeamMemberTeam]
ADD CONSTRAINT [PK_TeamMemberTeam]
    PRIMARY KEY NONCLUSTERED ([TeamMember_Id], [Team_Id] ASC);
GO

-- Creating primary key on [Event_ID], [Team_Id] in table 'EventTeam'
ALTER TABLE [dbo].[EventTeam]
ADD CONSTRAINT [PK_EventTeam]
    PRIMARY KEY NONCLUSTERED ([Event_ID], [Team_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GAMEID] in table 'Event'
ALTER TABLE [dbo].[Event]
ADD CONSTRAINT [FK_Event_Games]
    FOREIGN KEY ([GAMEID])
    REFERENCES [dbo].[Games]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_Games'
CREATE INDEX [IX_FK_Event_Games]
ON [dbo].[Event]
    ([GAMEID]);
GO

-- Creating foreign key on [LANID] in table 'Event'
ALTER TABLE [dbo].[Event]
ADD CONSTRAINT [FK_Event_LAN]
    FOREIGN KEY ([LANID])
    REFERENCES [dbo].[LAN]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_LAN'
CREATE INDEX [IX_FK_Event_LAN]
ON [dbo].[Event]
    ([LANID]);
GO

-- Creating foreign key on [SeatingPlanId] in table 'Seat'
ALTER TABLE [dbo].[Seat]
ADD CONSTRAINT [FK_SeatSeatingPlan]
    FOREIGN KEY ([SeatingPlanId])
    REFERENCES [dbo].[SeatingPlan]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeatSeatingPlan'
CREATE INDEX [IX_FK_SeatSeatingPlan]
ON [dbo].[Seat]
    ([SeatingPlanId]);
GO

-- Creating foreign key on [LANID] in table 'SeatingPlan'
ALTER TABLE [dbo].[SeatingPlan]
ADD CONSTRAINT [FK_SeatingPlanLAN]
    FOREIGN KEY ([LANID])
    REFERENCES [dbo].[LAN]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SeatingPlanLAN'
CREATE INDEX [IX_FK_SeatingPlanLAN]
ON [dbo].[SeatingPlan]
    ([LANID]);
GO

-- Creating foreign key on [User_Username] in table 'Seat'
ALTER TABLE [dbo].[Seat]
ADD CONSTRAINT [FK_UserSeat]
    FOREIGN KEY ([User_Username])
    REFERENCES [dbo].[User]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSeat'
CREATE INDEX [IX_FK_UserSeat]
ON [dbo].[Seat]
    ([User_Username]);
GO

-- Creating foreign key on [User_Username] in table 'TeamMemberSet'
ALTER TABLE [dbo].[TeamMemberSet]
ADD CONSTRAINT [FK_TeamMemberUser]
    FOREIGN KEY ([User_Username])
    REFERENCES [dbo].[User]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamMemberUser'
CREATE INDEX [IX_FK_TeamMemberUser]
ON [dbo].[TeamMemberSet]
    ([User_Username]);
GO

-- Creating foreign key on [TeamMember_Id] in table 'TeamMemberTeam'
ALTER TABLE [dbo].[TeamMemberTeam]
ADD CONSTRAINT [FK_TeamMemberTeam_TeamMember]
    FOREIGN KEY ([TeamMember_Id])
    REFERENCES [dbo].[TeamMemberSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Team_Id] in table 'TeamMemberTeam'
ALTER TABLE [dbo].[TeamMemberTeam]
ADD CONSTRAINT [FK_TeamMemberTeam_Team]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamMemberTeam_Team'
CREATE INDEX [IX_FK_TeamMemberTeam_Team]
ON [dbo].[TeamMemberTeam]
    ([Team_Id]);
GO

-- Creating foreign key on [Event_ID] in table 'EventTeam'
ALTER TABLE [dbo].[EventTeam]
ADD CONSTRAINT [FK_EventTeam_Event]
    FOREIGN KEY ([Event_ID])
    REFERENCES [dbo].[Event]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Team_Id] in table 'EventTeam'
ALTER TABLE [dbo].[EventTeam]
ADD CONSTRAINT [FK_EventTeam_Team]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[TeamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventTeam_Team'
CREATE INDEX [IX_FK_EventTeam_Team]
ON [dbo].[EventTeam]
    ([Team_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------