using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_network
{
    internal class Warstwa
    {
        public List<Neuron> Neurony;

        public Warstwa(int liczbaNeuronow, int liczbaWejsc, double ZDmin, double ZDmax)
        {
            Neurony = new List<Neuron>();
            for (int i = 0; i < liczbaNeuronow; i++)
            {
                Neuron nowyNeuron = new Neuron(liczbaWejsc, ZDmin, ZDmax);
                Neurony.Add(nowyNeuron);
            }
        }

        public List<double> Aktywacja(List<double> wejscia, double paramAktywacji)
        {
            List<double> wyjscia = new List<double>();
            foreach(Neuron neuron in Neurony)
            {
                wyjscia.Add(neuron.Aktywacja(wejscia, paramAktywacji));
            }

            return wyjscia;
        }
    }
}