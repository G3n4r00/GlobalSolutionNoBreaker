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
    /// <summary>
    /// Serviço responsável pelas regras de negócio relacionadas aos usuários.
    /// Coordena operações entre a camada de apresentação e o repositório de usuários.
    /// </summary>
    class UsuarioServices
    {
        /// <summary>
        /// Adiciona um novo usuário ao sistema.
        /// </summary>
        /// <param name="usuario">Objeto Usuario contendo os dados do usuário a ser registrado</param>
        /// <exception cref="Exception">
        /// Lançada quando não é possível registrar o usuário no sistema
        /// </exception>
        /// <remarks>
        /// Este método delega o registro ao UsuarioRepository e trata o resultado.
        /// Se o registro falhar (usuário já existe ou erro de banco), uma exceção é lançada.
        /// </remarks>
        public static void AddUsuario(Usuario usuario)
        {
            // Tenta registrar o usuário através do repositório
            if (UsuarioRepository.RegisterUsuario(usuario))
            {
                return; // Usuário registrado com sucesso
            }
            else
            {
                // Falha no registro - pode ser usuário duplicado ou erro de banco
                throw new Exception("Erro ao registrar usuário. Verifique os dados e tente novamente.");
            }
        }
    }
}