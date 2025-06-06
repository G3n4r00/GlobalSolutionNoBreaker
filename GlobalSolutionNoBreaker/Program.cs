using GlobalSolutionNoBreaker.Data;
using GlobalSolutionNoBreaker.Forms;
using GlobalSolutionNoBreaker.Repositories;

namespace GlobalSolutionNoBreaker
{
    /// <summary>
    /// Classe principal da aplica��o respons�vel pela inicializa��o do sistema.
    /// Configura o banco de dados e inicia a interface de usu�rio.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal da aplica��o.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Define a string de conex�o com o banco de dados SQLite
            string connectionString = $"Data Source={NobreakRepository.DbPath};Version=3;";

            // Inicializa as configura��es da aplica��o Windows Forms
            ApplicationConfiguration.Initialize();

            // Garante que o banco de dados est� criado e configurado
            // DataDeletion.DeleteDatabase(); // [COMENTADO] Remove o banco para reset completo
            DataMaker.CreateDatabase();

            // Popula o banco de dados com dados iniciais se necess�rio
            // DataPopulator.Populate(); // [COMENTADO] Dados de exemplo para desenvolvimento

            // Inicia a aplica��o com o formul�rio principal
            // Application.Run(new LoginForm()); // [COMENTADO] Formul�rio de login
            Application.Run(new MenuForm()); // Formul�rio principal do menu
        }
    }
}