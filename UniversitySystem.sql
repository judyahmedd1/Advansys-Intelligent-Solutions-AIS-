CREATE DATABASE UniversitySystem;

CREATE TABLE UniversityInstructors(
	InstructorID INT IDENTITY(1,1) PRIMARY KEY,
	InstructorFirstName VARCHAR(50) NOT NULL,
	InstructorLastName VARCHAR(50) NOT NULL,
    InstructorEmail VARCHAR(100) NOT NULL UNIQUE,
    InstructorPhone VARCHAR(20),
    InstructorHireDate DATETIME NOT NULL DEFAULT GETDATE(),
	InstructorOfficelocation VARCHAR(50) NOT NULL,
    DepartmentID INT NOT NULL
    --FOREIGN KEY (DepartmentID) REFERENCES UniversityDepartments(DepartmentID)
);

CREATE TABLE UniversityDepartments (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL,
    DepartmentBuilding VARCHAR(50) NOT NULL,
    DepartmentBudget DECIMAL(12,2) NOT NULL CHECK (DepartmentBudget > 0),
    HeadInstructorID INT NULL
    --FOREIGN KEY (HeadInstructorID) REFERENCES UniversityInstructors(InstructorID)
);

ALTER TABLE UniversityInstructors ADD CONSTRAINT FK_Instructors_Departments FOREIGN KEY(DepartmentID) REFERENCES UniversityDepartments(DepartmentID);
ALTER TABLE UniversityDepartments ADD CONSTRAINT FK_Departments_Instructors FOREIGN KEY(HeadInstructorID) REFERENCES UniversityInstructors(InstructorID);


CREATE TABLE Courses (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    CourseCredits TINYINT NOT NULL, 
    --CHECK (CourseCredits > 0)
    CourseDescription VARCHAR(MAX) NOT NULL,
    DepartmentID INT NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

----CREATE TABLE CoursePrerequisite (
----    PrerequisiteCourseID INT IDENTITY(1,1) PRIMARY KEY
----);

--many to many (Courses and CoursePrerequisite)
--junction table
CREATE TABLE Courses_Prerequisite(
    PrerequisiteCourseID INT NOT NULL,
    CourseID INT NOT NULL,
    PRIMARY KEY (CourseID, PrerequisiteCourseID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (PrerequisiteCourseID) REFERENCES CoursePrerequisite(PrerequisiteCourseID)
);


CREATE TABLE Programs (
    ProgramID INT IDENTITY(1,1) PRIMARY KEY,
    ProgramName VARCHAR(100) NOT NULL,
    DegreeType VARCHAR(30) NOT NULL,
    DepartmentID INT NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Semesters (
    SemesterID INT IDENTITY(1,1) PRIMARY KEY,
    SemesterName VARCHAR(30) NOT NULL,
    SemesterStartDate DATE NOT NULL,
    SemesterEndDate DATE NOT NULL 
);

CREATE TABLE Classrooms (
    ClassroomID INT IDENTITY(1,1) PRIMARY KEY,
    ClassroomBuilding VARCHAR(50) NOT NULL,
    RoomNumber VARCHAR(10) NOT NULL,
    ClassroomCapacity SMALLINT NOT NULL 
);

CREATE TABLE CourseSections (
    CourseSectionID INT IDENTITY(1,1) PRIMARY KEY,
    CourseSectionSchedule VARCHAR(50) NOT NULL,
    CourseSectionCapacity SMALLINT NOT NULL,
    CourseID INT NOT NULL,
    SemesterID INT NOT NULL,
    InstructorID INT NOT NULL,
    ClassroomID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (SemesterID) REFERENCES Semesters(SemesterID),
    FOREIGN KEY (InstructorID) REFERENCES UniversityInstructors(InstructorID),
    FOREIGN KEY (ClassroomID) REFERENCES Classrooms(ClassroomID)
);

CREATE TABLE Students(
	StudentID INT IDENTITY(1,1) PRIMARY KEY,
	StudentFirstName VARCHAR(50) NOT NULL,
	StudentLastName VARCHAR(50) NOT NULL,
    StudentEmail VARCHAR(50) NOT NULL UNIQUE,
    StudentPhone NVARCHAR(20),
	StudentAddress VARCHAR(200) NOT NULL,
    StudentEnrollmentDate DATETIME NOT NULL DEFAULT GETDATE(),
    StudentDOB DATE NOT NULL,
	ProgramID INT NOT NULL,
    AdvisorID INT NOT NULL,
    FOREIGN KEY (ProgramID) REFERENCES Programs(ProgramID),
    --AdvisorID
    FOREIGN KEY (AdvisorID) REFERENCES UniversityInstructors(InstructorID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseSectionID INT NOT NULL,
    StudentEnrollmentDate DATETIME NOT NULL DEFAULT GETDATE(), 
    Grade VARCHAR(2),
);

--many to many (coursesections , enrollments)
CREATE TABLE CourseSections_Enrollments(
    EnrollmentID INT NOT NULL,
    CourseSectionID INT NOT NULL,
    PRIMARY KEY (EnrollmentID, CourseSectionID),
    FOREIGN KEY (EnrollmentID) REFERENCES Enrollments(EnrollmentID),
    FOREIGN KEY (CourseSectionID) REFERENCES CourseSections(CourseSectionID)
);


--many to many (Students , enrollments)
CREATE TABLE Students_Enrollments(
    EnrollmentID INT NOT NULL,
    StudentID INT NOT NULL,
    PRIMARY KEY (EnrollmentID, StudentID),
    FOREIGN KEY (EnrollmentID) REFERENCES Enrollments(EnrollmentID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);


CREATE TABLE Payments(
    PaymentID INT NOT NULL,
    PaymentAmount DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(), 
    PaymentStatus VARCHAR(20)NOT NULL,
    StudentID INT NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);

--joins
--inner join (students , enrollments)
SELECT * 
FROM Students 
INNER JOIN Enrollments 
ON  Students.StudentID = Enrollments.StudentID; 

--left join(courses , instructors)
SELECT Courses.CourseID,Courses.CourseName,UniInstructors.InstructorFirstName,UniInstructors.InstructorLastName
FROM Courses 
LEFT JOIN UniInstructors
ON Courses.DepartmentID = UniInstructors.DepartmentID;

--right join
SELECT UniInstructors.InstructorFirstName,UniInstructors.InstructorLastName,Courses.CourseName
FROM UniInstructors 
RIGHT JOIN Courses
ON UniInstructors.DepartmentID = Courses.DepartmentID;

--full join (courses , departments)
SELECT *
FROM Courses 
FULL JOIN UniversityDepartments
ON Courses.DepartmentID = UniversityDepartments.DepartmentID; 
