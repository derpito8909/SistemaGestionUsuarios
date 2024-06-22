using System.ComponentModel.DataAnnotations;

namespace GestionUsuarios.Models;

public class Usuario
{
    public int IdUser { get; set; }
    [Required]
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string contrasena { get; set; } = string.Empty;
}
