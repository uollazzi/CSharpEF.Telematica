using System.ComponentModel.DataAnnotations;

namespace CSharpEF.Models;

public class Commento
{
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string? Testo { get; set; }

    [Required]
    public virtual Utente? Autore { get; set; }
}
