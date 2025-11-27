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

// prima eseguire sul terminale: dotnet tool install --global dotnet-ef
// Da eseguire nel terminale della cartella del progetto:
// dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSharpEF2;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer --data-annotations --output-dir Models --context-dir .


using CSharpEF;

using (var dc = new CsharpEfContext())
{
    Console.WriteLine("Elenco Todos");
    foreach (var todo in dc.Todos)
    {
        Console.WriteLine(todo.Testo);
    }
    Console.WriteLine();

    Console.WriteLine("Elenco Categorie e Todos");
    foreach (var cat in dc.Categories)
    {
        Console.WriteLine(cat.Nome);
        foreach (var todo in cat.Todos)
        {
            Console.WriteLine("\t" + todo.Testo);
        }
    }
}

