using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomImageSelector
{
    public class ImageSelector
    {
        public string InputDirectory;
        public string OutputDirectory;
        public int Count;
        public List<string> Images;
        public List<string> SelectedImages;

        public bool Initialise(string input, string output, int count)
        {
            if (count <= 0)
                return false;

            if (string.IsNullOrEmpty(input))
                return false;

            Count = count;
            InputDirectory = input;
            OutputDirectory = string.IsNullOrEmpty(output) ? InputDirectory + "/output" : output;

            Directory.CreateDirectory(OutputDirectory);

            var batchFolder = System.DateTime.Now.ToString();
            batchFolder = batchFolder.Replace(":", "");
            batchFolder = batchFolder.Replace("/", "");

            OutputDirectory += "\\" + batchFolder;

            Directory.CreateDirectory(OutputDirectory);

            return true;
        }

        public void LoadImages()
        {
            var files = Directory.GetFiles(InputDirectory);
            Images = files.ToList<string>();
        }

        public void SelectImages()
        {
            int min = 0;
            int max = Images.Count - 1;

            for (int i = 0; i < Count; i++)
            {
                var randomNumber = new Random().Next(min, max);
                var imagePath = Images[randomNumber];

                var outputPath = OutputDirectory + "\\" + i + "_" + Path.GetFileName(imagePath);
                
                File.Copy(imagePath, outputPath, true);
                Thread.Sleep(5);
            }
        }

        public void CheckOutput()
        {
            var files = Directory.GetFiles(OutputDirectory);

            Console.WriteLine($"Files copied:");
            Console.WriteLine();

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine($"Expected: {Count}");
            Console.WriteLine($"Total Number: {files.Length}");
        }
    }
}
