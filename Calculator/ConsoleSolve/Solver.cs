using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolve
{
    public class Solver
    {
        public Solver(string[] args)
        {
            string expression = "";
            for (int i = 0; i < args.Length; i++)
            {
                expression += args[i] + " ";
            }

            AnalaizerClass.AnalaizerClass analyzer = new AnalaizerClass.AnalaizerClass(expression);
            try
            {
                string res = analyzer.Estimate();
                Console.WriteLine(res);
            }
            catch (Exception exception)
            {
                string errorMessage = analyzer.lastError == "" ? exception.Message : analyzer.lastError;
                Console.WriteLine(errorMessage);
            }
            Console.ReadKey();
        }
    }
}
