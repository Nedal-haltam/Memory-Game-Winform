using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Similar_Picture_game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private bool Invalid_Input()
        {
            return !comboBox1.Items.Contains(comboBox1.SelectedItem) || numericUpDown1.Value <= 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(Invalid_Input())
            {
                MessageBox.Show("Wrong Choices for the game", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form1 form = new Form1((byte)comboBox1.SelectedIndex, (int)numericUpDown1.Value);
            form.Show();

            this.Hide();


        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
