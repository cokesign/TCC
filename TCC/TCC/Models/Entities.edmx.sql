
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2019 18:28:10
-- Generated from EDMX file: C:\DEV\TCC\TCC\TCC\Models\Entities.edmx
-- --------------------------------------------------

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'Plant'
CREATE TABLE [dbo].[Plant] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [Active] bit  NOT NULL,
    [IdCategory] int  NULL
);
GO

-- Creating table 'Sensor'
CREATE TABLE [dbo].[Sensor] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [Age] int  NOT NULL,
    [Active] bit  NOT NULL
);
GO

CREATE TABLE [dbo].[Configuration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Active] BIT NOT NULL,
	[Interval] INT
);
GO

-- Creating table 'UserPlant'
CREATE TABLE [dbo].[UserPlant] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReadingTime] datetime  NOT NULL,
    [Active] bit  NOT NULL,
    [IdPlant] int  NOT NULL,
    [IdSensor] int  NOT NULL,
    [IdUser] int  NOT NULL,
    [Humidity] decimal(18,3)  NULL
);
GO

-- Creating table 'Configuration'
CREATE TABLE [dbo].[Configuration] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SearchTime] BIGINT  NOT NULL,
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Plant'
ALTER TABLE [dbo].[Plant]
ADD CONSTRAINT [PK_Plant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sensor'
ALTER TABLE [dbo].[Sensor]
ADD CONSTRAINT [PK_Sensor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserPlant'
ALTER TABLE [dbo].[UserPlant]
ADD CONSTRAINT [PK_UserPlant]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category_Id] in table 'Plant'
ALTER TABLE [dbo].[Plant]
ADD CONSTRAINT [FK__Plant__IdCategory__4F7CD00D]
    FOREIGN KEY ([IdCategory])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Plant__IdCategor__4F7CD00D'
CREATE INDEX [IX_FK__Plant__IdCategor__4F7CD00D]
ON [dbo].[Plant]
    ([IdCategory]);
GO

-- Creating foreign key on [Plant_Id] in table 'UserPlant'
ALTER TABLE [dbo].[UserPlant]
ADD CONSTRAINT [FK__UserPlant__IdPlant__52593CB8]
    FOREIGN KEY ([IdPlant])
    REFERENCES [dbo].[Plant]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserPlant__IdPla__52593CB8'
CREATE INDEX [IX_FK__UserPlant__IdPlant__52593CB8]
ON [dbo].[UserPlant]
    ([IdPlant]);
GO

-- Creating foreign key on [Sensor_Id] in table 'UserPlant'
ALTER TABLE [dbo].[UserPlant]
ADD CONSTRAINT [FK__UserPlant__IdSen__5441852A]
    FOREIGN KEY ([IdSensor])
    REFERENCES [dbo].[Sensor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserPlant__IdSen__5441852A'
CREATE INDEX [IX_FK__UserPlant__IdSen__5441852A]
ON [dbo].[UserPlant]
    ([IdSensor]);
GO

-- Creating foreign key on [User_Id] in table 'UserPlant'
ALTER TABLE [dbo].[UserPlant]
ADD CONSTRAINT [FK__UserPlant__IdUse__534D60F1]
    FOREIGN KEY (IdUser)
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserPlant__IdUse__534D60F1'
CREATE INDEX [IX_FK__UserPlant__IdUse__534D60F1]
ON [dbo].[UserPlant]
    ([IdUser]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------