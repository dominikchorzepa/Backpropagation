namespace Neural_network
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

            List<double> wagi = new List<double> ();

            for (int i = 0; i < liczbaWag; i++)
            {
                double waga = rnd.NextDouble() * ZD + ZDMin;
                wagi.Add(waga);
            }

            for (int epoka = 0; epoka < liczbaEpok; epoka++)
            {
                foreach (var (wejscia, wyjscia) in daneSieci)
                {
                    double[] warstwaUkryta = new double[] {
                        Sigmoid(1 * wagi[0] + wejscia[0] * wagi[1] + wejscia[1] * wagi[2]),
                        Sigmoid(1 * wagi[3] + wejscia[0] * wagi[4] + wejscia[1] * wagi[5]),
                    };

                    double warstwaKoncowa = Sigmoid(1 * wagi[6] + warstwaUkryta[0] * wagi[7] + warstwaUkryta[1] * wagi[8]);
                   
                    double blad = wyjscia - warstwaKoncowa;
                   
                    double korektaWyjscia = wspUczenia * blad;
                  
                    double korektaWarstwyKoncowej = korektaWyjscia * paramAktywacji * warstwaKoncowa * (1 - warstwaKoncowa);
                 
                    List<double> korektyWagWarstwyUkrytej = new List<double>();

                    for (int i = 0; i < 2; i++)
                    {
                        if (i == 0)
                        {
                            double korektaWagiBias = korektaWarstwyKoncowej * 1;
                            korektyWagWarstwyUkrytej.Add(korektaWagiBias);
                        }
                        double korektaWagi = korektaWarstwyKoncowej * warstwaUkryta[i];
                        korektyWagWarstwyUkrytej.Add(korektaWagi);
                    }

                    List<double> korektyWejscWarstwyUkrytej = new List<double>();

                    for (int i = 0; i < warstwaUkryta.Length; i++)
                    {
                        double korektaWejscia = korektaWarstwyKoncowej * wagi[7 + i];
                        korektyWejscWarstwyUkrytej.Add(korektaWejscia);
                    }

                    List<double> korektyWarstwyPierwszej = new List<double>();

                    for (int i = 0; i < warstwaUkryta.Length; i++)
                    {
                        double korektaWarstwyPierwszej = korektyWejscWarstwyUkrytej[i] * paramAktywacji *
                            warstwaUkryta[i] * (1 - warstwaUkryta[i]);
                        korektyWarstwyPierwszej.Add(korektaWarstwyPierwszej);
                    }

                    List<double> korektyWagWarstwyPierwszej = new List<double>();

                    for (int i = 0; i < 2; i++)
                    {
                        double korektaWagiBias = korektyWarstwyPierwszej[i] * 1;
                        double korektaWagiWejscie1 = korektyWarstwyPierwszej[i] * wejscia[0];
                        double korektaWagiWejscie2 = korektyWarstwyPierwszej[i] * wejscia[1];
                        korektyWagWarstwyPierwszej.Add(korektaWagiBias);
                        korektyWagWarstwyPierwszej.Add(korektaWagiWejscie1);
                        korektyWagWarstwyPierwszej.Add(korektaWagiWejscie2);
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        wagi[i * 3 + 0] += korektyWagWarstwyPierwszej[i * 3 + 0];
                        wagi[i * 3 + 1] += korektyWagWarstwyPierwszej[i * 3 + 1];
                        wagi[i * 3 + 2] += korektyWagWarstwyPierwszej[i * 3 + 2];
                    }

                    wagi[6] += korektyWagWarstwyUkrytej[0];
                    wagi[7] += korektyWagWarstwyUkrytej[1];
                    wagi[8] += korektyWagWarstwyUkrytej[2];
                }

                for (int i = daneSieci.Count - 1; i > 0; i--)
                {
                    int j = rnd.Next(i + 1);
                    (daneSieci[i], daneSieci[j]) = (daneSieci[j], daneSieci[i]);
                }
            }

            Console.WriteLine("\n--- Wyjście sieci po liczbie " + liczbaEpok + " epok ---");

            foreach (var (wejscia, wyjscia) in daneSieci)
            {
                double[] warstwaUkryta = new double[]
                {
                    Sigmoid(1 * wagi[0] + wejscia[0] * wagi[1] + wejscia[1] * wagi[2]),
                    Sigmoid(1 * wagi[3] + wejscia[0] * wagi[4] + wejscia[1] * wagi[5]),
                };

                double warstwaKoncowa = Sigmoid(1 * wagi[6] + warstwaUkryta[0] * wagi[7] + warstwaUkryta[1] * wagi[8]);
                Console.WriteLine("Wejścia: " + wejscia[0] + " " + wejscia[1] + ", Wyjście sieci: " + Math.Round(warstwaKoncowa, 4) + " " + "(oczekiwane: " + wyjscia + ")");
            }
        }

        static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
