using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GlobalSolutionNoBreaker.Utils;
using GlobalSolutionNoBreaker.Models;

namespace GlobalSolutionNoBreaker.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de dados relacionadas aos usuários.
    /// Gerencia registro e autenticação de usuários no banco de dados SQLite.
    /// </summary>
    class UsuarioRepository
    {
        /// <summary>
        /// Registra um novo usuário no sistema.
        /// </summary>
        /// <param name="usuario">Objeto Usuario contendo os dados do usuário a ser registrado</param>
        /// <returns>
        /// true se o usuário foi registrado com sucesso;
        /// false se o usuário já existe ou ocorreu algum erro
        /// </returns>
        /// <remarks>
        /// Este método verifica se já existe um usuário com o email fornecido antes de realizar o registro.
        /// A senha é automaticamente hasheada antes de ser armazenada no banco de dados.
        /// </remarks>
        public static bool RegisterUsuario(Usuario usuario)
        {
            try
            {
                string email = usuario.Email;
                string senha = usuario.HashSenha;

                using (var connection = new SQLiteConnection($"Data Source={NobreakRepository.DbPath};Version=3;"))
                {
                    connection.Open();

                    // Verifica se o usuário já existe no banco de dados
                    string checkSql = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
                    using (var checkCommand = new SQLiteCommand(checkSql, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("Um usuário com este email já existe!");
                            return false;
                        }
                    }

                    // Gera o hash da senha para armazenamento seguro
                    string senhaHash = SenhaUtils.HashPassword(senha);

                    // Insere o novo usuário no banco de dados
                    string insertSql = @"INSERT INTO Usuarios (Email, senhaHash) 
                                   VALUES (@Email, @senhaHash)";
                    using (var command = new SQLiteCommand(insertSql, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@senhaHash", senhaHash);
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar usuário: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Autentica um usuário no sistema.
        /// </summary>
        /// <param name="usuario">Objeto Usuario contendo as credenciais de login (email e senha)</param>
        /// <returns>
        /// true se as credenciais são válidas e o login foi bem-sucedido;
        /// false se o email não existe, a senha está incorreta ou ocorreu algum erro
        /// </returns>
        /// <remarks>
        /// Este método busca o usuário pelo email e verifica se a senha fornecida
        /// corresponde ao hash armazenado no banco de dados.
        /// </remarks>
        public static bool LoginUsuario(Usuario usuario)
        {
            try
            {
                string email = usuario.Email;
                string password = usuario.HashSenha;

                using (var connection = new SQLiteConnection($"Data Source={NobreakRepository.DbPath};Version=3;"))
                {
                    connection.Open();

                    // Busca o hash da senha armazenado para o email fornecido
                    string sql = "SELECT senhaHash FROM Usuarios WHERE Email = @Email";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        object result = command.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Email não encontrado!");
                            return false;
                        }

                        string storedHash = result.ToString();

                        // Verifica se a senha fornecida corresponde ao hash armazenado
                        if (SenhaUtils.VerifyPassword(password, storedHash))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Senha incorreta!");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer login: " + ex.Message);
                return false;
            }
        }
    }
}