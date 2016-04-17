using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GetFileSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm a program!");
            
            //Draw form

            MainForm ourform = new MainForm();
            Application.Run(ourform);

            //end draw

            string input = getInput();
            Scanner s = new Scanner(input);
            //Display d = new Display();
            Console.ReadLine();
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

            private void DisplayGUI()
            {
                //this.Name = "WinForm Example";
                this.Text = "GetFileSize";
                this.Size = new Size(300, 400);
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
                /*MessageBox.Show(this.Bottom.ToString());
                MessageBox.Show(buttonSend.Bottom.ToString());

                MessageBox.Show(buttonSend.Height.ToString());
                MessageBox.Show(this.Top.ToString());
                MessageBox.Show(this.Bottom.ToString());
                int x = this.Bottom - buttonSend.Height;
                MessageBox.Show(x.ToString());
                MessageBox.Show(buttonSend.Top.ToString());
                MessageBox.Show(buttonSend.Bottom.ToString());*/

                this.Controls.Add(labelInput);
                this.Controls.Add(textBoxInput);
                this.Controls.Add(buttonSend);
                this.Show();
                

                return;
            }

            private void buttonSendClick(object source, EventArgs e)
            {
                MessageBox.Show("What are you doing??? Stop it!");
                MessageBox.Show(textBoxInput.Text);
            }
        }

        // END

            private static string getInput()
        {
            
            Console.WriteLine("Enter your username: ");
            string line = Console.ReadLine();            
            return line;
        }
    }

    class Scanner
    { 
        public string homeDir = "C:\\Users\\";

        public Scanner(string username)
        {
            homeDir =String.Concat(homeDir, username, "\\");
            Console.WriteLine(homeDir);
            //showDir();
            scan();
        }

        private void scan()
        {
            if (Directory.Exists(homeDir))
            {
                Console.Out.WriteLine("Scanning...");
                Console.WriteLine("subdirs:");
                string[] dirs = Directory.GetDirectories(homeDir);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("files:");
                string[] files = Directory.GetFiles(homeDir);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.Out.WriteLine("Home directory does not exists!");
            }
        }

        private string getFileSize()
        {
            string size = "";
            return size;
        }

        void showDir()
        {
            Console.Out.WriteLine("Going to scan " + homeDir + "\n");
        }
    }

    class Display
    {
        public Display()
        {
            Console.Out.WriteLine("I will display smth soon!");
        }
    }
}
