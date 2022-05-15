using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomImageSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            Console.WriteLine();
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            if (args.Length != 3)
            {
                Console.WriteLine("Specify 3 params");
                Console.ReadLine();
                return;
            }

            var inputDir = args[0];
            var outpuDir = args[1];
            var countString = args[2];
            int count = 0;

            if (!int.TryParse(countString, out count))
            {
                count = 15;
            }

            var selector = new ImageSelector();
            selector.Initialise(inputDir, outpuDir, count);
            Console.WriteLine("Initialisation Complete...");
            
            selector.LoadImages();

            Console.WriteLine("Images Laoded...");            

            selector.SelectImages();
            Console.WriteLine("Images Selected...");

            selector.CheckOutput();
           
            Console.WriteLine();
            Console.WriteLine("Completed");
        }
    }
}
