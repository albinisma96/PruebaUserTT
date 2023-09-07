using AdminUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AdminUsers.Interfaces

{
    public interface IDepartamento
    {
        Task<List<Departamento>> GetList();

    }
}
