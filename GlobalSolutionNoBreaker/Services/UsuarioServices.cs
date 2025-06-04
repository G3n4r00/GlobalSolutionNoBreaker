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
            try
            {
                if(Repositories.UsuarioRepository.RegisterUsuario(usuario))
                    ;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Erro ao inserir o usuário: " + ex.Message);
            }
        }
    }
}
