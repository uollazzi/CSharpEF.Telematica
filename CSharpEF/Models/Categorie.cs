using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSharpEF.Models;

[Table("Categorie")]
public partial class Categorie
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string Nome { get; set; } = null!;

    [InverseProperty("Categoria")]
    public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
}
