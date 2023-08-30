using Microsoft.Extensions.Configuration;
using Serilog;

namespace Enderun
{
    internal static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            var test = $"{Configuration["LogFolder"]}\\{DateTime.Now.ToString("MM-dd-yyyy")}.log";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File($"{Configuration["LogFolder"]}\\{DateTime.Now.ToString("MM-dd-yyyy")}.log")
                .CreateLogger();
            Log.Information(Configuration["SystemMessages:A0"]);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}