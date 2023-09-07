using AdminUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdminUsers.Interfaces;
using AdminUsers.Context;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AdminUsers.Services
{
    public class DepartamentoServices : IDepartamento
    {
        private Contexto _dbcontext;

        public DepartamentoServices()
        {
        }

        public DepartamentoServices(Contexto dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Departamento>> GetList()
        {
            try
            {
                List<Departamento> lista = new List<Departamento>();
                lista = await _dbcontext.departamentos.ToListAsync();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
