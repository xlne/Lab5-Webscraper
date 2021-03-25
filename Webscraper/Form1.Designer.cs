
namespace Webscraper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearChoicesButton = new System.Windows.Forms.Button();
            this.clearListBox1Button = new System.Windows.Forms.Button();
            this.selectedItemsCountLabel = new System.Windows.Forms.Label();
            this.saveToFolderButton = new System.Windows.Forms.Button();
            this.imagesFoundLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearChoicesButton);
            this.groupBox1.Controls.Add(this.clearListBox1Button);
            this.groupBox1.Controls.Add(this.selectedItemsCountLabel);
            this.groupBox1.Controls.Add(this.saveToFolderButton);
            this.groupBox1.Controls.Add(this.imagesFoundLabel);
            this.groupBox1.Location = new System.Drawing.Point(7, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(754, 327);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Websites";
            // 
            // clearChoicesButton
            // 
            this.clearChoicesButton.Location = new System.Drawing.Point(314, 274);
            this.clearChoicesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearChoicesButton.Name = "clearChoicesButton";
            this.clearChoicesButton.Size = new System.Drawing.Size(101, 22);
            this.clearChoicesButton.TabIndex = 5;
            this.clearChoicesButton.Text = "Clear choices";
            this.clearChoicesButton.UseVisualStyleBackColor = true;
            this.clearChoicesButton.Click += new System.EventHandler(this.clearChoicesButton_Click);
            // 
            // clearListBox1Button
            // 
            this.clearListBox1Button.Location = new System.Drawing.Point(178, 275);
            this.clearListBox1Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearListBox1Button.Name = "clearListBox1Button";
            this.clearListBox1Button.Size = new System.Drawing.Size(82, 22);
            this.clearListBox1Button.TabIndex = 4;
            this.clearListBox1Button.Text = "Clear all";
            this.clearListBox1Button.UseVisualStyleBackColor = true;
            this.clearListBox1Button.Click += new System.EventHandler(this.clearListBox1Button_Click);
            // 
            // selectedItemsCountLabel
            // 
            this.selectedItemsCountLabel.AutoSize = true;
            this.selectedItemsCountLabel.Location = new System.Drawing.Point(21, 297);
            this.selectedItemsCountLabel.Name = "selectedItemsCountLabel";
            this.selectedItemsCountLabel.Size = new System.Drawing.Size(121, 15);
            this.selectedItemsCountLabel.TabIndex = 3;
            this.selectedItemsCountLabel.Text = "Selected URLS count: ";
            // 
            // saveToFolderButton
            // 
            this.saveToFolderButton.Location = new System.Drawing.Point(512, 282);
            this.saveToFolderButton.Name = "saveToFolderButton";
            this.saveToFolderButton.Size = new System.Drawing.Size(235, 45);
            this.saveToFolderButton.TabIndex = 2;
            this.saveToFolderButton.Text = "Save to folder:";
            this.saveToFolderButton.UseVisualStyleBackColor = true;
            this.saveToFolderButton.Click += new System.EventHandler(this.saveToFolderButton_Click);
            // 
            // imagesFoundLabel
            // 
            this.imagesFoundLabel.AutoSize = true;
            this.imagesFoundLabel.Location = new System.Drawing.Point(21, 282);
            this.imagesFoundLabel.Name = "imagesFoundLabel";
            this.imagesFoundLabel.Size = new System.Drawing.Size(86, 15);
            this.imagesFoundLabel.TabIndex = 1;
            this.imagesFoundLabel.Text = "Images found: ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(28, 146);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(706, 244);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Insert URL:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(398, 23);
            this.textBox1.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBox1, "Input something here");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 51);
            this.button1.TabIndex = 5;
            this.button1.Text = "Extract";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 98);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(228, 22);
            this.progressBar1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Progress bar:";
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 472);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebScraper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label imagesFoundLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button saveToFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label selectedItemsCountLabel;
        private System.Windows.Forms.Button clearListBox1Button;
        private System.Windows.Forms.Button clearChoicesButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
    }
}

