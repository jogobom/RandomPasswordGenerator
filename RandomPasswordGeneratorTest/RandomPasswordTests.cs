using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace RandomPasswordGeneratorTest
{
    //The next task is to write a random password generator.This is something I actually use when I need to set a password for something (if I can't be arsed to use my password manager).


    //The script I use makes a password 32 characters long with a mix of upper & lowercase letters, at least 2 numbers and at least 1 symbol.For symbols, I've limited them #![]{}£$%& to avoid problems with some awkward special characters.


    //So you can have a go at doing the same thing.You should use the Random class I mentioned above to help with it.

    //When doing it, think about how you can make sure you end up with a 32 character password that has the correct combination of letters, symbols & numbers - and always, feel free to ask any questions in here and we'll do our best to help.

    public class RandomPasswordTests
    {
        private static readonly Random RandomNumberGenerator = new();

        [Fact]
        public void PasswordShouldBe32CharactersLong()
        {
            var password = GeneratePassword();

            password.Length.Should().Be(32);
        }

        [Fact]
        public void PasswordShouldBeRandom()
        {
            var password1 = GeneratePassword();
            var password2 = GeneratePassword();

            password1.Should().NotBe(password2);
        }

        [Fact]
        public void PasswordShouldContainBothUppercaseAndLowercaseLetters()
        {
            var password = GeneratePassword();

            password.Any(c => char.IsUpper(c)).Should().BeTrue();
            password.Any(c => char.IsLower(c)).Should().BeTrue();
        }

        private static string GeneratePassword()
        {
            const string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890#![]{}£$%&";

            var randomChoice = RandomNumberGenerator.Next(validCharacters.Length);
            var c = validCharacters[randomChoice];
            return new string(c, 32);
        }
    }
}
