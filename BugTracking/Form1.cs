using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugTracking
{
    public partial class Form1 : Form
    {
        class ReportEntry
        {
            public TextBox fileTBox = new TextBox();
            public TextBox blockTBox = new TextBox();
            public Button previewButton = new Button();
            public Button removeButton = new Button();
            public int id;

            public ReportEntry(int _id)
            {
                previewButton.Text = "Preview";
                removeButton.Text = "Remove";
                fileTBox.MouseDown += new MouseEventHandler(fileTBox_MouseDown);
                previewButton.Click += new EventHandler(previewButton_Click);
                removeButton.Click += new EventHandler(removeButton_Click);
                id = _id;
            }

            public void UpdateLocation()
            {
                fileTBox.Location = new Point(30, 30 * id + 77);
                blockTBox.Location = new Point(150, 30 * id + 77);
                previewButton.Location = new Point(270, 30 * id + 75);
                removeButton.Location = new Point(350, 30 * id + 75);
            }

            private void fileTBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    OpenFileDialog fd = new OpenFileDialog();
                    // System.Diagnostics.Debug.WriteLine(fd != null);
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        fileTBox.Text = fd.FileName;
                    }
                }
            }

            public override string ToString()
            {
                const string blocksep = "\n++++++++++++++++++++"; // line to separate blocks of lines
                string result = "";

                // Parse the string for block of lines
                string[] arr = blockTBox.Text.Split(new Char[] { ';', ' ', ',', '.', ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int[] starts = new int[100];
                int[] ends = new int[100];
                int start;
                int end;
                string line = "";
                int i;
                int block;

                try
                {
                    for (i = 0; i < arr.Length; i++)
                    {
                        arr[i] = arr[i] + "-";
                        string[] startend = arr[i].Split('-');
                        starts[i] = Convert.ToInt32(startend[0]);
                        try
                        {
                            ends[i] = Convert.ToInt32(startend[1]);
                        }
                        catch
                        {
                            ends[i] = starts[i];
                        }
                        System.Diagnostics.Debug.WriteLine(String.Format("{0}-{1}", starts[i], ends[i]));
                    }

                    try
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader(fileTBox.Text);
                        result = fileTBox.Text + blocksep;
                        i = 0;

                        for (block = 0; block < arr.Length; block++)
                        {
                            start = starts[block];
                            end = ends[block];

                            while (!sr.EndOfStream && i < start)
                            {
                                i++;
                                line = sr.ReadLine();
                            }

                            while (!sr.EndOfStream && i <= end)
                            {
                                result = result + String.Format("\n{0,7} │{1}", i, line);
                                i++;
                                line = sr.ReadLine();
                            }
                            result = result + blocksep;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Entry {0}:\n{1}", id + 1, ex.Message));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Entry {0}:\nWrong number format", id + 1));
                }

                result = result + "\n";
                
                return result;
            }
            
            private void previewButton_Click(object sender, EventArgs e)
            {
                // System.Diagnostics.Debug.WriteLine("Preview button clicked");
                // Form parentForm = previewButton.Parent as Form1;
                // System.Diagnostics.Debug.WriteLine(parentForm != null); // Check if the button belongs to the main form

                // Tranfer control to previewPanel in the main form
                RichTextBox previewPanel = previewButton.Parent.Controls["previewPanel"] as RichTextBox;
                // previewPanel.AppendText("Test");
                previewPanel.Clear();
                previewPanel.AppendText(this.ToString());
            }

            private void removeButton_Click(object sender, EventArgs e)
            {
                // System.Diagnostics.Debug.WriteLine("Preview button clicked");

                // Tranfer control to the main form
                Form1 mainform = previewButton.Parent as Form1;

                // Remove all components of this entry from the main form
                mainform.Controls.Remove(fileTBox);
                mainform.Controls.Remove(blockTBox);
                mainform.Controls.Remove(previewButton);
                mainform.Controls.Remove(removeButton);

                // Remove this entry from the list
                for (int i = id + 1; i < mainform.report.Count; i++)
                {
                    mainform.report[i - 1] = mainform.report[i];
                    mainform.report[i - 1].id = i - 1;
                    mainform.report[i - 1].UpdateLocation();
                }
                mainform.report.RemoveAt(mainform.report.Count - 1);
            }
        }

        List<ReportEntry> report = new List<ReportEntry>();

        public void AddRemoveButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Add/Remove button clicked");
            AddNewEntry();
        }

        public void AddNewEntry()
        {
            ReportEntry newentry = new ReportEntry(report.Count);
            report.Add(newentry);
            newentry.UpdateLocation();
            // newentry.removeButton.Click += new EventHandler(AddRemoveButton_Click);
            this.Controls.Add(newentry.fileTBox);
            this.Controls.Add(newentry.blockTBox);
            this.Controls.Add(newentry.previewButton);
            this.Controls.Add(newentry.removeButton);
        }

        public Form1()
        {
            InitializeComponent();
            AddNewEntry();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddNewEntry();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = String.Format("Formula involving bug {0}.txt", bugnumTBox.Text);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, false);

                for (int i = 0; i < report.Count; i++)
                {
                    sw.WriteLine(report[i].ToString());
                }

                sw.Close();
                MessageBox.Show("Report created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}