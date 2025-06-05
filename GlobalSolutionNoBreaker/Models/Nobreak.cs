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
        public int ModeloId { get; set; } // FK para Modelos(Id)
        public string Localizacao { get; set; }
        public DateTime DataAquisicao { get; set; }
        public DateTime? DataGarantia { get; set; } // Calculada a partir do modelo
        public DateTime? DataUltimaManutencao { get; set; }
        public DateTime? ProximaTrocaBateria { get; set; } // Calculada a partir do modelo
        public string StatusOperacional { get; set; }
        public int? NivelBateriaPercent { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
    }
}
