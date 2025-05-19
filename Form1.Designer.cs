namespace Neural_network_form
{
    partial class FormSiecNeuronowa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxWyniki = new ListBox();
            buttonTrenuj = new Button();
            label1LiczbaEpok = new Label();
            textBoxLiczbaEpok = new TextBox();
            label2RozmiarSieci = new Label();
            textBoxRozmiarSieci = new TextBox();
            label3wspUczenia = new Label();
            textBoxWspUczenia = new TextBox();
            label4paramBeta = new Label();
            textBoxParamBeta = new TextBox();
            label5ZDMin = new Label();
            textBoxZDMin = new TextBox();
            label6ZDMax = new Label();
            textBoxZDMax = new TextBox();
            comboBoxWyborDanych = new ComboBox();
            label7WyborDanych = new Label();
            SuspendLayout();
            // 
            // listBoxWyniki
            // 
            listBoxWyniki.FormattingEnabled = true;
            listBoxWyniki.Location = new Point(12, 141);
            listBoxWyniki.Name = "listBoxWyniki";
            listBoxWyniki.Size = new Size(827, 264);
            listBoxWyniki.TabIndex = 1;
            listBoxWyniki.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // buttonTrenuj
            // 
            buttonTrenuj.Location = new Point(12, 22);
            buttonTrenuj.Name = "buttonTrenuj";
            buttonTrenuj.Size = new Size(94, 29);
            buttonTrenuj.TabIndex = 2;
            buttonTrenuj.Text = "Trenuj sieć";
            buttonTrenuj.UseVisualStyleBackColor = true;
            buttonTrenuj.Click += button1_Click;
            // 
            // label1LiczbaEpok
            // 
            label1LiczbaEpok.AutoSize = true;
            label1LiczbaEpok.Location = new Point(148, 26);
            label1LiczbaEpok.Name = "label1LiczbaEpok";
            label1LiczbaEpok.Size = new Size(88, 20);
            label1LiczbaEpok.TabIndex = 3;
            label1LiczbaEpok.Text = "Liczba Epok";
            // 
            // textBoxLiczbaEpok
            // 
            textBoxLiczbaEpok.Location = new Point(148, 49);
            textBoxLiczbaEpok.Name = "textBoxLiczbaEpok";
            textBoxLiczbaEpok.Size = new Size(106, 27);
            textBoxLiczbaEpok.TabIndex = 4;
            textBoxLiczbaEpok.TextChanged += textBox1_TextChanged;
            // 
            // label2RozmiarSieci
            // 
            label2RozmiarSieci.AutoSize = true;
            label2RozmiarSieci.Location = new Point(270, 26);
            label2RozmiarSieci.Name = "label2RozmiarSieci";
            label2RozmiarSieci.Size = new Size(171, 20);
            label2RozmiarSieci.TabIndex = 5;
            label2RozmiarSieci.Text = "Rozmiar sieci (np. 2-2-2)";
            // 
            // textBoxRozmiarSieci
            // 
            textBoxRozmiarSieci.Location = new Point(270, 49);
            textBoxRozmiarSieci.Name = "textBoxRozmiarSieci";
            textBoxRozmiarSieci.Size = new Size(171, 27);
            textBoxRozmiarSieci.TabIndex = 6;
            // 
            // label3wspUczenia
            // 
            label3wspUczenia.AutoSize = true;
            label3wspUczenia.Location = new Point(456, 26);
            label3wspUczenia.Name = "label3wspUczenia";
            label3wspUczenia.Size = new Size(95, 20);
            label3wspUczenia.TabIndex = 7;
            label3wspUczenia.Text = "Wsp. uczenia";
            // 
            // textBoxWspUczenia
            // 
            textBoxWspUczenia.Location = new Point(456, 49);
            textBoxWspUczenia.Name = "textBoxWspUczenia";
            textBoxWspUczenia.Size = new Size(95, 27);
            textBoxWspUczenia.TabIndex = 8;
            // 
            // label4paramBeta
            // 
            label4paramBeta.AutoSize = true;
            label4paramBeta.Location = new Point(567, 26);
            label4paramBeta.Name = "label4paramBeta";
            label4paramBeta.Size = new Size(87, 20);
            label4paramBeta.TabIndex = 9;
            label4paramBeta.Text = "Param. beta";
            label4paramBeta.Click += label2_Click;
            // 
            // textBoxParamBeta
            // 
            textBoxParamBeta.Location = new Point(567, 49);
            textBoxParamBeta.Name = "textBoxParamBeta";
            textBoxParamBeta.Size = new Size(95, 27);
            textBoxParamBeta.TabIndex = 10;
            textBoxParamBeta.TextChanged += textBox3_TextChanged;
            // 
            // label5ZDMin
            // 
            label5ZDMin.AutoSize = true;
            label5ZDMin.Location = new Point(679, 26);
            label5ZDMin.Name = "label5ZDMin";
            label5ZDMin.Size = new Size(54, 20);
            label5ZDMin.TabIndex = 11;
            label5ZDMin.Text = "ZDMin";
            // 
            // textBoxZDMin
            // 
            textBoxZDMin.Location = new Point(679, 49);
            textBoxZDMin.Name = "textBoxZDMin";
            textBoxZDMin.Size = new Size(75, 27);
            textBoxZDMin.TabIndex = 12;
            // 
            // label6ZDMax
            // 
            label6ZDMax.AutoSize = true;
            label6ZDMax.Location = new Point(769, 26);
            label6ZDMax.Name = "label6ZDMax";
            label6ZDMax.Size = new Size(57, 20);
            label6ZDMax.TabIndex = 13;
            label6ZDMax.Text = "ZDMax";
            // 
            // textBoxZDMax
            // 
            textBoxZDMax.Location = new Point(769, 49);
            textBoxZDMax.Name = "textBoxZDMax";
            textBoxZDMax.Size = new Size(70, 27);
            textBoxZDMax.TabIndex = 14;
            // 
            // comboBoxWyborDanych
            // 
            comboBoxWyborDanych.FormattingEnabled = true;
            comboBoxWyborDanych.Location = new Point(148, 93);
            comboBoxWyborDanych.Name = "comboBoxWyborDanych";
            comboBoxWyborDanych.Size = new Size(151, 28);
            comboBoxWyborDanych.TabIndex = 15;
            comboBoxWyborDanych.Items.AddRange(new string[] { "XOR", "XOR + NOR", "Sumator" });
            comboBoxWyborDanych.SelectedIndex = 0;
            // 
            // label7WyborDanych
            // 
            label7WyborDanych.AutoSize = true;
            label7WyborDanych.Location = new Point(12, 96);
            label7WyborDanych.Name = "label7WyborDanych";
            label7WyborDanych.Size = new Size(99, 20);
            label7WyborDanych.TabIndex = 16;
            label7WyborDanych.Text = "Zbiór danych:";
            label7WyborDanych.Click += label1_Click;
            // 
            // FormSiecNeuronowa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 450);
            Controls.Add(label7WyborDanych);
            Controls.Add(comboBoxWyborDanych);
            Controls.Add(textBoxZDMax);
            Controls.Add(label6ZDMax);
            Controls.Add(textBoxZDMin);
            Controls.Add(label5ZDMin);
            Controls.Add(textBoxParamBeta);
            Controls.Add(label4paramBeta);
            Controls.Add(textBoxWspUczenia);
            Controls.Add(label3wspUczenia);
            Controls.Add(textBoxRozmiarSieci);
            Controls.Add(label2RozmiarSieci);
            Controls.Add(textBoxLiczbaEpok);
            Controls.Add(label1LiczbaEpok);
            Controls.Add(buttonTrenuj);
            Controls.Add(listBoxWyniki);
            Name = "FormSiecNeuronowa";
            Text = "Trenowanie Sieci Neuronowej";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxWyniki;
        private Button buttonTrenuj;
        private Label label1LiczbaEpok;
        private TextBox textBoxLiczbaEpok;
        private Label label2RozmiarSieci;
        private TextBox textBoxRozmiarSieci;
        private Label label3wspUczenia;
        private TextBox textBoxWspUczenia;
        private Label label4paramBeta;
        private TextBox textBoxParamBeta;
        private Label label5ZDMin;
        private TextBox textBoxZDMin;
        private Label label6ZDMax;
        private TextBox textBoxZDMax;
        private ComboBox comboBoxWyborDanych;
        private Label label7WyborDanych;
    }
}
