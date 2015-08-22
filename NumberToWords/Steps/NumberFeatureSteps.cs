using System;
using TechTalk.SpecFlow;
using NumberToWords;
using NUnit.Framework;

namespace NumberToWords.Steps
{
    [Binding]
    public class NumberFeatureSteps
    {
        private  NumberConverter _numberToWords;
        private String e;


        [Given(@"I have entered (.*) into the converter")]
        public void GivenIHaveEnteredIntoTheConverter(string numberToConvert)
        {
            _numberToWords = new NumberConverter(numberToConvert);
            Assert.That(_numberToWords._number, Is.EqualTo(int.Parse(numberToConvert)));
        }
        
        [When(@"I press enter")]
        public void WhenIPressEnter()
        {
            Console.WriteLine("Pressed Enter Button");
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOneOnTheScreen(String words)
        {
            Assert.That(_numberToWords.GetNumberToWord().Substring(0,_numberToWords.GetNumberToWord().Length -1), Is.EqualTo(words));
        }

        [Given(@"I have entered (.*) into the number converter")]
        public void GivenIHaveEnteredAIntoTheNumberConverter(String numberToConvert)
        {
            try
            {
                _numberToWords = new NumberConverter(numberToConvert);
            }
            catch (Exception e)
            {
                this.e = e.Message;
            }
        }

        [Given(@"I press enter")]
        public void GivenIPressEnter()
        {
            Console.WriteLine("Pressed Enter Button");
        }


        [Then(@"the exception message should be (.*) on the screen")]
        public void ThenTheExceptionMessageShouldBeABCDIsNotAValidNumberOnTheScreen(string words)
        {
            Assert.That(e, Is.EqualTo(words));
        }


    }
}
