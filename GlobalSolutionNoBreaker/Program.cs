using GlobalSolutionNoBreaker.Data;
using GlobalSolutionNoBreaker.Forms;
using GlobalSolutionNoBreaker.Repositories;


namespace GlobalSolutionNoBreaker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString =  $"Data Source={NobreakRepository.DbPath};Version=3;";;
            ApplicationConfiguration.Initialize();
            // Chama a função para garantir que o banco está criado
            //DataDeletion.DeleteDatabase();
            DataMaker.CreateDatabase();
            //DataPopulator.Populate(); // Popula o banco de dados com dados iniciais
            //Application.Run(new LoginForm());
            Application.Run(new NobreakForm());
        }
    }
}