# Server

Installation required Packages(3).

- Microsoft.EntityFrameworkCore.
- Microsoft.EntityFrameworkCore.Tool.
- Microsoft.EntityFrameworkCore.SqlServer.

1. Configure the appsetting.json file.
   "ConnectionStrings": {
   "DefaultString": "Server=.;Database=Project_Mangement;TrustedConnection=True;TrustServrCertificate=True"
   }

Discussion of Data Base Project.
1. A User Can Create A many Project.
2. A Project has many task.
3. A task  belongs to one project.
4. A project has many members.
5. A User can part of many Projects.
6. A Task can be assignment to multiple Users.
7. A user can comment on many task.
8. A Task Has Many comments.
9. User can create multiple task.
