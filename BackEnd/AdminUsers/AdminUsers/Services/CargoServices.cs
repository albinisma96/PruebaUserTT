using AdminUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdminUsers.Context;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AdminUsers.Services;
using AdminUsers.Interfaces;

namespace AdminUsers.Services
{
    public class CargoServices : ICargo
    {

        private Contexto _dbcontext;

        public CargoServices(Contexto dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Cargo>> GetList()
        {
            try
            {
                var lista = await _dbcontext.cargos.ToListAsync();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
