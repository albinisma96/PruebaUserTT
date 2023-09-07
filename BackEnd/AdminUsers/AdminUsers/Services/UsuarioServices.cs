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
    public class UsuarioServices : IUsuario
    {
        private Contexto _dbcontext;

        public UsuarioServices(Contexto dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Usuario> Get(int idUsuario)
        {
            try
            {
                Usuario? usuario = new Usuario();
                usuario = await _dbcontext.users.Include(dpt => dpt.idDepartamento).Where(e => e.id == idUsuario).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Usuario>> GetList()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                lista = await _dbcontext.users.ToListAsync();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async  Task<Usuario> Add(Usuario usuario)
        {
            try
            {
                _dbcontext.users.Add(usuario);
                await _dbcontext.SaveChangesAsync();
                return usuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Usuario usuario)
        {
            try
            {
                _dbcontext.users.Update(usuario);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Usuario usuario)
        {
            try
            {
                _dbcontext.users.Remove(usuario);
                await _dbcontext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
