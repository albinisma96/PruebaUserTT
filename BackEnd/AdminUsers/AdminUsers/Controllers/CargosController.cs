using AdminUsers.Context;
using AdminUsers.Models;
using AdminUsers.DTOs;
using AdminUsers.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AdminUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly Contexto _context;
        private readonly IMapper _mapper;
        private readonly CargoServices _cargoservice;
        public CargosController(Contexto context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Peticion Get: Obtener listado ded los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
            return await _context.cargos.Where(cargo => cargo.activo == true).ToListAsync();

        }


        //Peticion Get: Obtener listado de los cargos
        //[HttpGet]
        //public async Task<ActionResult<CargoReference>> GetCargos()
        //{
        //    var listcargos = await _context.cargos.ToListAsync();
        //    return _mapper.Map<CargoReference>(listcargos);
        //}


    }
}
