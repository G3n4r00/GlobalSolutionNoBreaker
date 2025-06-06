using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    public class Modelo
    {
        public int Id { get; set; } // PRIMARY KEY AUTOINCREMENT
        public string Nome { get; set; } // Nome do modelo
        public int CapacidadeVA { get; set; } // Potência do nobreak
        public int TempoDeGarantia { get; set; } // em anos
        public int TempoTrocaBateria { get; set; } // em anos
        public int VidaUtilAnos { get; set; } // em anos

    }
}
