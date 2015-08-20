using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NumberToWords.Logic
{
    [Binding]
    public class Runner
    {
        public NumberConverter _numberConverter { set; get; }
 

        public void run() {

            while (true)
            {
                Console.Write("Input: ");
                var s = Console.ReadLine();
                try { 
                    _numberConverter = new NumberConverter(s);
                    Console.WriteLine("Result: \"" + _numberConverter.GetNumberToWord()+"\"");
                }catch(Exception e)
                {
                    Console.WriteLine("Result: \"Not Suported\"" );
                }
            }
        }

    }
}
