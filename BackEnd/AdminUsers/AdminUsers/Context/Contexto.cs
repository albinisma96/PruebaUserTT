using AdminUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminUsers.Context
{
    public class Contexto:DbContext
    {

        public Contexto(DbContextOptions<Contexto> options):base(options)
        {


        }

        //Crear nuestro dbset para nuestros modelos
        public DbSet<Usuario> users { get; set; }
        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Departamento> departamentos { get; set; }
    }
}
