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
            Application.Run(new NobreakForm());
        }
    }
}