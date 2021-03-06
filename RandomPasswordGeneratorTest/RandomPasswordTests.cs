using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace RandomPasswordGeneratorTest
{
    //The next task is to write a random password generator.This is something I actually use when I need to set a password for something (if I can't be arsed to use my password manager).


    //The script I use makes a password 32 characters long with a mix of upper & lowercase letters, at least 2 numbers and at least 1 symbol.For symbols, I've limited them #![]{}?$%& to avoid problems with some awkward special characters.


    //So you can have a go at doing the same thing.You should use the Random class I mentioned above to help with it.

    //When doing it, think about how you can make sure you end up with a 32 character password that has the correct combination of letters, symbols & numbers - and always, feel free to ask any questions in here and we'll do our best to help.

    public class RandomPasswordTests
    {
        [Fact]
        public void PasswordShouldBe32CharactersLong()
        {
            var password = RandomPasswordGenerator.RandomPasswordGenerator.GeneratePassword();

            password.Length.Should().Be(32);
        }

        [Fact]
        public void PasswordShouldBeRandom()
        {
            var password1 = RandomPasswordGenerator.RandomPasswordGenerator.GeneratePassword();
            var password2 = RandomPasswordGenerator.RandomPasswordGenerator.GeneratePassword();

            password1.Should().NotBe(password2);
        }

        [Fact]
        public void PasswordShouldMeetTheContentRequirements()
        {
            // This will fail randomly if you run it like a billion times or using ReSharper's "until failure" mode
            var password = RandomPasswordGenerator.RandomPasswordGenerator.GeneratePassword();
            password.Count(char.IsUpper).Should()
                .BeGreaterOrEqualTo(1, $"the password {password} should contain at least 1 uppercase");
            password.Count(char.IsLower).Should()
                .BeGreaterOrEqualTo(1, $"the password {password} should contain at least 1 lowercase");
            password.Count(char.IsNumber).Should()
                .BeGreaterOrEqualTo(2, $"the password {password} should contain at least 2 numbers");
            password.Count(c => char.IsSymbol(c) || char.IsPunctuation(c)).Should()
                .BeGreaterOrEqualTo(1, $"the password {password} should contain at least 1 symbol");
        }

        //[Fact]
        //public void PasswordContentShouldBeInARandomOrder()
        //{
        //    false.Should().BeTrue();
        //}
    }
}
