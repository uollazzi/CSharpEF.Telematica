using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSharpEF.Models;

[Keyless]
public partial class VwTodo
{
    public int Id { get; set; }

    [Unicode(false)]
    public string Testo { get; set; } = null!;

    public bool Completato { get; set; }

    public int CategoriaId { get; set; }

    public int UtenteId { get; set; }

    public string Categoria { get; set; } = null!;
}
