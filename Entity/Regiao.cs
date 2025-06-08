using System.ComponentModel.DataAnnotations;

namespace FlowGuard.Entity
{
    public class Regiao
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Distrito { get; set; }
    }
}

