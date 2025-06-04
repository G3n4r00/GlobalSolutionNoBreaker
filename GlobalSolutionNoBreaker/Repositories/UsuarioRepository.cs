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
    class UsuarioRepository
    {
        public static bool RegisterUsuario(Usuario usuario)
        {
            try
            {
                string email = usuario.Email;
                string senha = usuario.HashSenha;

                using (var connection = new SQLiteConnection($"Data Source={NobreakRepository.DbPath};Version=3;"))
                {
                    connection.Open();

                    //Checa se o usuário já existe
                    string checkSql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
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

                    // Hash a senha
                    string senhaHash = SenhaUtils.HashPassword(senha);

                    // Insert new user
                    string insertSql = @"INSERT INTO Users (Email, senhaHash) 
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


        public static bool LoginUsuario(Usuario usuario)
        {
            try
            {
                string email = usuario.Email;
                string password = usuario.HashSenha;

                using (var connection = new SQLiteConnection($"Data Source={NobreakRepository.DbPath};Version=3;"))
                {
                    connection.Open();
                    string sql = "SELECT PasswordHash FROM Users WHERE Email = @Email";

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

                        // Verifica senha
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
