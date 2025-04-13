using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace CipherCraft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private void richtextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonEncode_Click(object sender, EventArgs e) {

            try
            {
                string inputString = InputString.Text;
                int inputNumber = int.Parse(InputNumber.Text);
                //validate method

                

                StringProcessing stringProcessing = new StringProcessing(inputString, inputNumber);
                

                stringProcessing.Print();
                stringProcessing.ValidateInputs(inputString, inputNumber);
                string encodedString = stringProcessing.Print();
                richTextBox1.Text = encodedString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


     

        private void InputString_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            InputString.Text = "";
            InputNumber.Text = "";
            richTextBox1.Text = "";
        }
    }
}


