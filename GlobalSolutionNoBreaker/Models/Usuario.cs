using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Models
{
    class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashSenha { get; set; }

        public DateTime DataCriacao { get; set; }

    }
}
