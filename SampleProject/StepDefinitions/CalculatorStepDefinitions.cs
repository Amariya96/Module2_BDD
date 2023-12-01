using NUnit.Framework;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private int firstNumber, secondNumber, sum, difference;
        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 
            this.firstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            this.secondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic
            this.sum = this.firstNumber + this.secondNumber;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic
            Assert.AreEqual(this.sum, result);
        }

        [When(@"the second number is substracted from the first number")]
        public void WhenTheSecondNumberIsSubstractedFromTheFirstNumber()
        {
            this.difference = this.firstNumber - this.secondNumber;
        }

        [Then(@"the difference should be (.*)")]
        public void ThenTheDifferenceShouldBe(int result)
        {
            Assert.AreEqual(this.difference, result);
        }

    }
}