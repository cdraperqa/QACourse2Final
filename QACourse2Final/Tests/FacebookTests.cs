using OpenQA.Selenium;
using QACourse2Final.PageObjectModels;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions.Execution;
using OpenQA.Selenium.Interactions;

namespace QACourse2Final.Tests
{
    public sealed class FacebookTests : BaseTest
    {
        FacebookLoginPage _facebookLoginPage;

        #region PrivateConstants

        private const string _facebookUserLogin = "PantsMcpantsertonJr@outlook.com";
        private const string _facebookUserPassword = "Le@therPants1";
        private const string _facebookBadLogin = "B@dAccount!";

        #endregion Private Constants

        public FacebookTests()
        {
            _facebookLoginPage = new FacebookLoginPage();
        }

        [Fact]
        public void SuccessfulLoginTest()
        {
            //arrange
            Driver.Navigate().GoToUrl(_facebookLoginPage.Url);
            Driver.Manage().Window.Maximize();

            //act
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_facebookLoginPage.UsernameInput).Displayed);

            Driver.FindElement(_facebookLoginPage.UsernameInput).Clear();
            Driver.FindElement(_facebookLoginPage.UsernameInput).SendKeys(_facebookUserLogin);

            wait.Until(c => Driver.FindElement(_facebookLoginPage.PasswordInput).Displayed);

            Driver.FindElement(_facebookLoginPage.PasswordInput).Clear();
            Driver.FindElement(_facebookLoginPage.PasswordInput).SendKeys(_facebookUserPassword);

            Driver.FindElement(_facebookLoginPage.LoginButton).Click();

            wait.Until(c => Driver.Url.Contains("welcome"));

            //assert
            Driver.Url.ToString().Should().Be("https://www.facebook.com/?sk=welcome");
            //https://www.facebook.com/profile.php?id=100091383433240  //after further setup, account will probably start landing on this page instead.
        }

        [Fact]
        public void UnsuccessfulLoginTest()
        {
            //arrange
            Driver.Navigate().GoToUrl(_facebookLoginPage.Url);
            Driver.Manage().Window.Maximize();

            //act
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_facebookLoginPage.UsernameInput).Displayed);

            Driver.FindElement(_facebookLoginPage.UsernameInput).Clear();
            Driver.FindElement(_facebookLoginPage.UsernameInput).SendKeys(_facebookBadLogin);

            wait.Until(c => Driver.FindElement(_facebookLoginPage.PasswordInput).Displayed);

            Driver.FindElement(_facebookLoginPage.PasswordInput).Clear();
            Driver.FindElement(_facebookLoginPage.PasswordInput).SendKeys(_facebookBadLogin);

            Driver.FindElement(_facebookLoginPage.LoginButton).Click();

            wait.Until(c => Driver.FindElement(_facebookLoginPage.BadLoginMessage).Displayed);

            //assert
            Driver.Url.Should().Contain("www.facebook.com/login/?privacy_mutation_token");
        }

    }
}
