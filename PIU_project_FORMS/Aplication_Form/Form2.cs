using LibrarieModele;
using NivelStocareDate;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplication_Form
{
    public partial class Form2 : Form
    {
        private Gestionare gestionare;
        private AdministrareFisier administrareFisier;
        public Form2()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            gestionare = new Gestionare();
            administrareFisier = new AdministrareFisier("cheltuieli.txt");

            int formWidth = (int)(Screen.PrimaryScreen.Bounds.Width * 0.8);
            int formHeight = (int)(Screen.PrimaryScreen.Bounds.Height * 0.8);
            this.Size = new Size(formWidth, formHeight);
            this.CenterToScreen();

            label1.Text = "Adauga cheltuieli";
            label2.Text = "Categoria:";
            label3.Text = "Suma:";
            label4.Text = "Data:";
            label1.Font = new Font(label1.Font.FontFamily, formWidth * 0.03f, FontStyle.Bold);
            label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);

            int labelMargin = (int)(formWidth * 0.03);
            int textBoxMargin = (int)(formWidth * 0.02);
            int buttonMargin = (int)(formWidth * 0.04);
            int verticalSpacing = (int)(formHeight * 0.04);

            label2.Font = new Font(label2.Font.FontFamily, formWidth * 0.015f);
            label3.Font = new Font(label3.Font.FontFamily, formWidth * 0.015f);
            label4.Font = new Font(label4.Font.FontFamily, formWidth * 0.015f);

            int labelWidth = Math.Max(label2.Width, Math.Max(label3.Width, label4.Width));
            int textBoxWidth = formWidth - labelWidth - labelMargin - textBoxMargin;

            label2.Location = new Point(labelMargin, label1.Location.Y + label1.Height + verticalSpacing);
            label3.Location = new Point(labelMargin, label2.Location.Y + label2.Height + verticalSpacing);
            label4.Location = new Point(labelMargin, label3.Location.Y + label3.Height + verticalSpacing);

            textBox1.Font = new Font(textBox1.Font.FontFamily, formWidth * 0.015f);
            textBox1.Size = new Size(textBoxWidth-100, textBox1.Height);
            textBox1.Location = new Point(label2.Location.X + labelWidth + textBoxMargin, label2.Location.Y);

            textBox2.Font = new Font(textBox2.Font.FontFamily, formWidth * 0.015f);
            textBox2.Size = new Size(textBoxWidth-100, textBox2.Height);
            textBox2.Location = new Point(label3.Location.X + labelWidth + textBoxMargin, label3.Location.Y);

            dateTimePicker1.Font = new Font(dateTimePicker1.Font.FontFamily, formWidth * 0.015f);
            dateTimePicker1.Size = new Size(textBoxWidth - 100, dateTimePicker1.Height);
            dateTimePicker1.Location = new Point(label4.Location.X + labelWidth + textBoxMargin, label4.Location.Y);

            button1.Font = new Font(button1.Font.FontFamily, formWidth * 0.015f, FontStyle.Bold);
            button1.Size = new Size((int)(formWidth * 0.2), button1.Height+50);
            button1.Location = new Point((this.Width - button1.Width) / 2, label4.Location.Y + label4.Height + verticalSpacing);

            button2.Font = new Font(button2.Font.FontFamily, formWidth * 0.015f, FontStyle.Bold);
            button2.Size = new Size((int)(formWidth * 0.2), button2.Height+50);
            button2.Location = new Point((this.Width - button2.Width) / 2, button1.Location.Y + button1.Height + buttonMargin);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string categoria = textBox1.Text;
            decimal suma = decimal.Parse(textBox2.Text);
            DateTime data = dateTimePicker1.Value;

            gestionare.AdaugaCheltuiala(categoria, suma, data);

            List<Cheltuiala> cheltuieliSortate = gestionare.SorteazaDupaCategorie();
            administrareFisier.ScrieInFisier(cheltuieliSortate);

            // Clear the input fields
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
