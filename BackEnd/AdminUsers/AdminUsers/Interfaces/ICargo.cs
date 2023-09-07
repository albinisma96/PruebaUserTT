using AdminUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AdminUsers.Interfaces

{
    public interface ICargo
    {
        Task<List<Cargo>> GetList();

    }
}
