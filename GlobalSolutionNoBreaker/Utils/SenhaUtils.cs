using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace GlobalSolutionNoBreaker.Utils
{
    /// <summary>
    /// Classe utilitária para operações relacionadas à segurança de senhas.
    /// Fornece métodos para gerar hash, verificar senhas e validar força da senha.
    /// </summary>
    class SenhaUtils
    {
        /// <summary>
        /// Gera o hash SHA256 de uma senha para armazenamento seguro.
        /// </summary>
        /// <param name="password">Senha em texto plano para ser hasheada</param>
        /// <returns>String contendo o hash SHA256 da senha em formato hexadecimal</returns>
        /// <remarks>
        /// Utiliza o algoritmo SHA256 para gerar um hash unidirecional da senha.
        /// O resultado é uma string hexadecimal de 64 caracteres.
        /// </remarks>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converte a senha em um array de bytes e calcula o hash
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Cria um StringBuilder para armazenar o hash em formato hexadecimal
                StringBuilder sBuilder = new StringBuilder();

                // Itera sobre cada byte do hash e o converte para uma string hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        /// <summary>
        /// Verifica se uma senha corresponde ao hash armazenado.
        /// </summary>
        /// <param name="password">Senha em texto plano a ser verificada</param>
        /// <param name="hash">Hash armazenado para comparação</param>
        /// <returns>
        /// true se a senha corresponde ao hash;
        /// false caso contrário
        /// </returns>
        /// <remarks>
        /// Gera o hash da senha fornecida e compara com o hash armazenado
        /// usando comparação case-insensitive para maior compatibilidade.
        /// </remarks>
        public static bool VerifyPassword(string password, string hash)
        {
            // Gera o hash da senha fornecida e compara com o hash armazenado
            string hashOfInput = HashPassword(password);
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }

        /// <summary>
        /// Verifica se uma senha atende aos critérios de segurança estabelecidos.
        /// </summary>
        /// <param name="password">Senha a ser validada</param>
        /// <returns>
        /// true se a senha atende a todos os critérios de segurança;
        /// false caso contrário
        /// </returns>
        /// <remarks>
        /// Critérios de validação:
        /// - Mínimo de 8 caracteres
        /// - Pelo menos uma letra minúscula
        /// - Pelo menos uma letra maiúscula
        /// - Pelo menos um dígito ou caractere especial
        /// </remarks>
        public static bool IsStrong(string password)
        {
            // Verifica se a senha não é nula ou vazia
            if (string.IsNullOrEmpty(password)) return false;

            // Verifica se tem mínimo de 8 caracteres
            if (password.Length < 8)
                return false;

            // Verifica se tem pelo menos uma letra minúscula
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            // Verifica se tem pelo menos uma letra maiúscula
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // Verifica se tem pelo menos um dígito ou caractere especial
            if (!Regex.IsMatch(password, @"[\d\W_]"))
                return false;

            return true;
        }
    }
}