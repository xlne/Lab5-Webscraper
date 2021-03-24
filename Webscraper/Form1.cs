using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTML_Extractor;

namespace Webscraper
{
    public partial class Form1 : Form
    {
        private const string imagesFoundText = "Images found: ";
        private const string selectedItemsCountText = "Selected URLS count: ";

        private List<string> imagesURLSList;
        private string inputURL;

        public Form1()
        {
            InitializeComponent();
            imagesFoundLabel.Text = imagesFoundText + "0";
            selectedItemsCountLabel.Text = selectedItemsCountText + "0";
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
                MessageBox.Show("The Url must be structured correctly", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                return;
            }
            inputURL = input;
            HtmlExtract extract = new HtmlExtract();
            button1.Enabled = false;

            imagesURLSList = extract.CallURL(input).Result;

            button1.Enabled = true;
            imagesFoundLabel.Text = imagesFoundText + imagesURLSList.Count.ToString();

            if (imagesURLSList.Count <= 0)
            {
                MessageBox.Show("No Pictures found", "Found Pics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                groupBox1.Visible = true;
                foreach (var item in imagesURLSList)
                {
                    listBox1.Items.Add(item + Environment.NewLine);
                }
            }
        }

        private void ListBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
                foreach (object item in listBox1.SelectedItems)
                    copy_buffer.AppendLine(item.ToString());
                if (copy_buffer.Length > 0)
                    Clipboard.SetDataObject(copy_buffer.ToString());
            }
        }

        private async void saveToFolderButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("List box is empty. Please extract images from an url.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (imagesURLSList == null)
            {
                MessageBox.Show("URL is missing!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            IEnumerable<string> selectedURLS = listBox1.SelectedItems?.Cast<string>();
            if (selectedURLS == null || selectedURLS.Count() == 0)
            {
                selectedURLS = listBox1.Items.Cast<string>().Select(s => s.Replace("\n", "").Replace("\r", ""));
            } //TODO: URL:erna kan bli felformatterade sannolikt pga IEnumerable<string>.Cast funktionen. Måste buggfixas!


            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            groupBox1.Enabled = false;
            button1.Enabled = false;

            if (result == DialogResult.OK)
            {
                label2.Text = "Downloading images...";
                progressBar1.Minimum = 0;
                progressBar1.Maximum = selectedURLS.Count();
                progressBar1.Step = 1;

                string path = folderBrowserDialog1.SelectedPath;

                List<Task> downloadFileTasks = new List<Task>(); // lista med alla tasks som ska ladda ner bilder askynkront

                for (int i = 0; i < selectedURLS.Count(); i++)
                {
                    string imageURL = selectedURLS.ElementAt(i);

                    var wc = new WebClient();
                    {
                        Match formatMatch = Regex.Match(imageURL, @"\.(bmp|png|gif|jpg|jpeg)",
                            RegexOptions.IgnoreCase); // hitta bildformatet med regex.

                        if (formatMatch.Success)
                        {
                            string fileNameWOExt;
                            int counter = 1;
                            string[] fileNamesWOExtensions = Directory.GetFiles(path)
                                .Select(s => Path.GetFileNameWithoutExtension(s)).ToArray(); // hämtar alla filnamn utan format i destinationsmappen.

                            do
                            {
                                fileNameWOExt = $"img{i + counter}";
                                counter++;
                            } while (Array.Exists(fileNamesWOExtensions, s => s.Equals(fileNameWOExt, StringComparison.InvariantCultureIgnoreCase)));
                            
                            Task task;
                            try
                            {
                                task = wc.DownloadFileTaskAsync(imageURL, $"{path}\\{fileNameWOExt}{formatMatch.Value}"); // ladda ner bildfilen asynkront.

                                await task;
                                downloadFileTasks.Add(task);
                            }
                            catch (Exception)
                            {
                                
                            }
                        }
                        progressBar1.PerformStep();
                        label2.Text = $"Downloading images ({i + 1} of {selectedURLS.Count()}";
                    }
                }
                Task.WaitAll(downloadFileTasks.ToArray());

                label2.Text = "Progress bar:";
                progressBar1.Value = 0;

                MessageBox.Show("Done downloading!");  
            }

            groupBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedItemsCountLabel.Text = selectedItemsCountText + listBox1.SelectedItems.Count.ToString();
        }

        private void clearListBox1Button_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            imagesFoundLabel.Text = imagesFoundText + "0";
            selectedItemsCountLabel.Text = selectedItemsCountText + "0";
        }

        private void clearChoicesButton_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            selectedItemsCountLabel.Text = selectedItemsCountText + "0";

        }
    }
}

