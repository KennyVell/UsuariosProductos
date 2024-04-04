using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuariosProductos.Data;
using UsuariosProductos.Models;
namespace UsuariosProductos.Controllers;

public class UsuariosController : Controller {
    public readonly BaseContext _context;
    public UsuariosController(BaseContext context) {
        _context = context;
    }
    public async Task<IActionResult> Index() {
        return View(await _context.Usuarios.ToListAsync()); 
    }

    public async Task<IActionResult> Detalles(int id) {
        return View(await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id));
    }

    public IActionResult Crear(){
        return View();
    }

    [HttpPost]
    public IActionResult Crear(Usuario u){
        //Agregar el usuario al DbSet
        _context.Usuarios.Add(u);
        //Guardamos los cambios realizados en el contexto de la base de datos
        _context.SaveChanges();
        //Nos redirigimos a otra vista
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Eliminar(int id) {
        //Buscamos en la base de datos
        var usuario = await _context.Usuarios.FindAsync(id);
        //Elimina un objeto del DbSet Usuarios que está dentro del contexto de la base de datos
        _context.Usuarios.Remove(usuario);
        //Es responsable de guardar los cambios realizados en el contexto de la base de datos de forma asíncrona.       
        await _context.SaveChangesAsync();
        //Nos redirigimos a otra vista
        return RedirectToAction("Index");
    }
}