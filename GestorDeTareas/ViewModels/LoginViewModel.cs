using System.ComponentModel.DataAnnotations;

namespace GestorDeTareas.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre de usuario no puede estar vacío")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Ingrese sólo caracteres alfanuméricos sin espacios")]
        public string Nombre { get; set; }
    }
}