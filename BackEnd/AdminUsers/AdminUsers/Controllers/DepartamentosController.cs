using AdminUsers.Context;
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
    public class DepartamentosController : ControllerBase
    {
        private readonly Contexto _context;
        public DepartamentosController(Contexto context)
        {
            _context = context;
        }
        //Peticion Get: Obtener listado ded los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            return await _context.departamentos.Where(cargo => cargo.activo == true).ToListAsync();
        }

        


    }
}
