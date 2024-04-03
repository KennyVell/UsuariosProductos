using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosProductos.Data;
namespace UsuariosProductos.Controllers;

public class UsuariosController : Controller {
    public readonly BaseContext _context;
    public UsuariosController(BaseContext context) {
        _context = context;
    }
    public async Task<IActionResult> Index() {
        return View(await _context.Usuarios.ToListAsync()); 
    }

    public async Task<IActionResult> Detalles(int? id) {
        return View(await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id));
    }
}