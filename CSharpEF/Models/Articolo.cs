using System.ComponentModel.DataAnnotations;

namespace CSharpEF.Models;

public class Articolo
{
    // Id = Convenzione Chiave Primaria
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Titolo { get; set; }

    [Required]
    public string? Testo { get; set; }

    [Required]
    public virtual Utente? Autore { get; set; }

    [Required]
    public virtual Categoria? Categoria { get; set; }
}
