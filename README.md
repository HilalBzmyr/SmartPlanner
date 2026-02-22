# SmartPlanner

SmartPlanner is a Windows Forms–based academic planning application developed in C# with SQL Server as the backend database.

The application enables students to manage courses, assignments, and exams within a structured relational system and an event-driven desktop interface.

### Features

- Course management

- Assignment tracking

- Exam scheduling

- Dashboard overview

- Deadline filtering

- Conflict detection

### Technical Highlights

- Event-driven WinForms architecture

- Relational database design with foreign keys

- ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter)

- Parameterized SQL queries

- Full CRUD operations

- DataGridView binding and UI synchronization

### Technologies

- C#

- .NET Windows Forms

- SQL Server (LocalDB)

- ADO.NET

### Educational Purpose

This project was developed for a Visual Programming course to demonstrate GUI development, database integration, and relational modeling.

### Project Architecture
```bash
SmartPlanner/
│
├── Program.cs
├── App.config
│
├── FrmMain.cs
├── FrmDashboard.cs
├── FrmCourses.cs
├── FrmAssignments.cs
├── FrmExams.cs
│
└── Database Scripts/
```
<img width="627" height="487" alt="image" src="https://github.com/user-attachments/assets/8fa734f0-b207-4208-828f-4352c8cb23df" />

### Application Entry Point

The application starts from:
```bash
// Program.cs
Application.Run(new FrmMain());
```
FrmMain acts as the central navigation hub of the system.

### Application Modules
 #### FrmMain

Main navigation interface providing access to:

- Dashboard

- Courses

- Assignments

- Exams

This structure ensures clear separation of responsibilities.

 #### FrmCourses

- Manages course records:

- Add, update, delete courses

- Display courses in a DataGridView


 #### FrmAssignments

Handles assignment management:

- Assign assignments to courses

- Manage deadlines

- Display assignments with course names (JOIN)

 #### FrmExams

 Manages exam records:

- Course-based exam creation

- Date and time handling

- Update/Delete operations

- Grid selection synchronization


 #### FrmDashboard

Provides a centralized overview:

- Upcoming assignments

- Upcoming exams

- Date-based filtering

- Conflict detection between assignments and exams

Conflict detection is implemented using date comparison logic.

### Database Design

The system uses a relational structure with foreign key constraints:

Courses

- CourseID (Primary Key)

- CourseName

- InstructorName

Assignments

- AssignmentID (Primary Key)

- CourseID (Foreign Key)

- Title

- Description

- DueDate

Exams

- ExamID (Primary Key)

- CourseID (Foreign Key)

- ExamType

- ExamDateTime

- Description

Foreign keys enforce referential integrity between tables.

### 🔐 Data Access Strategy

Database interaction is implemented using ADO.NET:

- ``` SqlConnection ```

- ``` SqlCommand ```

- ``` SqlDataAdapter ```

- ``` DataTable ```

Best practices applied:

- Parameterized SQL queries

- Null validation

- Proper resource disposal using ``` using``` statements

- Centralized configuration via ``` App.config```

### ⚙ Configuration

Database connection is managed through:
```
<!-- App.config -->
<connectionStrings>
  <add name="connStr"
       connectionString="Data Source=(localdb)\MSSQLLocalDB;
       Initial Catalog=SmartPlannerDB;
       Integrated Security=True" />
</connectionStrings>
```
Ensure:

- SQL Server LocalDB is installed

- The database exists

- Required tables are created before running the application

### 🛠 How to Run
git clone
```
https://github.com/HilalBzmyr/SmartPlanner.git
```
1. Open the solution in Visual Studio

2. Ensure SQL Server LocalDB is available

3. Create the database and tables if not included

4. Verify the connection string in App.config

5. Build and run the project

 
