
/**************************** Table [dbo].[roles] ************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/***************** Table [dbo].[UserRoles] *******************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/***************  Table [dbo].[Users]  ***********************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/*************************** Leave Types **********************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveTypes]( 
	[LeaveTypeId] [int] IDENTITY(1,1) NOT NULL, 
	[LeaveTypeName] [nvarchar](max) NOT NULL, 
    [MaxDaysPerYear] [int] NOT NULL
 CONSTRAINT [PK_LeaveTypes] PRIMARY KEY CLUSTERED  
(
	[LeaveTypeId] ASC 
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/********** EmployeeLeaves ***********/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeLeaves](
    [EmployeeLeaveId] [int] IDENTITY(1,1) NOT NULL, 
    [Id] [int] NOT NULL,  -- Foreign key to Employees table
    [LeaveTypeId] [int] NOT NULL, -- Foreign key to LeaveTypes table
    [LeaveStartDate] [date] NOT NULL,
    [LeaveEndDate] [date] NOT NULL,
    [DaysTaken] [int] NOT NULL,
 CONSTRAINT [PK_EmployeeLeaves] PRIMARY KEY CLUSTERED  
(
    [EmployeeLeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [FK_EmployeeLeaves_Employees] FOREIGN KEY([Id])
 REFERENCES [dbo].[Users]([Id]),
 CONSTRAINT [FK_EmployeeLeaves_LeaveTypes] FOREIGN KEY([LeaveTypeId])
 REFERENCES [dbo].[LeaveTypes]([LeaveTypeId])
) ON [PRIMARY]
GO


/*********************** leave balance *************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeLeaveBalance](
    [EmployeeLeaveBalanceId] [int] IDENTITY(1,1) NOT NULL, 
    [Id] [int] NOT NULL,  -- Foreign key to User table
    [LeaveTypeId] [int] NOT NULL, -- Foreign key to LeaveTypes table
    [AvailableDays] [int] NOT NULL, -- Days left for the specific leave type
 CONSTRAINT [PK_EmployeeLeaveBalance] PRIMARY KEY CLUSTERED  
(
    [EmployeeLeaveBalanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [FK_EmployeeLeaveBalance_Employees] FOREIGN KEY([Id])
 REFERENCES [dbo].[Users]([Id]),
 CONSTRAINT [FK_EmployeeLeaveBalance_LeaveTypes] FOREIGN KEY([LeaveTypeId])
 REFERENCES [dbo].[LeaveTypes]([LeaveTypeId])
) ON [PRIMARY]
GO











/************************       Constraints     *******************************/
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO



/* Seed ***/


GO
SET IDENTITY_INSERT [dbo].[Roles] ON
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [PhoneNumber], [EmailConfirmed], [CreatedDate]) VALUES (1, N'Admin', N'admin@gmail.com', N'$2a$11$NulP7XYlUOjMELsrj/me0uO/1OIQiHnMl.DVUk7LgB5SqjyWSas5K', N'9876543210', 0, CAST(N'2024-09-24T11:03:11.457' AS DateTime))
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [PhoneNumber], [EmailConfirmed], [CreatedDate]) VALUES (2, N'User', N'user@gmail.com', N'$2a$11$oNn03spA.XrRD8shVW9Z2.72X6ljCU/S6fjOZOTybNVFLtEr6Kb5y', N'9876543210', 0, CAST(N'2024-09-24T11:05:19.160' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)
GO




/******************** Stored Procedure **************************/
CREATE PROCEDURE InitializeLeaveBalance
    @ID INT
AS
BEGIN
    -- Insert leave balances for the new employee from LeaveTypes
    INSERT INTO [dbo].[EmployeeLeaveBalance] ([Id], [LeaveTypeId], [AvailableDays])
    SELECT @ID, [LeaveTypeId], [MaxDaysPerYear]
    FROM [dbo].[LeaveTypes];
END
GO


/***************************** Trigger ***************************************/
CREATE TRIGGER UpdateLeaveBalance
ON [dbo].[EmployeeLeaves]
AFTER INSERT
AS
BEGIN
    -- Deduct leave days from the EmployeeLeaveBalance table
    UPDATE ELB
    SET ELB.[AvailableDays] = ELB.[AvailableDays] - I.[DaysTaken]
    FROM [dbo].[EmployeeLeaveBalance] ELB
    INNER JOIN inserted I ON ELB.[ID] = I.[ID] 
                           AND ELB.[LeaveTypeId] = I.[LeaveTypeId];
END
GO

