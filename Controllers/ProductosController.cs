using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosProductos.Data;
using UsuariosProductos.Models;
using System.Linq.Expressions;
namespace UsuariosProductos.Controllers;

public class ProductosController : Controller {
    public readonly BaseContext _context;
    public ProductosController(BaseContext context) {
        _context = context;
    }
    public async Task<IActionResult> Index(string search) {
        var productos = from producto in _context.Productos select producto;
        if(!string.IsNullOrEmpty(search)){
            productos = productos.Where(p => p.Nombre.Contains(search));
            return View(await productos.ToListAsync());
        }
        return View(await productos.ToListAsync());
    }

    public async Task<IActionResult> Detalles(int id) {
        return View(await _context.Productos.FirstOrDefaultAsync(m => m.Id == id));
    }

    public IActionResult Crear(){
            return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Producto p){
        if(ModelState.IsValid){
            _context.Productos.Add(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(p); 
    }

    public async Task<IActionResult> Editar(int id){
       return View(await _context.Productos.FirstOrDefaultAsync(m => m.Id == id));
    }

    [HttpPost]
    public async Task<IActionResult> Editar(Producto p){
        if(ModelState.IsValid){
            _context.Productos.Update(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(p);
    }

    public async Task<IActionResult> Eliminar(int id) {
        //Buscamos en la base de datos
        var producto = await _context.Productos.FindAsync(id);
        //Elimina un objeto del DbSet Productos que está dentro del contexto de la base de datos
        _context.Productos.Remove(producto!);
        //Es responsable de guardar los cambios realizados en el contexto de la base de datos de forma asíncrona.       
        await _context.SaveChangesAsync();
        //Nos redirigimos a otra vista
        return RedirectToAction("Index");
    }
}