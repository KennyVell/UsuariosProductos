using System.ComponentModel.DataAnnotations;

namespace UsuariosProductos.Models;

public class Usuario {
    public int Id { get; set; }
    [Required]
    public string Nombres { get; set; }
    [Required]
    public string Apellidos { get; set; }
    [Required]
    public string Correo { get; set; }
    [Required]
    public string Direccion { get; set; }
    [Required]
    public string Telefono { get; set; }
    [Required]
    public DateTime FechaNacimiento { get; set; }
}