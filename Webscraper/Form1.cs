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
        private List<string> imagesURLSList;
        private string inputURL;

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
            inputURL = input;
            HtmlExtract extract = new HtmlExtract();
            imagesURLSList = extract.CallURL(input).Result;
            label2.Text = imagesFoundText + imagesURLSList.Count.ToString();

            if (imagesURLSList.Count <= 0)
            {
                MessageBox.Show("No Pictures", "Found Pics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                groupBox1.Visible = true;
                foreach (var item in imagesURLSList)
                {
                    listBox1.Items.Add(input + item + Environment.NewLine);
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
            if (imagesURLSList != null)
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {            
                    string path = folderBrowserDialog1.SelectedPath;

                    List<Task> downloadFileTasks = new List<Task>(); // lista med alla tasks som ska ladda ner bilder askynkront

                    for (int i = 0; i < imagesURLSList.Count(); i++)
                    {
                        string imageURL = imagesURLSList[i];

                        var wc = new WebClient();
                        {
                            bool isAnotherDomain = imageURL.Contains("//"); // double slashes indikerar att bilden hämtas från en annan domän
                            string url = (isAnotherDomain ? "https:" + imageURL : inputURL); // bestäm vilken domän bilden ska hämtas ifrån
                            Match formatMatch = Regex.Match(url, @"\.(bmp|png|gif|jpg|jpeg)", RegexOptions.IgnoreCase); // hitta bildformatet med regex

                            if (formatMatch.Success)
                            {
                                Task task = wc.DownloadFileTaskAsync(url, path + $"\\img{i}{formatMatch.Value}"); // ladda ner bildfilen asynkront

                                await task;

                                downloadFileTasks.Add(task);
                            }
                        }
                    }
                    Task completionTask = Task.WhenAll(downloadFileTasks);

                    completionTask.Wait();

                    MessageBox.Show("Done");
                }

            
            }
        }
    }


    
}

