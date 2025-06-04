using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace GlobalSolutionNoBreaker.Utils
{
    class SenhaUtils
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //Converte o password em um array de bytes e calcula o hash
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                //Cria um StringBuilder para armazenar o hash em formato hexadecimal
                StringBuilder sBuilder = new StringBuilder();

                //Itera sobre cada byte do hash e o converte para uma string hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static bool VerifyPassword(string password, string hash)
        {
            //Hash o resultado e compara com o armazenado
            string hashOfInput = HashPassword(password);
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }

        public static bool IsStrong(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;

            //Minimo 8 caracteres
            if (password.Length < 8)
                return false;

            //Pelo menos um caractere especial
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            // Pelo menos uma letra maiúscula
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // Pelo menos um dígito ou caracter especial
            if (!Regex.IsMatch(password, @"[\d\W_]"))
                return false;

            return true;
        }
    }

}
