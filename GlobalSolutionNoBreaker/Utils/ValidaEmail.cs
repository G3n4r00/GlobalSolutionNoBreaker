using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GlobalSolutionNoBreaker.Utils
{
    /// <summary>
    /// Classe utilitária para validação de endereços de email.
    /// Fornece métodos para verificar se um email possui formato válido.
    /// </summary>
    class ValidaEmail
    {
        /// <summary>
        /// Verifica se um endereço de email possui formato válido.
        /// </summary>
        /// <param name="email">Endereço de email a ser validado</param>
        /// <returns>
        /// true se o email possui formato válido;
        /// false se o email é nulo, vazio, contém apenas espaços ou possui formato inválido
        /// </returns>
        /// <remarks>
        /// Utiliza uma expressão regular simples que cobre a maioria dos casos comuns de email.
        /// O padrão verifica:
        /// - Pelo menos um caractere antes do @
        /// - Presença obrigatória do símbolo @
        /// - Pelo menos um caractere após o @ (domínio)
        /// - Presença obrigatória de um ponto no domínio
        /// - Pelo menos um caractere após o ponto (extensão)
        /// A validação é case-insensitive.
        /// </remarks>
        public static bool IsValidEmail(string email)
        {
            // Verifica se o email não é nulo, vazio ou contém apenas espaços
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Expressão regular simples que cobre a maioria dos casos comuns de email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Aplica a validação usando regex com opção case-insensitive
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}