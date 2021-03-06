USE [AWenDB] GO
/****** Object:  Table [dbo].[TB_TM_TaskLog]    Script Date: 04/17/2018 16:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TM_TaskLog](
	[TaskLogId] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[TaskName] [nvarchar](255) NULL,
	[ExecutionTime] [datetime] NULL,
	[ExecutionDuration] [decimal](18, 2) NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[RunLog] [text] NULL,
	[IsDelete] [int] NOT NULL,
 CONSTRAINT [PK_TB_TM_TaskLog] PRIMARY KEY CLUSTERED 
(
	[TaskLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_TM_TaskLog] ON
INSERT [dbo].[TB_TM_TaskLog] ([TaskLogId], [TaskId], [TaskName], [ExecutionTime], [ExecutionDuration], [CreatedDateTime], [RunLog], [IsDelete])
	VALUES (515, 7, N'Exe程序', CAST(0x0000A8C5010B5580 AS datetime), CAST(8.62 AS decimal(18, 2)), CAST(0x0000A8C5010B5F9E AS datetime), N'[Extend_Exe_Return:agr1
,Extend_Exe_Error:
未经处理的异常:  System.Exception: errotr
   在 ExeTest.Program.Main(String[] args)
]', 0)
INSERT [dbo].[TB_TM_TaskLog] ([TaskLogId], [TaskId], [TaskName], [ExecutionTime], [ExecutionDuration], [CreatedDateTime], [RunLog], [IsDelete])
	VALUES (516, 8, N'Url程序', CAST(0x0000A8C5010B6138 AS datetime), CAST(0.01 AS decimal(18, 2)), CAST(0x0000A8C5010B6157 AS datetime), N'[Extend_Url_Return:KEY:KEY1--WXC:wuxincao--WWD:wangwending--61

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>

</title></head>
<body>
    <form method="post" action="./WebForm1.aspx" id="form1">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUKLTEzNDM3NzkxOWRkWnW4wkp5fWh1dKnGQBB/mF6eQKeVcKzOfL15F4kxt+k=" />

<input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="C687F31A" />
    <div>
    
    </div>
    </form>
</body>
</html>
]', 0)
INSERT [dbo].[TB_TM_TaskLog] ([TaskLogId], [TaskId], [TaskName], [ExecutionTime], [ExecutionDuration], [CreatedDateTime], [RunLog], [IsDelete])
	VALUES (517, 7, N'Exe程序', CAST(0x0000A8C5010B6138 AS datetime), CAST(4.18 AS decimal(18, 2)), CAST(0x0000A8C5010B6622 AS datetime), N'[Extend_Exe_Return:agr1
,Extend_Exe_Error:
未经处理的异常:  System.Exception: errotr
   在 ExeTest.Program.Main(String[] args)
]', 0)
INSERT [dbo].[TB_TM_TaskLog] ([TaskLogId], [TaskId], [TaskName], [ExecutionTime], [ExecutionDuration], [CreatedDateTime], [RunLog], [IsDelete])
	VALUES (518, 8, N'Url程序', CAST(0x0000A8C5010B6CF0 AS datetime), CAST(0.00 AS decimal(18, 2)), CAST(0x0000A8C5010B6D00 AS datetime), N'[Extend_Url_Return:KEY:KEY1--WXC:wuxincao--WWD:wangwending--62

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>

</title></head>
<body>
    <form method="post" action="./WebForm1.aspx" id="form1">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwUKLTEzNDM3NzkxOWRkWnW4wkp5fWh1dKnGQBB/mF6eQKeVcKzOfL15F4kxt+k=" />

<input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="C687F31A" />
    <div>
    
    </div>
    </form>
</body>
</html>
]', 0)
INSERT [dbo].[TB_TM_TaskLog] ([TaskLogId], [TaskId], [TaskName], [ExecutionTime], [ExecutionDuration], [CreatedDateTime], [RunLog], [IsDelete])
	VALUES (519, 7, N'Exe程序', CAST(0x0000A8C5010B6CF0 AS datetime), CAST(4.51 AS decimal(18, 2)), CAST(0x0000A8C5010B723D AS datetime), N'[Extend_Exe_Return:agr1
,Extend_Exe_Error:
未经处理的异常:  System.Exception: errotr
   在 ExeTest.Program.Main(String[] args)
]', 0)
SET IDENTITY_INSERT [dbo].[TB_TM_TaskLog] OFF
/****** Object:  Table [dbo].[TB_TM_TaskInfo]    Script Date: 04/17/2018 16:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TM_TaskInfo](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskType] [nvarchar](50) NULL,
	[TaskName] [nvarchar](255) NULL,
	[AssemblyName] [nvarchar](255) NULL,
	[ClassName] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[TaskArgs] [nvarchar](255) NULL,
	[CronExpression] [nvarchar](255) NULL,
	[CronExpressionDescription] [nvarchar](255) NULL,
	[FirstRunTime] [datetime] NULL,
	[NextRunTime] [datetime] NULL,
	[LastRunTime] [datetime] NULL,
	[RunCount] [int] NOT NULL,
	[State] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Priority] [int] NULL,
	[CreatedByUserId] [nvarchar](40) NULL,
	[CreatedByUserName] [nvarchar](80) NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastUpdatedByUserId] [nvarchar](40) NULL,
	[LastUpdatedByUserName] [nvarchar](80) NULL,
	[LastUpdatedDateTime] [datetime] NULL,
	[IsDelete] [int] NOT NULL,
 CONSTRAINT [PK_TB_TM_TaskInfo] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_TM_TaskInfo] ON
INSERT [dbo].[TB_TM_TaskInfo] ([TaskId], [TaskType], [TaskName], [AssemblyName], [ClassName], [Description], [TaskArgs], [CronExpression], [CronExpressionDescription], [FirstRunTime], [NextRunTime], [LastRunTime], [RunCount], [State], [DisplayOrder], [Priority], [CreatedByUserId], [CreatedByUserName], [CreatedDateTime], [LastUpdatedByUserId], [LastUpdatedByUserName], [LastUpdatedDateTime], [IsDelete])
	VALUES (2, N'IJob', N'Job管理器', N'Only.Jobs.exe', N'Only.Jobs.JobItems.ManagerJob', N'负责Job的动态调度', NULL, N'0/3 * * * * ?', N'每隔3秒执行一次', NULL, CAST(0x0000A8C000A4D288 AS datetime), CAST(0x0000A8C000A4CF04 AS datetime), 10, -100, 0, NULL, NULL, NULL, CAST(0x0000A7AA013C0B64 AS datetime), NULL, NULL, CAST(0x0000A7AB00FE6D26 AS datetime), 1)
INSERT [dbo].[TB_TM_TaskInfo] ([TaskId], [TaskType], [TaskName], [AssemblyName], [ClassName], [Description], [TaskArgs], [CronExpression], [CronExpressionDescription], [FirstRunTime], [NextRunTime], [LastRunTime], [RunCount], [State], [DisplayOrder], [Priority], [CreatedByUserId], [CreatedByUserName], [CreatedDateTime], [LastUpdatedByUserId], [LastUpdatedByUserName], [LastUpdatedDateTime], [IsDelete])
	VALUES (7, N'Exe', N'Exe程序', N'ExeTest.exe', N'ExeTest.exe', N'exe文件运行测试', N'{"KEY":"agr1","WXC":"agr2","WWD":"wangwending","other":"this is other args"}', N'0/10 * * * * ?', N'升水', CAST(0x0000A8C501005900 AS datetime), CAST(0x0000A8C5010B78A8 AS datetime), CAST(0x0000A8C5010B6CF0 AS datetime), 102, 20, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[TB_TM_TaskInfo] ([TaskId], [TaskType], [TaskName], [AssemblyName], [ClassName], [Description], [TaskArgs], [CronExpression], [CronExpressionDescription], [FirstRunTime], [NextRunTime], [LastRunTime], [RunCount], [State], [DisplayOrder], [Priority], [CreatedByUserId], [CreatedByUserName], [CreatedDateTime], [LastUpdatedByUserId], [LastUpdatedByUserName], [LastUpdatedDateTime], [IsDelete])
	VALUES (8, N'Url', N'Url程序', N'http://localhost:22960/WebForm1.aspx', N'http://localhost:22960/WebForm1.aspx', N'exe文件运行测试', N'{"KEY":"KEY1","WXC":"wuxincao","WWD":"wangwending","other":"this is other args"}', N'0/10 * * * * ?', N'升水', NULL, CAST(0x0000A8C5010B78A8 AS datetime), CAST(0x0000A8C5010B6CF0 AS datetime), 124, 20, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[TB_TM_TaskInfo] ([TaskId], [TaskType], [TaskName], [AssemblyName], [ClassName], [Description], [TaskArgs], [CronExpression], [CronExpressionDescription], [FirstRunTime], [NextRunTime], [LastRunTime], [RunCount], [State], [DisplayOrder], [Priority], [CreatedByUserId], [CreatedByUserName], [CreatedDateTime], [LastUpdatedByUserId], [LastUpdatedByUserName], [LastUpdatedDateTime], [IsDelete])
	VALUES (9, N'Url', N'Url程序', N'http://localhost:22960/WebForm1.aspx', N'http://localhost:22960/WebForm1.aspx', N'exe文件运行测试', NULL, N'0/6 * * * * ?', N'升水', NULL, CAST(0x0000A8C500AEAEC0 AS datetime), CAST(0x0000A8C500AEA7B8 AS datetime), 21, -100, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[TB_TM_TaskInfo] ([TaskId], [TaskType], [TaskName], [AssemblyName], [ClassName], [Description], [TaskArgs], [CronExpression], [CronExpressionDescription], [FirstRunTime], [NextRunTime], [LastRunTime], [RunCount], [State], [DisplayOrder], [Priority], [CreatedByUserId], [CreatedByUserName], [CreatedDateTime], [LastUpdatedByUserId], [LastUpdatedByUserName], [LastUpdatedDateTime], [IsDelete])
	VALUES (10, N'IJob', N'IJob程序', N'lib/QuartzDemo.exe', N'QuartzDemo.HelloJob', N'负责Job的动态调度', NULL, N'0/10 * * * * ?', N'每隔3秒执行一次', NULL, CAST(0x0000A8C000A4D288 AS datetime), CAST(0x0000A8C000A4CF04 AS datetime), 10, -100, 0, NULL, NULL, NULL, CAST(0x0000A7AA013C0B64 AS datetime), NULL, NULL, CAST(0x0000A7AB00FE6D26 AS datetime), 1)
SET IDENTITY_INSERT [dbo].[TB_TM_TaskInfo] OFF
/****** Object:  Table [dbo].[Table_1]    Script Date: 04/17/2018 16:29:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table_1](
	[TaskId] [varchar](50) NOT NULL,
	[TaskName] [nvarchar](255) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Table_1] ([TaskId], [TaskName])
	VALUES (N'1', N'TEST')
INSERT [dbo].[Table_1] ([TaskId], [TaskName])
	VALUES (N'27CCF88F-A696-4448-B53C-48BA2A8A33A2', N'TEST')