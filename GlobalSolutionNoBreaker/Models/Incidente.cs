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
        public string TipoIncidente { get; set; } // Ex: Falha de energia, Sobrecarga, Falha de bateria, etc.
        public string StatusAtual { get; set; } // Ex: Aberto, Em andamento, Resolvido, Cancelado
        public int Prioridade { get; set; } // 1=Alta, 2=Média, 3=Baixa
        public DateTime DataHora { get; set; } = DateTime.Now;

    }
}
