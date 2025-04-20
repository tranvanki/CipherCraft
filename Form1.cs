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
using System.Diagnostics;

namespace CipherCraft
{
    public partial class Form1 : Form
    {
        
        private string selectedEncoding = "Caesar(shift value)";
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
        private void buttonEncode_Click(object sender, EventArgs e)
        {


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

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonEncode_Click_1(object sender, EventArgs e)
        {
            try
            {
                string input = InputString.Text.Trim();
                int inputNumber = 0;
                encodingType selectedType;

                if (selectedEncoding == "Caesar(shift value)")
                {
                    if (!int.TryParse(InputNumber.Text, out inputNumber))
                       throw new ArgumentException("Please enter a valid Caesar shift " +
                           "(between -25 and 25).");

                    selectedType = encodingType.Caesar;
                }
                else if (selectedEncoding == "Base-64")
                {
                    selectedType = encodingType.Base64;
                }
              
                else
                {
                    throw new ArgumentException("Please select a valid encoding type.");
                }

                //Construct processor
                StringProcessing processor = new StringProcessing(input, inputNumber, selectedType);
                richTextBox1.Text = processor.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Encoding Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }





        private void label5_Click(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedEncoding = comboBox1.SelectedItem.ToString();

                // Enable or disable the input number box based on encoding
                if (selectedEncoding == "Caesar(shift value)")
                {
                    InputNumber.Enabled = true;
                }
                else
                {
                    InputNumber.Enabled = false;
                    InputNumber.Text = ""; // Optional: clear input number when not needed
                }
            }
        }
    }
    }

