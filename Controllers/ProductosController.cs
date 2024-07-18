using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosProductos.Data;
namespace UsuariosProductos.Controllers;

public class ProductosController : Controller {
    public readonly BaseContext _context;
    public ProductosController(BaseContext context) {
        _context = context;
    }
    public async Task<IActionResult> Index() {
        return View(await _context.Productos.ToListAsync()); 
    }

    public async Task<IActionResult> Detalles(int? id) {
        return View(await _context.Productos.FirstOrDefaultAsync(m => m.Id == id));
    }
}