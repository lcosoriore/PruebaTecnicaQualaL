using System.ComponentModel.DataAnnotations;
namespace QualaServices.Models;

public partial class Monedum
{
    public int MonedaId { get; set; }

    [Required(ErrorMessage = "El campo Moneda es requerido")]
    public string Moneda { get; set; } = null!;
}
