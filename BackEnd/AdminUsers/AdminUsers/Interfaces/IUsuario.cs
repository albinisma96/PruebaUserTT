using AdminUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminUsers.Interfaces
{
    public interface IUsuario
    {

        Task<List<Usuario>> GetList();
        Task<Usuario> Get(int idUsuario);
        Task<Usuario> Add(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Delete(Usuario usuario);
    }
}
