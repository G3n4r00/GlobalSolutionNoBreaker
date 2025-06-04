using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Services
{
    class UsuarioServices
    {
        public static void AddUsuario(Usuario usuario)
        {
            if (!ValidaInput.IsValidEmail(usuario.Email))
                throw new ArgumentException("O email deve ser válido");



            Repositories.UsuarioRepository.RegisterUsuario(usuario);
        }
    }
}
