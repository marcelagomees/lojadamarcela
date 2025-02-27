using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDaMarcela.Models;

[Table("ProdutoFoto")]
public class ProdutoFoto
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Produtos")]
    [Required(ErrorMessage = "Por favor, informe o Produto")]
    public int ProdutoId { get; set; }
    [ForeignKey("ProdutoId")]
    public Produto Produto { get; set; }

    [Required(ErrorMessage = "Por favor, informe a foto")]
    [StringLength(200)]
    public string Foto { get; set; }

    [StringLength(100)]
    public string Descricao { get; set; }
}