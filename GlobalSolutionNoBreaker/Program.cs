using GlobalSolutionNoBreaker.Forms;
using GlobalSolutionNoBreaker.Data;


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
            ApplicationConfiguration.Initialize();
            // Chama a fun��o para garantir que o banco est� criado
            //DataDeletion.DeleteDatabase();
            DataMaker.CreateDatabase();
            //DataPopulator.Populate(); // Popula o banco de dados com dados iniciais
            //Application.Run(new LoginForm());
            Application.Run(new DashboardForm());
        }
    }
}