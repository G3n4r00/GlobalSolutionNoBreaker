using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    class LogEvento
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string TipoEvento { get; set; }
        public string Retorno { get; set; }
        public int? UsuarioId { get; set; } // Chave estrangeira para Usuario (nullable)
        public int? NobreakId { get; set; } // Chave estrangeira para Nobreak (nullable)
        public int? IncidenteId { get; set; } // Chave estrangeira para Incidente (nullable)
        public int? MonitoramentoId { get; set; } // Chave estrangeira para Monitoramento (nullable)

    }
}
