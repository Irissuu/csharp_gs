namespace FlowGuard.Application.Response
{
    public class OcorrenciaResponseDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public int? UsuarioId { get; set; } 
    }
}