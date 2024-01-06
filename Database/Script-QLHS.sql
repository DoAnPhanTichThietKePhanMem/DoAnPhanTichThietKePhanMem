/* SQLINES DEMO *** le [dbo].[tb_Class] /
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
/* SQLINES DEMO *** le [dbo].[tb_Groups]    /
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
/* SQLINES DEMO *** le [dbo].[tb_Menu]    /
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
/* SQLINES DEMO *** le [dbo].[tb_Regulations]   /
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
/* SQLINES DEMO *** le [dbo].[tb_Roles]    /
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
/* SQLINES DEMO *** le [dbo].[tb_Semesters]    /
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
/* SQLINES DEMO *** le [dbo].[tb_Students]    /
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
/* SQLINES DEMO *** le [dbo].[tb_Subjects]    /
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
/* SQLINES DEMO *** le [dbo].[tb_TranScripts]    /
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
/* SQLINES DEMO *** le [dbo].[tb_Users]    /
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
	

INSERT INTO tb_Groups (Name, CreatedDate, LastUpdatedDate, IsDeleted) VALUES
('Group A', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group B', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group C', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group D', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group E', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group F', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group G', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group H', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group I', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Group J', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0);

INSERT INTO tb_Roles (Name, CreatedDate, LastUpdatedDate, IsDeleted) VALUES
('Teacher', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Staff', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Guest', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Librarian', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Principal', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Counselor', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Parent', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Guardian', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0);

INSERT INTO tb_Class (GroupID, Name, Quantity, CreatedDate, LastUpdatedDate, IsDeleted) VALUES
(1, 'Class A1', 30, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(2, 'Class B1', 25, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(3, 'Class C1', 20, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(4, 'Class D1', 35, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(5, 'Class E1', 22, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(1, 'Class A2', 28, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(3, 'Class C2', 18, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(2, 'Class B2', 27, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(4, 'Class D2', 32, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
(5, 'Class E2', 20, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0);


INSERT INTO tb_Semesters (Name, CreatedDate, LastUpdatedDate, IsDeleted) VALUES
('Semester 1', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 2', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 3', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 4', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 5', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 6', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 7', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 8', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 9', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Semester 10', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0);

INSERT INTO tb_Subjects (Name, CreatedDate, LastUpdatedDate, IsDeleted) VALUES
('Mathematics', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('English', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Physics', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Chemistry', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Biology', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('History', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Geography', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Computer Science', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Economics', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Physical Education', '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0);

-- Sample data for tb_Regulations
INSERT INTO tb_Regulations (MinAge, MaxAge, MaxQuantity, ClassQuantity, SubjectQuantity, PassingGrade, CreatedDate, LastUpdatedDate, IsDeleted) VALUES
(18, 25, 200, 10, 5, 7.0, '2024-01-01 08:00:00', '2024-01-01 08:00:00', 0),
(20, 30, 250, 12, 6, 6.5, '2024-01-02 09:00:00', '2024-01-02 09:00:00', 0),
(22, 35, 300, 15, 8, 8.0, '2024-01-03 10:00:00', '2024-01-03 10:00:00', 0),
(19, 28, 180, 8, 4, 7.5, '2024-01-04 11:00:00', '2024-01-04 11:00:00', 0),
(21, 32, 220, 11, 5, 6.0, '2024-01-05 12:00:00', '2024-01-05 12:00:00', 0);

INSERT INTO tb_Students (Name, Gender, DateOfBirth, Address, Email, ClassID, CreatedDate, LastUpdatedDate, IsDeleted) VALUES
('Student A1', 1, '2000-01-01', 'Address A1', 'student_a1@email.com', 1, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student B1', 2, '2000-02-02', 'Address B1', 'student_b1@email.com', 2, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student C1', 1, '2000-03-03', 'Address C1', 'student_c1@email.com', 3, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student D1', 2, '2000-04-04', 'Address D1', 'student_d1@email.com', 4, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student E1', 1, '2000-05-05', 'Address E1', 'student_e1@email.com', 5, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student A2', 2, '2000-06-06', 'Address A2', 'student_a2@email.com', 1, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student B2', 1, '2000-07-07', 'Address B2', 'student_b2@email.com', 2, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student C2', 2, '2000-08-08', 'Address C2', 'student_c2@email.com', 3, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student D2', 1, '2000-09-09', 'Address D2', 'student_d2@email.com', 4, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0),
('Student E2', 2, '2000-10-10', 'Address E2', 'student_e2@email.com', 5, '2024-01-03 12:00:00', '2024-01-03 12:00:00', 0);
