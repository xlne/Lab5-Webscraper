using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTML_Extractor;

namespace Webscraper
{
    public partial class Form1 : Form
    {
        private const string imagesFoundText = "Images found: ";
        private List<string> imagesLinksList;
        private string url;

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
            url = input;
            HtmlExtract extract = new HtmlExtract();
            imagesLinksList = extract.CallURL(input).Result;
            label2.Text = imagesFoundText + imagesLinksList.Count.ToString();

            if (imagesLinksList.Count <= 0)
            {
                MessageBox.Show("No Pictures", "Found Pics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                groupBox1.Visible = true;
                foreach (var item in imagesLinksList)
                {
                    listBox1.Items.Add(input + item + Environment.NewLine);
                }
            }
        }

        private void saveToFolderButton_Click(object sender, EventArgs e)
        {
            if (imagesLinksList != null)
            {

                DialogResult result = folderBrowserDialog1.ShowDialog();
                //Task[] tasks = new Task[imagesLinksList.Count()];

                if (result == DialogResult.OK)
                {
                    string path = folderBrowserDialog1.SelectedPath;

                    TestAsync(path);
                }
            }
        }

        private void Output(string path)
        {
            Console.WriteLine(path);
        }
        //public System.Threading.Tasks.Task<byte[]> GetByteArrayAsync (Uri? requestUri);
        private async void TestAsync(string path)
        {
            IEnumerable<Task> urlTasks = imagesLinksList.Select((url, index) =>
            {
                if (index >= 5)
                    return null;

                WebClient wc = new WebClient();
                string filePath = string.Format("{0}image-{1}.png", path, index);

                //ha en kontrollsats - använda regex? 
                var downloadTask = wc.DownloadFileTaskAsync("https:" + url, filePath);
                Output(path);

                return downloadTask;
            });

            urlTasks = urlTasks.Take(urlTasks.Count() - 3);

            //foreach (var fileName in imagesLinksList)
            //{
            //    WebClient wClient = new WebClient();
            //    string filePath = string.Format("{0}image-{1}.jpg", path, index);

            //    using (File.Create(filePath = path + $"img{index}"))
            //    {
            //        Task task = wClient.DownloadFileTaskAsync("https:" + fileName, filePath);
            //        Output(path);
            //        tasks[index++] = task.ContinueWith(t => Output(filePath));
            //    }
            //}
            await Task.WhenAll(urlTasks);
            MessageBox.Show("Done");
        }
    }
}

