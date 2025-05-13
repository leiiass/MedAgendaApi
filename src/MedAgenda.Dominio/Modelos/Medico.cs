namespace MedAgenda.Dominio.Modelos
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        // Relacionamento
        public int? EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
