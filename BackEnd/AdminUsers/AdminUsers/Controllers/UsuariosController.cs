using AdminUsers.Context;
using AdminUsers.DTOs;
using AdminUsers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly Contexto _context;
        public UsuariosController(Contexto context)
        {
            _context = context;
        }
        //Peticion Get: Obtener listado ded los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsers()
        {
            return await _context.users.Include(opt => opt.idDepartamento).Include(opt=>opt.idCargo).ToListAsync();

        }
        [Route("Guardar")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Usuario>>> Post([FromBody] UsuarioDTO usuario)
        {
            try
            {
                Usuario newuser = new Usuario();
                var cargo = _context.cargos.FirstOrDefault(cargo => cargo.id == usuario.idCargo);
                var departamento = _context.departamentos.FirstOrDefault(departamento => departamento.id == usuario.idDepartamento);
                newuser.usuario = usuario.usuario;
                newuser.primerNombre = usuario.primerNombre;
                newuser.segundoNombre = usuario.segundoNombre;
                newuser.primerApellido = usuario.primerApellido;
                newuser.segundoApellido = usuario.segundoApellido;
                newuser.correo = usuario.correo;
                newuser.idCargo = cargo;
                newuser.idDepartamento = departamento;

                _context.users.Add(newuser);
                _context.SaveChanges();
                return Ok(newuser);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Put(int id, [FromBody] UsuarioDTO usuario)
        {
            try
            {
                    var searchuser = _context.users.FirstOrDefault(user => user.id == id);
                    if (searchuser != null)
                    {
                        var cargo = _context.cargos.FirstOrDefault(cargo => cargo.id == usuario.idCargo);
                        var departamento = _context.departamentos.FirstOrDefault(departamento => departamento.id == usuario.idDepartamento);
                        searchuser.usuario = usuario.usuario;
                        searchuser.primerNombre = usuario.primerNombre;
                        searchuser.segundoNombre = usuario.segundoNombre;
                        searchuser.primerApellido = usuario.primerApellido;
                        searchuser.segundoApellido = usuario.segundoApellido;
                        searchuser.correo = usuario.correo;
                        searchuser.idCargo = cargo;
                        searchuser.idDepartamento = departamento;
                        await _context.SaveChangesAsync();
                }
                    
                    return Ok(usuario);
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Delete(int id)
        {
            try
            {
                var usuario = _context.users.FirstOrDefault(f => f.id == id);
                if (usuario !=null)
                {
                    _context.users.Remove( usuario);
                    _context.SaveChanges();
                    return Ok(usuario);
                }
                else
                {
                    return BadRequest("No se encuentro el usuario a eliminar");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
