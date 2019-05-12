using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename1 = null;
            string filename2 = null;
            string path1 = null;
            string path2 = null;
            string fpath1 = null;
            string fpath2 = null;

            Console.WriteLine("-----Document Merger-----");
            Console.WriteLine("\n\n");

            while (!File.Exists(path1))
            {
                Console.WriteLine("Enter the name of the first file you want to merge: ");
                filename1 = Console.ReadLine();
                fpath1 = @"C:\Users\MCB10\Desktop\School Work\IT2040\Projects\Mod6\IT2040_DocumentMerger\{0}.txt";
                path1 = string.Format(fpath1, filename1);

                if (!File.Exists(path1))
                {
                    Console.WriteLine("File does not exist.");
                }
                else
                {
                    Console.WriteLine("File exists!");
                }
            }

            while (!File.Exists(path2))
            {
                if(filename2 == null)
                Console.WriteLine("Enter the name of the second file you want to merge: ");
                filename2 = Console.ReadLine();
                fpath2 = @"C:\Users\MCB10\Desktop\School Work\IT2040\Projects\Mod6\IT2040_DocumentMerger\{0}.txt";
                path2 = string.Format(fpath2, filename2);

                if (!File.Exists(path2))
                {
                    Console.WriteLine("File does not exist.");
                }
                else
                {
                    Console.WriteLine("File exists!");
                }
            }

            string[] files = {filename1, filename2 };
            var mergefile = string.Concat(files);
            mergefile += ".txt";
            string mergepath = @"C:\Users\MCB10\Desktop\School Work\IT2040\Projects\Mod6\IT2040_DocumentMerger\{0}";
            string path3 = string.Format(mergepath, mergefile);

            Console.WriteLine("\n{0}", mergefile);

            string[] file1 = File.ReadAllLines(path1);
            string[] file2 = File.ReadAllLines(path2);

            using (StreamWriter writer = File.CreateText(path3))
            {
                int lineNum = 0;
                while (lineNum < file1.Length || lineNum < file2.Length)
                {
                    if (lineNum < file1.Length)
                        writer.WriteLine(file1[lineNum]);
                    if (lineNum < file2.Length)
                        writer.WriteLine(file2[lineNum]);
                    lineNum++;
                }
            }

            int count = 0;
            string textcount = new System.IO.StreamReader(path3).ReadToEnd().Replace("\r\n", "\r");
            count = textcount.Length;
            Console.WriteLine("\nYour file, {0}, was saved! The document contains {1} characters.", mergefile, count);
            Console.ReadKey();
            


        }
    }
}
