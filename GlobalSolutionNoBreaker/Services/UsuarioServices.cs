using GlobalSolutionNoBreaker.Models;
using GlobalSolutionNoBreaker.Repositories;
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
            if (UsuarioRepository.RegisterUsuario(usuario))
            {
                return; // Usuário registrado com sucesso
            }
            else
            {
                throw new Exception("Erro ao registrar usuário. Verifique os dados e tente novamente.");
            }
        }
    }
}
