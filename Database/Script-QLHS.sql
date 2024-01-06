/* SQLINES DEMO *** le [dbo].[tb_Class]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Class`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `GroupID` int NULL,
    `Name` Longtext NULL,
    `Quantity` int NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Class` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Groups]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Groups`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `Name` Longtext NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Groups` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Menu]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Menu`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `Name` Longtext NULL,
    `RoleID` int NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Menu` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Regulations]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Regulations`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `MinAge` int NULL,
    `MaxAge` int NULL,
    `MaxQuantity` int NULL,
    `ClassQuantity` int NULL,
    `SubjectQuantity` int NULL,
    `PassingGrade` Double NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Regulations` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Roles]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Roles`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `Name` Longtext NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Roles` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Semesters]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Semesters`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `Name` Longtext NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Semesters` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Students]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Students`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `Name` Longtext NULL,
    `Gender` int NULL,
    `DateOfBirth` date NULL,
    `Address` Longtext NULL,
    `Email` nvarchar(200) NULL,
    `ClassID` int NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Students` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Subjects]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_Subjects`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `Name` Longtext NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Subjects` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_TranScripts]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
CREATE TABLE `tb_TranScripts`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `StudentID` int NULL,
    `SemesterID` int NULL,
    `SubjectID` int NULL,
    `Grade15` Double NULL,
    `Grade45` Double NULL,
    `GradeSemester` Double NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_TranScripts` PRIMARY KEY (`ID` ASC)
);
/* SQLINES DEMO *** le [dbo].[tb_Users]    Script Date: 11/25/2022 9:53:26 PM ******/
/* SET ANSI_NULLS ON */
/* SET QUOTED_IDENTIFIER ON */
/* SET ANSI_PADDING ON */
CREATE TABLE `tb_Users`(
    `ID` int AUTO_INCREMENT NOT NULL,
    `Name` Longtext NULL,
    `Username` varchar(50) NULL,
    `Password` varchar(50) NULL,
    `Email` nvarchar(200) NULL,
    `RoleID` int NULL,
    `CreatedDate` datetime(3) NULL,
    `LastUpdatedDate` datetime(3) NULL,
    `IsDeleted` Tinyint NULL,
    CONSTRAINT `PK_tb_Users` PRIMARY KEY (`ID` ASC)
);
/* SET ANSI_PADDING OFF */
ALTER TABLE
    tb_Class
ADD
    CONSTRAINT FK_tb_Class_tb_Groups FOREIGN KEY(GroupID) REFERENCES tb_Groups (ID);

ALTER TABLE
    tb_MenuADD CONSTRAINT FK_tb_Menu_tb_Roles FOREIGN KEY(RoleID) REFERENCES tb_Roles (ID);

ALTER TABLE
    tb_Students
ADD
    CONSTRAINT FK_tb_Students_tb_Class FOREIGN KEY(ClassID) REFERENCES tb_Class (ID);

ALTER TABLE
    tb_TranScripts
ADD
    CONSTRAINT FK_tb_TranScripts_tb_Semesters FOREIGN KEY(SemesterID) REFERENCES tb_Semesters (ID);

ALTER TABLE
    tb_TranScripts
ADD
    CONSTRAINT FK_tb_TranScripts_tb_Students FOREIGN KEY(StudentID) REFERENCES tb_Students (ID);

ALTER TABLE
    tb_TranScripts
ADD
    CONSTRAINT FK_tb_TranScripts_tb_Subjects FOREIGN KEY(SubjectID) REFERENCES tb_Subjects (ID);

ALTER TABLE
    tb_Users
ADD
    CONSTRAINT FK_tb_Users_tb_Roles FOREIGN KEY(RoleID) REFERENCES tb_Roles (ID);
