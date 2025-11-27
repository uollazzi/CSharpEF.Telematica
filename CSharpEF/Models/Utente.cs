using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpEF.Models;

public class Utente
{
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [InverseProperty("Autore")]
    public virtual ICollection<Articolo>? Articoli { get; set; }

    [InverseProperty("Autore")]
    public virtual ICollection<Commento>? Commenti { get; set; }
}
