
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDaMarcela.Models;

[Table("Categoria")]
public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, Informe o Nome")]
    [StringLength(50, ErrorMessage = "O Nome deve possuir no máximo 50 caracteres")]
    public string Nome { get; set; }

    [StringLength(200)]
    public string Foto { get; set; }

    [Display(Name ="Exibir na Home?")]
    public bool ExibirHome { get; set; } = false;
}
