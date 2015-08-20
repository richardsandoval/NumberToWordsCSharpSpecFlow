using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NumberConverter n = new NumberConverter("S");

                Console.WriteLine(n.GetNumberToWord());

            }
            catch (NumberConverter.ParseNumberConvertException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
