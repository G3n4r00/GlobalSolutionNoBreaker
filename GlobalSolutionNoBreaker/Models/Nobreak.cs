using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    public class Nobreak
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Localizacao { get; set; }
        public int CapacidadeVA { get; set; }
        public DateTime DataAquisicao { get; set; }
        public DateTime DataGarantia { get; set; } // Nullable DateTime
        public int VidaUtilAnos { get; set; }
        public DateTime? DataUltimaManutencao { get; set; } // Nullable DateTime
        public DateTime? ProximaTrocaBateria { get; set; } // Nullable DateTime
        public string StatusOperacional { get; set; }
        public int? NivelBateriaPercent { get; set; } // Nullable int
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; } // Nullable DateTime
        public string AtualizadoPor { get; set; }

    }
}
