using Microsoft.EntityFrameworkCore;
using UsuariosProductos.Models;

namespace UsuariosProductos.Data;

public class BaseContext : DbContext {
    public BaseContext(DbContextOptions<BaseContext> options) : base(options) {

    }

    //Registramos los modelos
    public DbSet<Usuario> Usuarios { get; set; } 
    public DbSet<Producto> Productos { get; set; }
}