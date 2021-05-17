using FluentAssertions;
using TechTalk.SpecFlow;

namespace RandomPasswordGenerator.Specs.Steps
{
    [Binding]
    public sealed class PasswordStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private const string PasswordKey = "password";

        private readonly ScenarioContext myScenarioContext;

        public PasswordStepDefinitions(ScenarioContext scenarioContext)
        {
            this.myScenarioContext = scenarioContext;
        }

        [When(@"I generate a password")]
        public void WhenIGenerateAPassword()
        {
            var password = RandomPasswordGeneratorTest.RandomPasswordGenerator.GeneratePassword();
            myScenarioContext[PasswordKey] = password;
        }

        [Then(@"the password will be (.*) characters long")]
        public void ThenThePasswordWillBeCharactersLong(int requiredLength)
        {
            var password = (string)myScenarioContext[PasswordKey];
            password.Length.Should().Be(requiredLength);
        }
    }
}
