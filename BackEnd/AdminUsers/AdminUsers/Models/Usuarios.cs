using System.ComponentModel.DataAnnotations;

namespace AdminUsers.Models
{
    public class Usuario
    {
        
        public int id { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Departamento? idDepartamento { get; set; }
        public Cargo? idCargo { get; set; }
    }
}
