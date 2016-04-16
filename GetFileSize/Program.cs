using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFileSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm a program!");
            string input = getInput();
            Scanner s = new Scanner(input);
            //Display d = new Display();
            Console.ReadLine();
        }

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
