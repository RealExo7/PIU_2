using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibrarieModele;

using NivelStocareDate;

namespace Aplication_Form
{
    public partial class Form4 : Form
    {
        private AdministrareFisier adminFisier;

        public Form4()
        {
            InitializeComponent();

            
            adminFisier = new AdministrareFisier("cheltuieli.txt");
            AfiseazaDate();
        }

        private void AfiseazaDate()
        {
            int formWidth = (int)(Screen.PrimaryScreen.Bounds.Width * 0.8);
            int formHeight = (int)(Screen.PrimaryScreen.Bounds.Height * 0.8);
            this.Size = new Size(formWidth, formHeight);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            button1.AutoSize = true;
            button1.Location = new Point(this.Width - button1.Width - 50, this.Height - button1.Height - 50);
            button2.Location = new Point(50, this.Height - button2.Height - 50);

            List<Cheltuiala> cheltuieli = adminFisier.CitesteDinFisier();

            int leftMargin = (this.Width - 450) / 2;
            int topMargin = 10;

            Label antetCategorie = new Label();
            antetCategorie.Text = "Categorie";
            antetCategorie.Font = new Font(antetCategorie.Font.FontFamily, 16);
            antetCategorie.AutoSize = true;
            antetCategorie.Location = new Point(leftMargin, topMargin);
            antetCategorie.ForeColor = Color.White;
            this.Controls.Add(antetCategorie);

            Label antetSuma = new Label();
            antetSuma.Text = "Suma";
            antetSuma.Font = new Font(antetSuma.Font.FontFamily, 16);
            antetSuma.AutoSize = true;
            antetSuma.Location = new Point(leftMargin + 150, topMargin);
            antetSuma.ForeColor = Color.White;
            this.Controls.Add(antetSuma);

            Label antetData = new Label();
            antetData.Text = "Data";
            antetData.Font = new Font(antetData.Font.FontFamily, 16);
            antetData.AutoSize = true;
            antetData.Location = new Point(leftMargin + 300, topMargin);
            antetData.ForeColor = Color.White;
            this.Controls.Add(antetData);

            topMargin += 30;

            foreach (Cheltuiala cheltuiala in cheltuieli)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Location = new Point(leftMargin - 20, topMargin);
                checkBox.ForeColor = Color.White;
                this.Controls.Add(checkBox);

                Label labelCategorie = new Label();
                labelCategorie.Text = cheltuiala.Categoria;
                labelCategorie.AutoSize = true;
                labelCategorie.Location = new Point(leftMargin, topMargin);
                labelCategorie.ForeColor = Color.White;
                this.Controls.Add(labelCategorie);

                Label labelSuma = new Label();
                labelSuma.Text = cheltuiala.Suma.ToString();
                labelSuma.AutoSize = true;
                labelSuma.Location = new Point(leftMargin + 150, topMargin);
                labelSuma.ForeColor = Color.White;
                this.Controls.Add(labelSuma);

                Label labelData = new Label();
                labelData.Text = cheltuiala.Data.ToShortDateString();
                labelData.AutoSize = true;
                labelData.Location = new Point(leftMargin + 300, topMargin);
                labelData.ForeColor = Color.White;
                this.Controls.Add(labelData);

                topMargin += 30;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<Cheltuiala> cheltuieli = adminFisier.CitesteDinFisier();
            List<Cheltuiala> cheltuieliNoi = new List<Cheltuiala>();

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                   
                }
                else if (control is Label label && label.Tag is Cheltuiala cheltuiala)
                {
                    cheltuieliNoi.Add(cheltuiala);
                }
            }
            Stream streamFisierText = File.Open("cheltuieli.txt", FileMode.Truncate);
            streamFisierText.Close();
            adminFisier.ScrieInFisier(cheltuieliNoi);

            this.Controls.Clear();
            InitializeComponent();
            AfiseazaDate();

            MessageBox.Show("Cheltuielile au fost actualizate cu succes!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
