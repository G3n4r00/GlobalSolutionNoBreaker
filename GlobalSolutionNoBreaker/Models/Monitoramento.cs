using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    class Monitoramento
    {
        public int Id { get; set; }
        public int NobreakId { get; set; } // Chave estrangeira para Nobreak
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int CargaAtualVA { get; set; }
        public int PorcentagemBateria { get; set; }
        public int CodigoEstado { get; set; }

    }
}
