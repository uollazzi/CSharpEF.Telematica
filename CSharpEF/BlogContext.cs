using CSharpEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpEF;

public class BlogContext : DbContext
{
    public BlogContext()
    {
        
    }

    public BlogContext(DbContextOptions<BlogContext> options)
        : base(options)
    {

    }

    // get esplicita
    public DbSet<Utente> Utenti { 
        get 
        {
            return base.Set<Utente>();
        } 
    }

    // get abbreviata
    public DbSet<Articolo> Articoli => Set<Articolo>();
    public DbSet<Categoria> Categorie => Set<Categoria>();
    public DbSet<Commento> Commenti => Set<Commento>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CSharpEF_Blog;Integrated Security=true;");
        }
    }
}
