namespace AdminUsers.Models
{
    public class Cargo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
        public int idUsuarioCreacion { get; set; }
    }
}
