using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    class Incidente
    {
        public int Id { get; set; }
        public int NobreakId { get; set; } // Chave estrangeira para Nobreak
        public string TipoIncidente { get; set; }
        public string StatusAtual { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;

    }
}
