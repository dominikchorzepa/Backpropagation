using Neural_network;

namespace Neural_network_form
{
    public partial class FormSiecNeuronowa : Form
    {

        public FormSiecNeuronowa()
        {
            InitializeComponent();

            Application.ThreadException += new ThreadExceptionEventHandler(GlobalnyWyjatek);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalnyWyjatekDomeny);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxWyniki.Items.Clear();

            if (!int.TryParse(textBoxLiczbaEpok.Text, out int liczbaEpok))
            {
                MessageBox.Show("Nieprawid�owa liczba epok!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] warstwyString = textBoxRozmiarSieci.Text.Split('-');

            if (!double.TryParse(textBoxWspUczenia.Text, out double wspUczenia))
            {
                MessageBox.Show("Nieprawid�owy wsp�czynnik uczenia!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBoxParamBeta.Text, out double paramAktywacji))
            {
                MessageBox.Show("Nieprawid�owy parametr Beta!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBoxZDMin.Text, out double ZDMin))
            {
                MessageBox.Show("Nieprawid�owy parametr ZDMin!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBoxZDMax.Text, out double ZDMax))
            {
                MessageBox.Show("Nieprawid�owy parametr ZDMax!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Random rnd = new Random();

            List<int> rozmiarSieci = new List<int>();
            foreach (var w in warstwyString)
            {
                if (int.TryParse(w, out int rozmiar))
                {
                    rozmiarSieci.Add(rozmiar);
                }
                else
                {
                    MessageBox.Show("Nieprawid�owy rozmiar sieci!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var siec = new SiecNeuronowa(rozmiarSieci, wspUczenia, paramAktywacji, ZDMin, ZDMax);

            List<(List<double>, List<double>)> daneSieci = new();

            switch (comboBoxWyborDanych.SelectedItem.ToString())
            {
                case "XOR":
                    daneSieci = new List<(List<double>, List<double>)>
                    {
                        (new List<double> {0, 0 }, new List<double> { 0 }),
                        (new List<double> {0, 1 }, new List<double> { 1 }),
                        (new List<double> {1, 0 }, new List<double> { 1 }),
                        (new List<double> {1, 1 }, new List<double> { 0 }),
                    };
                    break;
                case "XOR + NOR":
                    daneSieci = new List<(List<double>, List<double>)>
                    {
                        (new List<double> {0, 0 }, new List<double> { 0, 1 }),
                        (new List<double> {0, 1 }, new List<double> { 1, 0 }),
                        (new List<double> {1, 0 }, new List<double> { 1, 0 }),
                        (new List<double> {1, 1 }, new List<double> { 0, 0 }),
                    };
                    break;
                case "Sumator":
                    daneSieci = new List<(List<double>, List<double>)>
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
                    break;
            }

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

                //if (epoka % 1000 == 0 || epoka == liczbaEpok - 1)
                //{
                //    listBoxWyniki.Items.Add("\nEpoka " + (epoka + 1) + " - B��d po: " + siec.ObliczBlad(daneSieci));
                //}
            }

            listBoxWyniki.Items.Add("\n--- Wyj�cie sieci po liczbie " + liczbaEpok + " epok ---");

            foreach (var (wejscia, wyjsciaOczekiwane) in daneSieci)
            {
                var wyjscie = siec.LiczenieWstepne(wejscia);

                string tekstWejscia = "";
                for (int i = 0; i < wejscia.Count; i++)
                {
                    tekstWejscia += wejscia[i].ToString();
                    tekstWejscia += " ";
                }

                string tekstWyjscia = "";
                for (int i = 0; i < wyjscie.Count; i++)
                {
                    tekstWyjscia += wyjscie[i].ToString("F4");
                    tekstWyjscia += " ";
                }

                string tekstOczekiwane = "";
                for (int i = 0; i < wyjsciaOczekiwane.Count; i++)
                {
                    tekstOczekiwane += wyjsciaOczekiwane[i].ToString("F4");
                    tekstOczekiwane += " ";
                }

                listBoxWyniki.Items.Add("Wej�cia: " + tekstWejscia + ", Wyj�cie sieci: " + tekstWyjscia + " (oczekiwane: " + tekstOczekiwane + ")");
            }
        }

        private void GlobalnyWyjatek(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Wyst�pi� nieoczekiwany b��d:\n" + e.Exception.Message, "B��d",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GlobalnyWyjatekDomeny(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show("Wyst�pi� krytyczny b��d:\n" + ex?.Message, "B��d",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
