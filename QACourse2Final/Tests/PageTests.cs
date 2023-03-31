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
using Xunit;
using System.Reflection.Metadata;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using FluentAssertions.Equivalency.Tracing;

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
        MultipleWindowsPage _multipleWindowsPage;
        HoverActionsPage _hoverActionsPage;

        private const string _facebookUserLogin = "PantsMcpantsertonJr@outlook.com";
        private const string _facebookUserPassword = "Le@therPants1";
        private const string _facebookBadLogin = "B@dAccount!";

        public PageTests()
        {
            _facebookLoginPage = new FacebookLoginPage();
            _facebookUserMainPage = new FacebookUserMainPage();
            _datePickerPage = new DatePickerPage();
            _fileUploadPage = new FileUploadPage();
            _multipleWindowsPage = new MultipleWindowsPage();
            _hoverActionsPage= new HoverActionsPage();
        }

        [Fact]
        public async Task SuccessfulLoginTest()
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
        public async Task UnsuccessfulLoginTest()
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
        public async Task ConfirmFileUpload()
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
                //Driver.PageSource.Contains("File Uploaded!");
            }
        }

        [Fact]
        public async Task OpenNewWindowSuccessful()
        {
            //arrange
            string newPageTitle = "New Window";
            Driver.Navigate().GoToUrl(_multipleWindowsPage.Url);

            //act
            Driver.FindElement(_multipleWindowsPage.OpenNewPageLink).Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            //assert
            using (new AssertionScope())
            {
                Driver.Title.Should().Be(newPageTitle);
            }
        }

        [Fact]
        public async Task ConfirmHover1TextShowSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject1);
            Actions action = new Actions(Driver);
            action.MoveToElement(hoverable).Perform();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_hoverActionsPage.HoverText1).Displayed);

            //assert
            using (new AssertionScope())
            {
                Driver.FindElement(_hoverActionsPage.HoverText1).Text.Should().Be("name: user1");
            }
        }

        [Fact]
        public async Task ConfirmHover2TextShowSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject2);
            Actions action = new Actions(Driver);
            action.MoveToElement(hoverable).Perform();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_hoverActionsPage.HoverText2).Displayed);

            //assert
            using (new AssertionScope())
            {
                Driver.FindElement(_hoverActionsPage.HoverText2).Text.Should().Be("name: user2");
            }
        }

        [Fact]
        public async Task ConfirmHover3TextShowSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject3);
            Actions action = new Actions(Driver);
            action.MoveToElement(hoverable).Perform();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_hoverActionsPage.HoverText3).Displayed);

            //assert
            using (new AssertionScope())
            {
                Driver.FindElement(_hoverActionsPage.HoverText3).Text.Should().Be("name: user3");
            }
        }

        [Fact]
        public async Task ConfirmHover1MoveHideTextSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject1);
            Actions action = new Actions(Driver);
            action.MoveToElement(hoverable).Perform();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_hoverActionsPage.HoverText1).Displayed);

            IWebElement hoverable2 = Driver.FindElement(_hoverActionsPage.HoverObject2);
            action.MoveToElement(hoverable2).Perform();

            //assert
            using (new AssertionScope())
            {
                Driver.FindElement(_hoverActionsPage.HoverText1).Displayed.Should().BeFalse();
            }
        }

        //[Fact]
        //public async Task ConfirmDatePicker()
        //{
        //    //arrange
        //    Driver.Navigate().GoToUrl(_datePickerPage.Url);

        //    //act
        //    Driver.FindElement(_datePickerPage.DatePicker).Click();
        //    //Driver.FindElement(_datePickerPage.DatePicker).Text(15).

        //    //assert
        //    using (new AssertionScope())
        //    {
        //        Thread.Sleep(1000);
        //    }
        //}

    }
}
