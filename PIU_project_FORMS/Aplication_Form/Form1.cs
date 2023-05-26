using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplication_Form
{
    public partial class Form1 : Form
    {
        private Label label1;
        public Form1()
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

            label1 = new Label();
            label1.Text = "Welcome";
            label1.Font = new Font(label1.Font.FontFamily, 56);
            button1.Font = new Font(button1.Font.FontFamily, 16);
            button2.Font = new Font(button2.Font.FontFamily, 16);
            button3.Font = new Font(button3.Font.FontFamily, 16);
            button4.Font = new Font(button4.Font.FontFamily, 16);
            label1.ForeColor = Color.White;

            label1.Size = new Size(500, 80);

            // Plasarea butoanelor în mijlocul ecranului
            int buttonWidth = 200;
            int buttonHeight = 75;
            int buttonSpacing = 50;
            int totalButtonWidth = (buttonWidth + buttonSpacing) * 3 - buttonSpacing;
            int buttonY = (formHeight - buttonHeight) / 2; // Ajustarea coordonatelor Y pentru a plasa butoanele mai sus
            int button1X = (formWidth - totalButtonWidth) / 2;
            int button2X = button1X + buttonWidth + buttonSpacing;
            int button3X = button2X + buttonWidth + buttonSpacing;

            button1.Size = new Size(buttonWidth, buttonHeight);
            button2.Size = new Size(buttonWidth, buttonHeight);
            button3.Size = new Size(buttonWidth, buttonHeight);

            button1.Location = new Point(button1X, buttonY);
            button2.Location = new Point(button2X, buttonY);
            button3.Location = new Point(button3X, buttonY);

            // Plasarea butonului 4 în colțul din dreapta jos
            int button4X = formWidth - buttonWidth - buttonSpacing;
            int button4Y = formHeight - buttonHeight - buttonSpacing;

            button4.Size = new Size(buttonWidth, buttonHeight);
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            int labelWidth = 500;
            int labelHeight = 80;
            int labelX = (formWidth - labelWidth) / 2;
            int labelY = (formHeight - labelHeight) / 4;
            label1.Location = new Point(labelX, labelY);
            label1.TextAlign = ContentAlignment.MiddleCenter;

            button4.Location = new Point(button4X, button4Y);

            this.Controls.Add(label1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
