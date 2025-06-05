using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite; 

namespace GlobalSolutionNoBreaker.Data
{
    public static class DataDeletion
    {
        public static string GetDatabasePath()
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "NobreakerSystemApp"
            );
            return Path.Combine(path, "NoBreakerSystem.db");
        }

        public static void DeleteDatabase()
        {
            string dbPath = GetDatabasePath();

            if (File.Exists(dbPath))
            {
                try
                {
                    
                    SQLiteConnection.ClearAllPools(); // Clears any active connections in the pool

                    File.Delete(dbPath);
                    Console.WriteLine("Database deleted successfully!");

                    // Optionally, delete the parent directory if it's empty
                    string parentDirectory = Path.GetDirectoryName(dbPath);
                    if (Directory.Exists(parentDirectory) && !Directory.EnumerateFileSystemEntries(parentDirectory).Any())
                    {
                        Directory.Delete(parentDirectory);
                        Console.WriteLine($"Parent directory '{parentDirectory}' also deleted as it was empty.");
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error deleting database: {ex.Message}");
                    Console.WriteLine("Please ensure no applications are currently using the database file.");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Error deleting database: {ex.Message}");
                    Console.WriteLine("Access denied. You might need administrator privileges to delete the file.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Database file does not exist. Nothing to delete.");
            }
        }
    }
}
