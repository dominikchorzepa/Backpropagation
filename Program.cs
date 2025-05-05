namespace Backpropagation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paramAktywacji = 1;
            double wspUczenia = 0.3;
            double ZDMin = -5;
            double ZDMax = 5;
            double ZD = ZDMax - ZDMin;
            int liczbaEpok = 50000;
            int liczbaWag = 9;

            Random rnd = new Random();

            List<(int[], int)> daneSieci = new List<(int[], int)>
            {
                (new int[] { 0, 0 }, 0),
                (new int[] { 0, 1 }, 1),
                (new int[] { 1, 0 }, 1),
                (new int[] { 1, 1 }, 0),
            };

            List<double> wagi = new List<double>();

            for (int i = 0; i < liczbaWag; i++)
            {
                double waga = rnd.NextDouble() * ZD + ZDMin;
                Console.WriteLine("Waga " + i + ": " + waga);
                wagi.Add(waga);
            }

            foreach (double waga in wagi)
            {
                Console.WriteLine(waga);
            }

            foreach (var (wejscia, wyjscia) in daneSieci)
            {
                Console.WriteLine("Wejscia: " + wejscia[0] + wejscia[1] + ", wyjścia: " + wyjscia);

                double[] warstwaUkryta = new double[] {
                    Sigmoid(wejscia[0] * wagi[0] + wejscia[1] * wagi[1] + 1 * wagi[2]),
                    Sigmoid(wejscia[0] * wagi[3] + wejscia[1] * wagi[4] + 1 * wagi[5]),
                };

                for (int i = 0; i < warstwaUkryta.Length; i++)
                {
                    Console.WriteLine("Ukryte: " + warstwaUkryta[i]);
                }

                double warstwaKoncowa = Sigmoid(warstwaUkryta[0] * wagi[6] + warstwaUkryta[1] * wagi[7] + 1 * wagi[8]);
                Console.WriteLine("Końcowa: " + warstwaKoncowa);

                double blad = wyjscia - warstwaKoncowa;
                Console.WriteLine("Błąd: " + blad);

                double korekta = wspUczenia * (wyjscia - warstwaKoncowa);
                Console.WriteLine("Korekta: " + korekta);


            }

        }

        static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
