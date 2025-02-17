using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDaMarcela.Models;

[Table("ProdutosFoto")]
public class ProdutosFoto
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Produtos")]
    [Required(ErrorMessage = "Por favor, informe o Produto")]
    public int ProdutoId { get; set; }
    [ForeignKey("ProdutosId")]
    public Produtos Produtos { get; set; }

    [Required(ErrorMessage = "Por favor, informe a foto")]
    [StringLength(100, ErrorMessage = "A descrição deve possuir 100 caracteres")]
    public int MyProperty { get; set; }
}