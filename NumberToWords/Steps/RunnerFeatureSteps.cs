using NumberToWords.Logic;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace NumberToWords.Steps
{
    [Binding]
    public class RunnerFeatureSteps
    {

        private Runner _runner = new Runner();

        [Given(@"nothing yet")]
        public void GivenNothingYet()
        {

            _runner._numberConverter = new NumberConverter();
        }
        
        [Then(@"Create NumberConverter objet")]
        public void ThenCreateNumberConverterObjet()
        {
            Assert.IsInstanceOf( typeof(NumberConverter), _runner._numberConverter);
        }

        [Given(@"Input (.*)")]
        public void GivenInput(string p0)
        {
            _runner._numberConverter = new NumberConverter(p0);
        }

        [Then(@"Result is (.*) number")]
        public void ThenResultIsTwentyFive(string result)
        {
            Assert.That(_runner._numberConverter.GetNumberToWord, Is.EqualTo(result));
        }

    }
}
