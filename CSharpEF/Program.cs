// See https://aka.ms/new-console-template for more information
// ADO.NET (Active Data Objects for .NET)
// Con ADO.NET interagiamo col DB attraverso istruzioni SQL

using Microsoft.Data.SqlClient;
using System.Data;

var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=CSharpEF2;Integrated Security=true;";

// CONNESSIONE AL DB
using SqlConnection connection = new(connectionString);
SqlCommand cmd = connection.CreateCommand();

try
{
	connection.Open();

    // scalar 
    cmd.CommandText = "SELECT COUNT(*) as count FROM Todos";
    var count = cmd.ExecuteScalar();

    Console.WriteLine($"Numero Todos: {count}");

    // where
    int userId = 3;

    cmd.CommandText = "SELECT COUNT(*) as count FROM Todos WHERE UtenteId = @UtenteId";
    cmd.Parameters.AddWithValue("@UtenteId", userId);
    count = cmd.ExecuteScalar();

    Console.WriteLine($"Numero Todos utente {userId}: {count}");

    //// insert
    //cmd.CommandText = "INSERT INTO Todos (Testo, Completato, CategoriaId, UtenteId) VALUES (@Testo, 0, 2, @UtenteId)";
    //cmd.Parameters.Clear();

    //var testo = "30 Piegamenti";
    //cmd.Parameters.AddWithValue("@Testo", testo);
    //cmd.Parameters.AddWithValue("@UtenteId", userId);
    //var result = cmd.ExecuteNonQuery();
    //Console.WriteLine($"Risultato inserimento: {result}");

    // reader
    cmd.Parameters.Clear();
    cmd.CommandText = @"
                        SELECT t.Id, t.Testo, t.Completato, c.Nome AS Categoria, u.Nome AS Utente
                        FROM Todos AS t
                        INNER JOIN Utenti AS u ON t.UtenteId = u.Id
                        INNER JOIN Categorie AS c ON t.CategoriaId = c.Id";

    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        Console.WriteLine("Todos:");
        while (reader.Read())
        {
            var id = reader[0];
            var testo = reader[1];
            var completato = reader[2];
            var categoria = reader[3];
            var utente = reader[4];

            Console.WriteLine($"Id: {id}, Testo: {testo}, Completato: {completato}, Categoria: {categoria}, Utente: {utente}");
        }
    }

    // dataset
    SqlDataAdapter adapter = new(cmd);
    DataSet ds = new();
    adapter.Fill(ds, "todos");

    Console.WriteLine("Todos Dataset:");
    foreach (DataRow t in ds.Tables["todos"]!.Rows)
    {
        Console.WriteLine($"Id: {t["Id"]}, Testo: {t["Testo"]}, Completato: {t["Completato"]}, Categoria: {t["Categoria"]}, Utente: {t["Utente"]}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
