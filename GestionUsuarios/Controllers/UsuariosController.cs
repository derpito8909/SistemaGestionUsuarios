using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionUsuarios.Models;
using GestionUsuarios.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestionUsuarios.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsuariosController(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetAllUsers());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userRepository.GetUserById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
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
        public async Task<IActionResult> Create([Bind("IdUser,Nombre,Email,contrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.AddUser(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userRepository.GetUserById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Nombre,Email,contrasena")] Usuario usuario)
        {
            if (id != usuario.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.UpdateUser(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUser))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _userRepository.GetUserById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userRepository.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _userRepository.ExistUser(id);
        }
    }
}
