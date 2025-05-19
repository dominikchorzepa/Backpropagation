using Neural_network_form;

namespace Neural_network
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSiecNeuronowa());

            int paramAktywacji = 1;
            double wspUczenia = 0.1;
            double ZDMin = -5;
            double ZDMax = 5;
            double ZD = ZDMax - ZDMin;
            int liczbaEpok = 50000;
            Random rnd = new Random();

            List<int> rozmiarSieci = new List<int> { 3, 3, 2, 2 };

            var siec = new SiecNeuronowa(rozmiarSieci, wspUczenia, paramAktywacji, ZDMin, ZDMax);

            List<(List<double>, List<double>)> daneSieci = new List<(List<double>, List<double>)>
            {
                (new List<double> {0, 0, 0 }, new List<double> { 0, 1 }),
                (new List<double> {0, 1, 0 }, new List<double> { 1, 0 }),
                (new List<double> {1, 0, 0 }, new List<double> { 1, 0 }),
                (new List<double> {1, 1, 0 }, new List<double> { 0, 1 }),
                (new List<double> {0, 0, 1 }, new List<double> { 1, 0 }),
                (new List<double> {0, 1, 1 }, new List<double> { 0, 1 }),
                (new List<double> {1, 0, 1 }, new List<double> { 0, 1 }),
                (new List<double> {1, 1, 1 }, new List<double> { 1, 1 }),
            };

            for (int epoka = 0; epoka < liczbaEpok; epoka++)
            {
                for (int i = daneSieci.Count - 1; i > 0; i--)
                {
                    int j = rnd.Next(i + 1);
                    (daneSieci[i], daneSieci[j]) = (daneSieci[j], daneSieci[i]);
                }

                foreach (var (wejscia, wyjsciaOczekiwane) in daneSieci)
                {
                    siec.Trenowanie(wejscia, wyjsciaOczekiwane);
                }

                if (epoka % 1000 == 0 || epoka == liczbaEpok - 1)
                {
                    Console.WriteLine("\nEpoka " + (epoka + 1) + " - Błąd po: " + siec.ObliczBlad(daneSieci));
                }
            }

            Console.WriteLine("\n--- Wyjście sieci po liczbie " + liczbaEpok + " epok ---");

            foreach (var (wejscia, wyjsciaOczekiwane) in daneSieci)
            {
                var wyjscie = siec.LiczenieWstepne(wejscia);
                Console.WriteLine("Wejścia: " + wejscia[0] + " " + wejscia[1] + " " + wejscia[2] + ", Wyjście sieci: " + Math.Round(wyjscie[0], 4) + " " + Math.Round(wyjscie[1], 4) + " (oczekiwane: " + wyjsciaOczekiwane[0] + ", " + wyjsciaOczekiwane[1] + ")");
            }
        }
    }
}