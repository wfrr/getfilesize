using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace GetFileSize
{
    class Program
    {
        static void Main(string[] args)
        {
            //Draw form

            MainForm ourform = new MainForm();
            Application.Run(ourform);
            //end draw

  

            /*
             * 
             * "getBiggestFiles()" should be called to get dictionary with 5 records
             * that is convenient to present in the gui
             * 
             * 
             * Scanner s = new Scanner();
             * object biggestFiles = s.getBiggestFiles(); 
             * 
             * 
             * Also "new Scanner(textBoxInput.Text)" to process input
             * 
             * 
             */

        }
        // HERE
        public class MainForm : Form
        {
            public MainForm()
            {
                DisplayGUI();                
            }

            private Button buttonSend;
            private Label labelInput;
            private TextBox textBoxInput;
           
            private ListView listViewOutput;
            private ListViewItem itemFaleName;
            private ListViewItem itemFaleSize;

            private void DisplayGUI()
            {
                //this.Name = "WinForm Example";
                this.Text = "GetFileSize";
                this.Size = new Size(500, 600);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.PaleTurquoise;
                
                //MessageBox.Show("bla-bla");
                //labelInput
                labelInput = new Label();
                labelInput.Text = "Enter your username: ";
                labelInput.Size = new Size(200, 20);
                labelInput.Location = new Point((this.Width / 2) - (labelInput.Width / 2), this.Top + 20);
                labelInput.Font = new Font("Tobota", 10, FontStyle.Bold);
                labelInput.TextAlign = ContentAlignment.MiddleCenter;

                //textBoxInput
                textBoxInput = new TextBox();
                textBoxInput.Text = "";
                textBoxInput.Size = new Size(labelInput.Width, labelInput.Height);
                textBoxInput.Location = new Point((this.Width / 2) - (textBoxInput.Width / 2), labelInput.Bottom + 20);
                textBoxInput.BackColor = Color.Ivory;
                textBoxInput.Font = new Font("Tobota", 10);

                //buttonSend
                buttonSend = new Button();
                //buttonSend.Name = "buttonSend";
                buttonSend.Text = "Send";
                buttonSend.Size = new Size(labelInput.Width / 2, labelInput.Height * 2);

                buttonSend.Location = new Point((this.Width / 2) - (buttonSend.Width / 2), this.Bottom - buttonSend.Height - 50);// STUDY IT!!!
                buttonSend.BackColor = Color.Ivory;
                buttonSend.Font = new Font("Tobota", 10, FontStyle.Bold);

                buttonSend.Click += new System.EventHandler(this.buttonSendClick);


                //listViewOutput
                listViewOutput = new ListView();
                itemFaleName = new ListViewItem();
                itemFaleSize = new ListViewItem();

                listViewOutput.View = View.Details;
                listViewOutput.Columns.Add("File", 250, HorizontalAlignment.Left);
                listViewOutput.Columns.Add("Size", 150, HorizontalAlignment.Left);

                itemFaleName.Text = "File";
                itemFaleSize.Text = "Size";
                
                listViewOutput.Size = new Size(400, 200);
                listViewOutput.Location = new Point((this.Width / 2) - (listViewOutput.Width / 2), textBoxInput.Bottom + 20);
                listViewOutput.Font = new Font("Tobota", 10, FontStyle.Bold);
                listViewOutput.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
                

                this.Controls.Add(labelInput);
                this.Controls.Add(textBoxInput);
                this.Controls.Add(buttonSend);

                this.Controls.Add(listViewOutput);

                this.Show();

                

                return;
            }

            private void buttonSendClick(object source, EventArgs e)
            {
                Scanner s = new Scanner(this.GetString());
               

                //object biggestFiles = s.getBiggestFiles();
                /*Dictionary<int, string>.KeyCollection keyColl = s.getBiggestFiles().Keys;
                foreach (int i in keyColl)
                {
                    MessageBox.Show(i.ToString());
                }*/
                int i = 0;
                foreach (KeyValuePair<int, string> kvp in s.getBiggestFiles())
                {
                    listViewOutput.Items.Add(kvp.Value.ToString());
                    listViewOutput.Items[i].SubItems.Add(kvp.Key.ToString());
                    i++;
                    //MessageBox.Show(kvp.Key.ToString());
                    //MessageBox.Show(kvp.Value.ToString());
                    //listViewOutput.Items[0].Text = "bla";
                    //listViewOutput.Items[0].SubItems.Add("hm"); //добавить в первую колонку
                    //listView.Items[index].SubItems.Add(testTextValue2);
                }
                //MessageBox.Show(s.getBiggestFiles().Values.ToArray().ToString());

                //labelOutput.Text = s.getBiggestFiles().GetType().ToString();
                //labelOutput.Text = s.getBiggestFiles().ToString();
            }
            
            public string GetString()
            {
                return textBoxInput.Text;
            }
        }

        // END
    }

    public class Scanner
    { 
        private string dir = "C:\\Users\\";
        private int numOfFiles = 5;
        private SortedDictionary<int, string> fileData = new SortedDictionary<int, string>();
        
        //StreamWriter outputFile = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\1.txt", true);


        public Scanner(string username)
        {
            dir =String.Concat(dir, username, "\\");
            if (checkInput())
            {
                scan(dir);
            }
            else
            {
                MessageBox.Show("Input error, try again");
            }
        }

        private bool checkInput() 
        {
            if (!Directory.Exists(dir))
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        private void scan(string dir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        fileData.Add(unchecked((int)new System.IO.FileInfo(f).Length), f);
                    }
                    scan(d);
                }
            }
            catch (System.Exception excpt)
            {
                //Console.WriteLine(excpt.Message);
            }            
        }

        //internal object getBiggestFiles()
        public Dictionary<int, string> getBiggestFiles()
        {
            Dictionary<int, string> biggestFiles = new Dictionary<int, string>();
            foreach (var x in fileData.Reverse())
            {
                //outputFile.WriteLine(x.Value + "\t" + x.Key);
                if (numOfFiles > 0)
                {
                    biggestFiles.Add(x.Key, x.Value);
                    numOfFiles--;
                }                  
                else
                    return biggestFiles;
            }
            return null; // in case of error
        }
    }
}
