using System.Text.Json.Serialization;

namespace MedAgenda.Dominio.Modelos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoUsuario
    {
        Paciente,
        Medico
    }
}
