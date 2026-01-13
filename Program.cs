using BayesianInference;

namespace BayesianNetwork
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        
    }
}