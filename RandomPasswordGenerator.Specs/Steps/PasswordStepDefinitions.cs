using System.Linq;
using System.Threading;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace RandomPasswordGenerator.Specs.Steps
{
    [Binding]
    public sealed class PasswordStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private const string PasswordKey = "password";
        private const string Password2Key = "password2";

        private readonly ScenarioContext myScenarioContext;

        public PasswordStepDefinitions(ScenarioContext scenarioContext)
        {
            this.myScenarioContext = scenarioContext;
        }

        [When(@"I generate a password")]
        public void WhenIGenerateAPassword()
        {
            var password = RandomPasswordGenerator.GeneratePassword();
            myScenarioContext[PasswordKey] = password;
        }

        [Then(@"the password will be (.*) characters long")]
        public void ThenThePasswordWillBeCharactersLong(int requiredLength)
        {
            var password = (string)myScenarioContext[PasswordKey];
            password.Length.Should().Be(requiredLength);
        }

        [When(@"I generate another password")]
        public void WhenIGenerateAnotherPassword()
        {
            var password = RandomPasswordGenerator.GeneratePassword();
            myScenarioContext[Password2Key] = password;
        }

        [Then(@"the passwords will be different")]
        public void ThenThePasswordsWillBeDifferent()
        {
            var password = (string)myScenarioContext[PasswordKey];
            var password2 = (string)myScenarioContext[Password2Key];

            password2.Should().NotBe(password);
        }

        [Then(@"the password will contain at least (.*) uppercase character")]
        public void ThenThePasswordWillContainAtLeastUppercaseCharacter(int numberRequired)
        {
            var password = (string)myScenarioContext[PasswordKey];

            var numberOfUppercaseCharacters = password.Count(char.IsUpper);

            numberOfUppercaseCharacters.Should().BeGreaterOrEqualTo(numberRequired, $"the password {password} should contain some uppercase");
        }

        [Then(@"the password will contain at least (.*) lowercase character")]
        public void ThenThePasswordWillContainAtLeastLowercaseCharacter(int numberRequired)
        {
            var password = (string)myScenarioContext[PasswordKey];

            var numberOfLowercaseCharacters = password.Count(char.IsLower);

            numberOfLowercaseCharacters.Should().BeGreaterOrEqualTo(numberRequired, $"the password {password} should contain some lowercase");
        }

        [Then(@"the password will contain at least (.*) numeric characters")]
        public void ThenThePasswordWillContainAtLeastNumericCharacters(int numberRequired)
        {
            var password = (string)myScenarioContext[PasswordKey];

            var numberOfNumericCharacters = password.Count(char.IsNumber);

            numberOfNumericCharacters.Should().BeGreaterOrEqualTo(numberRequired, $"the password {password} should contain some numeric characters");
        }

        [Then(@"the password will contain at least (.*) of the characters ""(.*)""")]
        public void ThenThePasswordWillContainAtLeastOfTheCharacters(int numberRequired, string validSymbols)
        {
            var password = (string)myScenarioContext[PasswordKey];

            var numberOfValidSymbolCharacters = password.Count(validSymbols.Contains);

            numberOfValidSymbolCharacters.Should().BeGreaterOrEqualTo(numberRequired, $"the password {password} should contain some of the valid symbol characters");
        }
    }
}
