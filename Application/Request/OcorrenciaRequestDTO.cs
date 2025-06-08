namespace FlowGuard.Application.Request
{
    public class OcorrenciaRequestDTO
    {
        public string Descricao { get; set; } = default!;
        public string Data { get; set; } = default!;
        public int UsuarioId { get; set; } 
    }
}