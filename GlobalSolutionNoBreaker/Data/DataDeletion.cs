using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GlobalSolutionNoBreaker.Data
{
    /// <summary>
    /// Classe estática responsável por operações de exclusão de dados e banco de dados.
    /// Fornece funcionalidades para localizar e remover o banco de dados SQLite da aplicação.
    /// </summary>
    public static class DataDeletion
    {
        /// <summary>
        /// Obtém o caminho completo para o arquivo de banco de dados SQLite.
        /// </summary>
        /// <returns>
        /// Uma string contendo o caminho completo para o arquivo NoBreakerSystem.db 
        /// localizado na pasta ApplicationData do usuário.
        /// </returns>
        /// <remarks>
        /// O banco de dados é armazenado em:
        /// %APPDATA%\NobreakerSystemApp\NoBreakerSystem.db
        /// </remarks>
        public static string GetDatabasePath()
        {
            // Obtém o caminho da pasta ApplicationData do usuário atual
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "NobreakerSystemApp"
            );

            // Combina o caminho da pasta com o nome do arquivo de banco de dados
            return Path.Combine(path, "NoBreakerSystem.db");
        }

        /// <summary>
        /// Exclui completamente o banco de dados SQLite e, opcionalmente, 
        /// o diretório pai se estiver vazio.
        /// </summary>
        /// <remarks>
        /// Este método:
        /// <list type="bullet">
        /// <item><description>Limpa todas as conexões ativas do pool de conexões SQLite</description></item>
        /// <item><description>Remove o arquivo de banco de dados do sistema de arquivos</description></item>
        /// <item><description>Remove o diretório pai se estiver vazio após a exclusão</description></item>
        /// <item><description>Trata exceções comuns como IOException e UnauthorizedAccessException</description></item>
        /// </list>
        /// </remarks>
        /// <exception cref="IOException">
        /// Lançada quando ocorre um erro de E/S, como arquivo em uso por outro processo.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// Lançada quando não há permissões suficientes para excluir o arquivo.
        /// </exception>
        /// <exception cref="Exception">
        /// Captura qualquer outra exceção não prevista durante o processo de exclusão.
        /// </exception>
        public static void DeleteDatabase()
        {
            // Obtém o caminho completo do banco de dados
            string dbPath = GetDatabasePath();

            // Verifica se o arquivo de banco de dados existe antes de tentar excluí-lo
            if (File.Exists(dbPath))
            {
                try
                {
                    // Limpa todas as conexões ativas no pool para evitar conflitos de acesso
                    SQLiteConnection.ClearAllPools(); // Clears any active connections in the pool

                    // Remove o arquivo de banco de dados
                    File.Delete(dbPath);
                    Console.WriteLine("Database deleted successfully!");

                    // Opcionalmente, remove o diretório pai se estiver vazio
                    string parentDirectory = Path.GetDirectoryName(dbPath);

                    // Verifica se o diretório existe e está vazio
                    if (Directory.Exists(parentDirectory) && !Directory.EnumerateFileSystemEntries(parentDirectory).Any())
                    {
                        // Remove o diretório vazio
                        Directory.Delete(parentDirectory);
                        Console.WriteLine($"Parent directory '{parentDirectory}' also deleted as it was empty.");
                    }
                }
                catch (IOException ex)
                {
                    // Trata erros de E/S, como arquivo em uso
                    Console.WriteLine($"Error deleting database: {ex.Message}");
                    Console.WriteLine("Please ensure no applications are currently using the database file.");
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Trata erros de permissão de acesso
                    Console.WriteLine($"Error deleting database: {ex.Message}");
                    Console.WriteLine("Access denied. You might need administrator privileges to delete the file.");
                }
                catch (Exception ex)
                {
                    // Captura qualquer outra exceção não prevista
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
            else
            {
                // Informa que o arquivo não existe
                Console.WriteLine("Database file does not exist. Nothing to delete.");
            }
        }
    }
}