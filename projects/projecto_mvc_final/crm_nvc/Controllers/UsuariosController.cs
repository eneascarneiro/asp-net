﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crm_mvc.Data;
using crm_mvc.Models;

namespace crm_mvc.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly crm_mvc_Context _context;

        public UsuariosController(crm_mvc_Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuario_logged = 0;
            //Comprobar con la sesion sin he validado usuario y password
            if (HttpContext.Session.GetInt32("UserLogged").HasValue)
            {
                 usuario_logged = (int)HttpContext.Session.GetInt32("UserLogged");
            }
           
            if (usuario_logged == 1){
                return View(await _context.Usuarios.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "LoginUsuarios");
            }
            
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }



        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,USUARIO,PASSWORD,CREATEDDATE,LASTLOGINDATE,ISACTIVE,EMAIL")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,USUARIO,PASSWORD,CREATEDDATE,LASTLOGINDATE,ISACTIVE,EMAIL")] Usuarios usuarios)
        {
            if (id != usuarios.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.ID == id);
        }
        // GET: Usuarios/DetailsName/5
        public async Task<IEnumerable<Usuarios>> DetailsName(string username)
        {
        
            List<Usuarios> Usr = new List<Usuarios>();
            if (username == null)
            {
                return null;
            }
            var usuarios = _context.Usuarios
                .FirstOrDefault(m => m.USUARIO == username);
            if (usuarios == null)
            {
                return null;
            }
            Usr.Add(usuarios);
            return Usr;
        }
        // GET: Usuarios/DetailsName
        public async Task<Usuarios> DetailsNameUsr(string username)
        {
            
            if (username == null)
            {
                return null;
            }
            var usuarios = _context.Usuarios
                .FirstOrDefault(m => m.USUARIO == username);
            if (usuarios == null)
            {
                return null;
            }
            return usuarios;
        }
    }
}