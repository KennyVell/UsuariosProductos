using System.ComponentModel.DataAnnotations;

namespace UsuariosProductos.Models;

public class Producto {
    public int Id { get; set; }
    [Required]
    public string ImagenURL { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]    
    public string Descripcion { get; set; }
    [Required]    
    public double Precio { get; set; }
    [Required]
    public int Cantidad { get; set; }
    [Required]
    public DateTime FechaVencimiento { get; set; }
    [Required]
    public int UsuarioId { get; set; }
}