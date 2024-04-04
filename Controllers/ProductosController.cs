using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosProductos.Data;
using UsuariosProductos.Models;
namespace UsuariosProductos.Controllers;

public class ProductosController : Controller {
    public readonly BaseContext _context;
    public ProductosController(BaseContext context) {
        _context = context;
    }
    public async Task<IActionResult> Index() {
        return View(await _context.Productos.ToListAsync()); 
    }

    public async Task<IActionResult> Detalles(int id) {
        return View(await _context.Productos.FirstOrDefaultAsync(m => m.Id == id));
    }

    public IActionResult Crear(){
            return View();
    }

    [HttpPost]
    public IActionResult Crear(Producto p){
        if(ModelState.IsValid){
            _context.Productos.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(p); 
    }

    public IActionResult Editar(int id){
       return View(_context.Productos.FirstOrDefault(m => m.Id == id));
    }

    [HttpPost]
    public IActionResult Editar(Producto p){
        if(ModelState.IsValid){
            _context.Productos.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(p);
    }

    public async Task<IActionResult> Eliminar(int id) {
        //Buscamos en la base de datos
        var producto = await _context.Productos.FindAsync(id);
        //Elimina un objeto del DbSet Productos que está dentro del contexto de la base de datos
        _context.Productos.Remove(producto);
        //Es responsable de guardar los cambios realizados en el contexto de la base de datos de forma asíncrona.       
        await _context.SaveChangesAsync();
        //Nos redirigimos a otra vista
        return RedirectToAction("Index");
    }
}