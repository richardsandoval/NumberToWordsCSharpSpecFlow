using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NumberToWords
{
    [Binding]
    public class NumberConverter
    {

        public int _number {set; get;}

        public NumberConverter(String number)
        {

            try
            {
                Int32 n = -1;

                n = Int32.Parse(number);
                Console.WriteLine("N = " + n);

                if (n < 0 ||  n > 9999)
                    throw new ParseNumberConvertException(n);
                else
                    this._number = n;
            }
            catch(ParseNumberConvertException e)
            {
                throw new ParseNumberConvertException(number);
            }catch(Exception e)
            {
                throw new ParseNumberConvertException(number);
            }

        }


        public String GetNumberToWord()
        {
            StringBuilder str = new StringBuilder();

            short length = (short) _number.ToString().Length;




            if ( length > 4)
                throw new ParseNumberConvertException(_number);

            if (length < 2)
                str.Append(Unit(_number));
            else
                str.Append(ThousandsUnit(_number));

            return str.ToString();
        }


        private String ThousandsUnit(int number)
        {
            int thousand = (int) Math.Floor( (decimal) Math.Abs(number / 1000) );
            int houndred = (int) number % 1000;

            StringBuilder thousandU = new StringBuilder(
                thousand != 0 ?
                Unit(thousand) + "Thousand " :
                "");

            thousandU.Append(HoundredUnit(houndred));

            return thousandU.ToString();
        }

        private String HoundredUnit(int number)
        {
            int houndred = (int)Math.Floor((decimal)Math.Abs(number / 100));
            int decim = (int)number % 100;

            StringBuilder houndredU = new StringBuilder(
                houndred != 0 ?
                Unit(houndred) + "Houndred " :
                "");

            houndredU.Append( DecimalUnit(decim) );

            return houndredU.ToString();
        }

        private String DecimalUnit(int number)
        {
            int decim = (int)Math.Floor((decimal)Math.Abs(number / 10));
            int unit = (int)number % 10;


            StringBuilder decimalU = new StringBuilder();

            if (number > 0 && number <= 9)
                decimalU.Append(Unit(number));
            else if (number > 9 && number < 20)
                decimalU.Append(SpecialDecimal(number));
            else
            {
                switch (decim)
                {
                    case 2:
                        decimalU.Append("Twenty ");
                        break;
                    case 3:
                        decimalU.Append("Thirty ");
                        break;
                    case 4:
                        decimalU.Append("Fourty ");
                        break;
                    case 5:
                        decimalU.Append("Fifty ");
                        break;
                    case 6:
                        decimalU.Append("Sixty ");
                        break;
                    case 7:
                        decimalU.Append("Seventy ");
                        break;
                    case 8:
                        decimalU.Append("Eighty ");
                        break;
                    case 9:
                        decimalU.Append("Ninety ");
                        break;

                }
                if(unit>0)
                    decimalU.Append(Unit(unit));
            }


            return decimalU.ToString();
        }

        private String SpecialDecimal(int special)
        {
            StringBuilder specialU = new StringBuilder();

            switch (special)
            {
                case 10:
                    specialU.Append("Ten ");
                    break;
                case 11:
                    specialU.Append("Eleven ");
                    break;
                case 12:
                    specialU.Append("Twelve ");
                    break;
                case 13:
                    specialU.Append("Thirteen ");
                    break;
                case 15:
                    specialU.Append("Fifteen ");
                    break;
                default:
                    specialU.Append( Unit( (Int16)(special % 10) ) );
                    specialU.Append("teen ");
                    break;
            }

            return specialU.ToString();
        }

        private String Unit(int unit)
        {
            StringBuilder unity = new StringBuilder();

            switch(unit){
                case 1:
                    unity.Append("One ");
                    break;
                case 2:
                    unity.Append("Two ");
                    break;
                case 3:
                    unity.Append("Three ");
                    break;
                case 4:
                    unity.Append("Four ");
                    break;
                case 5:
                    unity.Append("Five ");
                    break;
                case 6:
                    unity.Append("Six ");
                    break;
                case 7:
                    unity.Append("Seven ");
                    break;
                case 8:
                    unity.Append("Eight ");
                    break;
                case 9:
                    unity.Append("Nine ");
                    break;
                default:
                    unity.Append("Zero ");
                    break;
            }



            return unity.ToString();
        }

        public class ParseNumberConvertException : Exception
        {
            
            public ParseNumberConvertException(Int32 number) : base(String.Format("Number: {0} is invalid for convert", number))
            {

            }

            public ParseNumberConvertException(String character) : base(String.Format("\"{0}\" is not a valid number", character))
            {

            }

        }

    }
}
