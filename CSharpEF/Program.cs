// MIGRAZIONI

// installazione tool ef
// dotnet tool install --global dotnet-ef

// creare migrazione
// dotnet ef migrations add InitialCreate --context BlogContext

// rimuovere ultima migrazione
// dotnet ef migrations remove

// applichiamo la migrazione: aggiorniamo il database
// dotnet ef database update

// riporta il DB allo stato iniziale, cioè senza migrazioni
// dotnet ef database update 0

using CSharpEF;
using CSharpEF.Models;
using Microsoft.EntityFrameworkCore;

#region Popolamento DB con dati di test
static void PopulateDB()
{
    using (var dc = new BlogContext())
    {
        if (!dc.Utenti.Any())
        {
            // inseriamo Utenti
            var gigi = new Utente()
            {
                Nome = "Gigi Rossi"
            };
            var anna = new Utente();
            anna.Nome = "Anna Bianchi";

            // corrispettivo della INSERT
            dc.Add(gigi);
            dc.Add(anna);            
        }

        if (!dc.Categorie.Any())
        {
            dc.Add(new Categoria() { Nome = "Cronoca" });
            dc.Add(new Categoria() { Nome = "Attualità" });
            dc.Add(new Categoria() { Nome = "Sport" });
            dc.Add(new Categoria() { Nome = "Politica" });
        }

        try
        {
            var r = dc.SaveChanges(); // committa le modifiche sul DB
            Console.WriteLine($"Entità aggiornate: {r}");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException?.Message);
            Console.ResetColor();
        }

        if (!dc.Articoli.Any())
        {
            var autore = dc.Utenti.First();
            var categoria = dc.Categorie.FirstOrDefault(x => x.Nome == "Politica");

            if (categoria != null)
            {
                var a1 = new Articolo()
                {
                    Titolo = "Nuovo Presidente del Consiglio",
                    Testo = "Bella e brava!",
                    Autore = autore,
                    Categoria = categoria
                };
                dc.Add(a1);
            }            
        }

        try
        {
            var r = dc.SaveChanges(); // committa le modifiche sul DB
            Console.WriteLine($"Entità aggiornate: {r}");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException?.Message);
            Console.ResetColor();
        }
    }
}

PopulateDB();
#endregion

using (var dc = new BlogContext())
{
    var articolo = dc.Articoli
        .Include(x => x.Autore)
        .Include(x => x.Categoria)
        .Single(x => x.Id == 3);

    Console.WriteLine(articolo.Titolo);
    Console.WriteLine(articolo.Testo);
    Console.WriteLine($"Scritto da: {articolo.Autore!.Nome}");
    Console.WriteLine($"Categoria: {articolo.Categoria!.Nome}");

    // preparazione della query
    var articoli = dc.Articoli.Where(x => x.Autore!.Id == 2).OrderBy(o => o.Titolo);

    // esecuzione
    foreach (var a in articoli)
    {
        Console.WriteLine(a.Titolo);
    }

}

Console.WriteLine();