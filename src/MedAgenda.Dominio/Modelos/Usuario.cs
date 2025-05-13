namespace MedAgenda.Dominio.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TipoUsuario Tipo { get; set; }
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public int? MedicoId { get; set; }
        public Medico? Medico { get; set; }
    }
}
