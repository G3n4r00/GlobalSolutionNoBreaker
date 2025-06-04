using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    public class Nobreak
    {
        public int Id { get; set; } // Gerado automaticamente pelo banco
        public string Modelo { get; set; }
        public string Localizacao { get; set; }
        public int CapacidadeVA { get; set; }
        public DateTime DataAquisicao { get; set; }
        public int VidaUtilAnos { get; set; }
        public int CicloCarga { get; set; }
    }
}
