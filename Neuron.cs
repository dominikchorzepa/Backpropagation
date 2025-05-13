using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_network
{
    internal class Neuron
    {
        public List<double> wagi;

        public double wyjscie;
        public double korekta;

        public Neuron(int liczbaWejsc, double ZDmin, double ZDmax)
        {
            Random rnd = new Random();
            wagi = new List<double>();
            for (int i = 0; i < liczbaWejsc + 1; i++)
            {
                double waga = rnd.NextDouble() * (ZDmax - ZDmin) + ZDmin;
                wagi.Add(waga);
            }
        }

        public double Aktywacja(List<double> wejscia, double paramAktywacji)
        {
            double suma = wagi[0];
            for (int i = 0; i < wejscia.Count; i++)
            {
                suma += wejscia[i] * wagi[i + 1];
            }

            wyjscie = Sigmoid(suma, paramAktywacji);
            return wyjscie;
        }

        static double Sigmoid(double x, double paramAktywacji)
        {
            return 1 / (1 + Math.Exp(-paramAktywacji * x));
        }

    }
}
