# AmarisBlazorLab
A test project to showcase Blazor server-side for an ERP style application.

# Requirements
- SQLExpress
- .Net Core 3.1+
- ASP.NET and web development workload (if using Visual Studio)
- dotnet ef (when using the .Net Core CLI directly)

# What the project showcase
- Use of the IdentityFramework for User management.
- Use of EntityFramework for Database management.
  - The Repository pattern has been implemented and EntityFramework is used in a Code-First approach.
- Use of community projects for facilitating development (e.g.: Blazorise)

With this project a default Admin account is seeded:
- admin@test.com => Admin#1

Regular users can:
- Login/Logout.
- Sign-up.
- Join a project.
- Leave a project.
- Upload materials to a project.

Admins are regular users who can also:
- Create users with a specific role (Admin or Regular)
- Delete regular users.
- Create projects.
- Update projects.
- Assign users to project.
- Remove users from project.

# More information
You can find more information about the setup of this project and how to run it inside the ``Techno Study`` document.
