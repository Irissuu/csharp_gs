using System.ComponentModel.DataAnnotations;

namespace FlowGuard.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();
    }


}
