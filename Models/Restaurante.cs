using System;   
using System.Collections.Generic;   
using System.Linq;   
using System.Threading.Tasks;   
using System.ComponentModel.DataAnnotations; 

namespace app_restaurante.Models
{
    public class Restaurante
    {
        
        [Key]
        [Display(Name = "Restaurante")]
        public string RestauranteNome {   
                get;   
                set;   
        }
        public bool IsComplete { get; set; }
    }
}
