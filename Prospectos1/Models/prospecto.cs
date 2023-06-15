//Creación de clase Modelos
//Contiene la delcaración de objetos y atributos

using System;
using System.ComponentModel.DataAnnotations;

namespace Prospectos1.Models
{
    //Declaración de objetos
    public class prospecto
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Apellidop")]
        public string Apellidop { get; set; }

        
        [StringLength(100)]
        [Display(Name = "Apellidom")]
        public string Apellidom { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "CodigoP")]
        public string CodigoP { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [StringLength(100)]
        [Display(Name = "Estatus")]
        public string Estatus { get; set; }
    }
    
}
