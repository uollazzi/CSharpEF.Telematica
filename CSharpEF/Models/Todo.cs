using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSharpEF.Models;

public partial class Todo
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string Testo { get; set; } = null!;

    public bool Completato { get; set; }

    public int CategoriaId { get; set; }

    public int UtenteId { get; set; }

    [ForeignKey("CategoriaId")]
    [InverseProperty("Todos")]
    public virtual Categorie Categoria { get; set; } = null!;

    [ForeignKey("UtenteId")]
    [InverseProperty("Todos")]
    public virtual Utenti Utente { get; set; } = null!;
}
