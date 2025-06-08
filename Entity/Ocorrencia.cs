using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowGuard.Entity
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }


}

