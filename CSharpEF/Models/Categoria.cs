using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpEF.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [InverseProperty("Categoria")]
    public virtual ICollection<Articolo>? Articoli { get; set; }
}
