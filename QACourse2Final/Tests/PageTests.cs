using QACourse2Final.Tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QACourse2Final.PageObjectModels;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using FluentAssertions.Execution;

namespace QACourse2Final.Tests
{
    //Well, this final project been a crash and burn of epic proportions. I got stuck attempting to use sites which didn't work out and wasted all my time
    //hitting a wall, assuming I was doing it incorrectly and not that the sites were poor choices. (Social media sites seemed like a good exmaple for file uploads
    //but have randomly changing XPaths. I restarted this thing at least 7 times. I'm going to keep going until I finish because I want the satisfaction of
    ///completing it, along with the knowledge gained, but I'm sure it won't be be finished before this is graded. 
    ///It's been a great session anyway, and I am extremely grateful it was offered and that I participated. Thanks for all the great classes!

    public sealed class PageTests : BaseTest
    {
        IWebDriver _driver;
        DatePickerPage _datePickerPage;
        FileUploadPage _fileUploadPage;
        FacebookLoginPage _facebookLoginPage;
        FacebookUserMainPage _facebookUserMainPage;

        private const string _facebookUserLogin = "PantsMcpantsertonJr@outlook.com";
        private const string _facebookUserPassword = "Le@therPants1";
        private const string _facebookBadLogin = "B@dAccount!";

        public PageTests()
        {
            _facebookLoginPage = new FacebookLoginPage();
            _facebookUserMainPage = new FacebookUserMainPage();
            _datePickerPage = new DatePickerPage();
            _fileUploadPage = new FileUploadPage();
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

        [Fact]
        public void ConfirmFileUpload()
        {
            //arrange
            Random r = new Random();
            int rInt = r.Next(1, 5);
            Driver.Navigate().GoToUrl(_fileUploadPage.Url);

            //act
            string uploadFile = Path.GetFullPath(Path.Combine(@"DataFile/", $"pants{rInt}.jpg"));
            Driver.FindElement(_fileUploadPage.ChooseFile).SendKeys(uploadFile.ToString());  
            Driver.FindElement(_fileUploadPage.SubmitFile).Submit();

            //assert
            using (new AssertionScope())
            {
                Driver.FindElement(_fileUploadPage.UploadedFiles).Text.Should().Be($"pants{rInt}.jpg");
                Driver.PageSource.Contains("File Uploaded!");
            }
        }

    }
}
