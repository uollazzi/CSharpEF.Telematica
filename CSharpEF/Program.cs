// See https://aka.ms/new-console-template for more information

// ORM = Object-Relational Mapping => Entity Framework
// Code First
// Database First

// 04-02 APPROCCIO DB FIRST: SCAFFOLD
// Installazione
// Microsoft.EntityFrameworkCore
// Microsoft.EntityFrameworkCore.Design
// Microsoft.EntityFrameworkCore.SqlServer
// Microsoft.EntityFrameworkCore.Tools


// Da eseguire nel Package Manager Console:
// Scaffold-DbContext -DataAnnotations -OutputDir Models -ContextDir . 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSharpEF2;Integrated Security=true;' Microsoft.EntityFrameworkCore.SqlServer

var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CSharpEF2;Integrated Security=true;";

