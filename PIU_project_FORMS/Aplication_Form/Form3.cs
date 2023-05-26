using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LibrarieModele;

using NivelStocareDate;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aplication_Form
{
    public partial class Form3 : Form
    {
        private Gestionare gestionare;
        private AdministrareFisier administrareFisier;

        public Form3()
        {
            InitializeComponent();

            int formWidth = (int)(Screen.PrimaryScreen.Bounds.Width * 0.8);
            int formHeight = (int)(Screen.PrimaryScreen.Bounds.Height * 0.8);
            this.Size = new Size(formWidth, formHeight);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Centrarea formularului pe ecran
            this.CenterToScreen();

            label2.Text = string.Empty;

            gestionare = new Gestionare();
           
            administrareFisier = new AdministrareFisier("cheltuieli.txt");
            List<Cheltuiala> temp_cheltuieli = administrareFisier.CitesteDinFisier();
            foreach(Cheltuiala cheltuiala in temp_cheltuieli) {
                gestionare.AdaugaCheltuiala(cheltuiala);
            }

            button1.Location = new Point(this.Width - button1.Width - 50, this.Height - button1.Height - 50);
            button2.Location = new Point(50, this.Height - button2.Height - 50);
            int leftMargin = (this.Width - label1.Width) / 2;
            int topMargin = 50;

            label1.Location = new Point(leftMargin - 50, topMargin);
            textBox1.Location = new Point(leftMargin + 50, topMargin);
            label2.Location = new Point(leftMargin-150, topMargin + label1.Height + textBox1.Height + 100);

            label1.Font = new Font(label1.Font.FontFamily, 14, FontStyle.Regular);
            label2.Font = new Font(label2.Font.FontFamily, 14, FontStyle.Regular);




        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string categorie = textBox1.Text;

            

            List<Cheltuiala> cheltuieliGasite = gestionare.CautaDupaCategorie(categorie);

            if (cheltuieliGasite.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Cheltuiala cheltuiala in cheltuieliGasite)
                {
                    sb.AppendLine($"Categoria: {cheltuiala.Categoria}, Suma: {cheltuiala.Suma}, Data: {cheltuiala.Data}");
                }

                label2.Text = sb.ToString();
                
            }
            else
            {
                label2.Text = string.Empty;
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
