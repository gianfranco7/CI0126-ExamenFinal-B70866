using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CI0126_ExamenFinal_B70866.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Es necesario que escriba el nombre del producto")]
        [Display(Name = "Ingrese el nombre del producto")]
        public string name { get; set; }

        [Required(ErrorMessage = "Es necesario que escriba la descripción del producto")]
        [Display(Name = "Ingrese la descripción del producto")]
        public string description { get; set; }

        [Required(ErrorMessage = "Es necesario que escriba la cantidad para aplicar descuento al producto")]
        [Display(Name = "Ingrese la cantidad de unidades para aplicar descuento al producto")]
        public int discountAmount { get; set; }

        [Required(ErrorMessage = "Es necesario que escriba el precio del producto")]
        [Display(Name = "Ingrese el precio del producto")]
        public double price { get; set; }

        [Required(ErrorMessage = "Es necesario que escriba el descuento aplicable al producto")]
        [Display(Name = "Ingrese el descuento aplicable al producto")]
        public double discount { get; set; }

        [Required(ErrorMessage = "Es necesario que añada una imagen al producto")]
        [Display(Name = "Ingrese una imagen para el producto")]
        public HttpPostedFileBase image { get; set; }

        public string fileType { get; set; }
    }
}