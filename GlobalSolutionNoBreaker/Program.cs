using GlobalSolutionNoBreaker.Data;
using GlobalSolutionNoBreaker.Forms;
using GlobalSolutionNoBreaker.Repositories;

namespace GlobalSolutionNoBreaker
{
    /// <summary>
    /// Classe principal da aplicação responsável pela inicialização do sistema.
    /// Configura o banco de dados e inicia a interface de usuário.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal da aplicação.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Define a string de conexão com o banco de dados SQLite
            string connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";

            // Inicializa as configurações da aplicação Windows Forms
            ApplicationConfiguration.Initialize();

            // Garante que o banco de dados está criado e configurado
            // DataDeletion.DeleteDatabase(); // [COMENTADO] Remove o banco para reset completo
            DataMaker.CreateDatabase();

            // Popula o banco de dados com dados iniciais se necessário
            // DataPopulator.Populate(); // [COMENTADO] Dados de exemplo para desenvolvimento

            // Inicia a aplicação com o formulário principal
            // Application.Run(new LoginForm()); // [COMENTADO] Formulário de login
            Application.Run(new MenuForm()); // Formulário principal do menu
        }
    }
}