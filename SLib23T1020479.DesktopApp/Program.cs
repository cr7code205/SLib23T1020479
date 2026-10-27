namespace SLib23T1020479.DesktopApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            string connectionString = string connectionString = "Server=thach;Database=LibraryManagementDB;Integrated Security=True;TrustServerCertificate=True;";

            ServiceManager.Initialize(connectionString);

            Application.Run(new FormMain());
        }
    }
}