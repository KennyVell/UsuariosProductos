namespace UsuariosProductos.Models;

public class Producto {
    public int Id { get; set; }
    public string ImagenURL { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int UsuarioId { get; set; }
}