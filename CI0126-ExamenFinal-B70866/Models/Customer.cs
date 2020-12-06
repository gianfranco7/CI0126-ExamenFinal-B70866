using System.ComponentModel.DataAnnotations;

namespace CI0126_ExamenFinal_B70866.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Es necesario que ingrese su dirección para enviar los productos")]
        [Display(Name = "Ingrese la dirección donde se recibirán los productos")]
        public string address { get; set; }
    }
}