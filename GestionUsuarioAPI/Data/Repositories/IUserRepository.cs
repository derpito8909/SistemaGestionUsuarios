using GestionUsuarioAPI.Models;

namespace GestionUsuarioAPI.Data.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<Usuario>> GetAllUsers();
    Task<Usuario> GetUserById(int id);
    Task<Usuario> AddUser(Usuario user);
    Task<Usuario> UpdateUser(Usuario user);
    Task DeleteUser(int id); 

    bool ExistUser(int id);
}
