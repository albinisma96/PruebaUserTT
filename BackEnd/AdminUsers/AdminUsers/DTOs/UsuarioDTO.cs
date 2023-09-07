namespace AdminUsers.DTOs
{
    public class UsuarioDTO
    {


        public int id { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int idDepartamento { get; set; }
        public int idCargo { get; set; }
            
    }
}
