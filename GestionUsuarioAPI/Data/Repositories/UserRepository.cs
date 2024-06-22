using GestionUsuarioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionUsuarioAPI.Data.Repositories;

public class UserRepository: IUserRepository
{
    private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsers()
        {
            return await _context.Usuarios.ToListAsync<Usuario>();
        }

        public async Task<Usuario> GetUserById(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m=>m.IdUser == id);

            if(usuario != null){
                return usuario;
            }else
            {
                return null;
            }
        }

        public async Task<Usuario> AddUser(Usuario user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Usuario> UpdateUser(Usuario user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public bool ExistUser(int id)
        {
            return _context.Usuarios.Any( e=>e.IdUser == id);
        }
}
