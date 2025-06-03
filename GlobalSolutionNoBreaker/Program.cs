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
            // Chama a função para garantir que o banco está criado
            DataMaker.CreateDatabase();
            Application.Run(new LoginForm());
        }
    }
}