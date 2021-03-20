using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTML_Extractor;

namespace Webscraper
{
    public partial class Form1 : Form
    {
        private const string imagesFoundText = "Images found: ";

        public Form1()
        {
            InitializeComponent();

            label2.Text = imagesFoundText + "0";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (input == string.Empty || input == " ")
            {
                MessageBox.Show("Url Can't be empty", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = string.Empty;
                return;
            }

            if (!Uri.IsWellFormedUriString(input, UriKind.Absolute))
            {
                MessageBox.Show("The Url must be sturctured correct", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                return;
            }
            HtmlExtract extract = new HtmlExtract();
            List<string> strList = extract.CallURL(input).Result;
            label2.Text = imagesFoundText + strList.Count.ToString();

            folderBrowserDialog1.ShowDialog();

            if (strList.Count <= 0)
            {
                MessageBox.Show("No Pictures", "Found Pics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                groupBox1.Visible = true;
                foreach (var item in strList)
                {
                    listBox1.Text = "Image" + item + Environment.NewLine;
                }
            }
        }
    }
}
