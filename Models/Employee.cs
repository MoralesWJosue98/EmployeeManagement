using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nombre del Empleado")]
        public string? NAME { get; set; }

        [Display(Name = "Ocupación")]
        public string? DESGINATION { get;set; }
        [DataType(DataType.MultilineText)]

        [Display(Name = "Dirección")]
        public string? ADDRESS { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime? RecordCreatedOn { get; set; }

    }
}
