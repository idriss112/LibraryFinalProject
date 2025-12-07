namespace GestionBibliotheque.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable modern visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configure High-DPI support for sharp, modern displays
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            // Start the application with Form1 (we'll change this later to Login form)
            Application.Run(new FrmLogin());
        }
    }
}