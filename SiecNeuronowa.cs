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

        public void Trenowanie(List<double> wejscia, List<double> wyjsciaOczekiwane)
        {
            var wyjscia = LiczenieWstepne(wejscia);
            ObliczKorekteWyjscia(wyjsciaOczekiwane);
            ObliczKorektyWarstwUkrytych();
            AktualizujWagi(wejscia); 
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

        void ObliczKorektyWarstwUkrytych()
        {
            for (int w = Warstwy.Count - 2; w >= 0; w--)
            {
                var obecnaWarstwa = Warstwy[w];
                var nastepnaWarstwa = Warstwy[w + 1];

                for (int i = 0; i < obecnaWarstwa.Neurony.Count; i++)
                {
                    double korektaWarstwyUkrytej = 0;
                    for (int j = 0; j < nastepnaWarstwa.Neurony.Count; j++)
                    {
                        korektaWarstwyUkrytej += nastepnaWarstwa.Neurony[j].korekta * nastepnaWarstwa.Neurony[j].wagi[i + 1];
                    }

                    var neuron = obecnaWarstwa.Neurony[i];
                    neuron.korekta = korektaWarstwyUkrytej * ParamAktywacji * neuron.wyjscie * (1 - neuron.wyjscie);
                }
            }
        }

        void AktualizujWagi(List<double> wejscia)
        {
            List<double> wejsciaDoWarstwy = new List<double>(wejscia);

            for (int w = 0; w < Warstwy.Count; w++)
            {
                if (w > 0)
                {
                    wejsciaDoWarstwy = new List<double>();
                    for (int j = 0; j < Warstwy[w - 1].Neurony.Count; j++)
                    {
                        wejsciaDoWarstwy.Add(Warstwy[w - 1].Neurony[j].wyjscie);
                    }
                }

                for (int i = 0; i < Warstwy[w].Neurony.Count; i++)
                {
                    var neuron = Warstwy[w].Neurony[i];
                    neuron.wagi[0] += neuron.korekta * 1;

                    for (int j = 0; j < wejsciaDoWarstwy.Count; j++)
                    {
                        neuron.wagi[j + 1] += neuron.korekta * wejsciaDoWarstwy[j];
                    }
                }
            }
        }

        public double ObliczBlad(List<(List<double>, List<double>)> daneSieci)
        {
            double modulBledu = 0;
            foreach (var k in daneSieci)
            {
                List<double> wejscia = k.Item1;
                List<double> wyjsciaOczekiwane = k.Item2;
                List<double> wyjscia = LiczenieWstepne(wejscia);

                for (int i = 0; i < wyjscia.Count; i++)
                {
                    modulBledu = Math.Abs(wyjsciaOczekiwane[i] - wyjscia[i]);
                }
            }
            return modulBledu;
        }
    }
}