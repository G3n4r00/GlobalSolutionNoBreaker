using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    class Equipamento
    {

        public int Id { get; set; } 
        public string Nome { get; set; } 
        public string Tipo { get; set; } // Ex: Servidor, Máquina, Roteador, Respirador.
        public int NobreakId { get; set; } // Chave estrangeira para Nobreak

    }
}
