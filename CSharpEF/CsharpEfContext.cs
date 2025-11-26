using System;
using System.Collections.Generic;
using CSharpEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpEF;

public partial class CsharpEfContext : DbContext
{
    public CsharpEfContext()
    {
    }

    public CsharpEfContext(DbContextOptions<CsharpEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Todo> Todos { get; set; }

    public virtual DbSet<Utenti> Utentis { get; set; }

    public virtual DbSet<VwTodo> VwTodos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CSharpEF2;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasOne(d => d.Categoria).WithMany(p => p.Todos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Todos_Categorie");

            entity.HasOne(d => d.Utente).WithMany(p => p.Todos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Todos_Utenti");
        });

        modelBuilder.Entity<VwTodo>(entity =>
        {
            entity.ToView("VW_Todos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
