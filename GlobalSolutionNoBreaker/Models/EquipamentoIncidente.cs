using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    class EquipamentoIncidente
    {
        public int IncidenteId { get; set; } // Parte da chave primária composta e chave estrangeira
        public int EquipamentoId { get; set; } // Parte da chave primária composta e chave estrangeira

    }
}
