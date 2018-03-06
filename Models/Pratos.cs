using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace app_restaurante.Models
{
    public class Pratos
    {
        
        [Required]
        [Display(Name = "Restaurante")]
        private string RestauranteNome
        {
            get;
            set;
        }
        [Key]
        [Display(Name = "Prato")]
        public string Nome
        {
            get;
            set;
        }
        [Required]
        [Display(Name = "Preço")]
        public float Preco
        {
            get;
            set;
        }
        public bool IsComplete { get; set; }
    }
}
