using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    public class NobreakDTO
    {
        public int Id { get; set; }            // ID do nobreak, pode ser 0 para novo
        public string Modelo { get; set; }
        public string Localizacao { get; set; }
        public string CapacidadeVA { get; set; }        // ainda é string (do TextBox)
        public DateTime DataAquisicao { get; set; }     // já vem em DateTime do DateTimePicker
        public string VidaUtil { get; set; }            // ainda é string
        public string CicloInicial { get; set; }        // pode ser vazio ou string
    }
}
