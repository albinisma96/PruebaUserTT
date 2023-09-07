namespace AdminUsers.Models
{
    public class Departamento
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
        public int idUsuarioCreacion { get; set; }
            
    }
}
