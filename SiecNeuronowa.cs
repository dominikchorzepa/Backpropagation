using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Neural_network
{
    internal class SiecNeuronowa
    {
        public List<Warstwa> Warstwy;
        public double WspUczenia;
        public double ParamAktywacji;

        public SiecNeuronowa(List<int> rozmiarSieci, double wspUczenia, double paramAktywacji, double ZDmin, double ZDmax)
        {
            WspUczenia = wspUczenia;
            ParamAktywacji = paramAktywacji;
            Warstwy = new List<Warstwa>();

            for (int i = 1; i < rozmiarSieci.Count; i++)
            {
                Warstwa nowaWarstwa = new Warstwa(rozmiarSieci[i], rozmiarSieci[i - 1], ZDmin, ZDmax);
                Warstwy.Add(nowaWarstwa);
            }
        }

        public List<double> LiczenieWstepne(List<double> wejscia)
        {
            List<double> wyjscia = wejscia;
            foreach (Warstwa warstwa in Warstwy)
            {
                wyjscia = warstwa.Aktywacja(wyjscia, ParamAktywacji);
            }
            return wyjscia;
        }

        void ObliczKorekteWyjscia(List<double> wyjsciaOczekiwane)
        {
            var warstwaWyjsciowa = Warstwy[Warstwy.Count - 1];

            for (int i = 0; i < warstwaWyjsciowa.Neurony.Count; i++)
                {
                    var neuron = warstwaWyjsciowa.Neurony[i];
                    double blad = wyjsciaOczekiwane[i] - neuron.wyjscie;
                    double korekta = WspUczenia * blad;
                    neuron.korekta = korekta;
                }
        }
    }
}