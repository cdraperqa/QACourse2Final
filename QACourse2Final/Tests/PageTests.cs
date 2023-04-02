using OpenQA.Selenium;
using QACourse2Final.PageObjectModels;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions.Execution;
using OpenQA.Selenium.Interactions;

namespace QACourse2Final.Tests
{
    public sealed class PageTests : BaseTest
    {
        FileUploadPage _fileUploadPage;
        MultipleWindowsPage _multipleWindowsPage;
        HoverActionsPage _hoverActionsPage;

        public PageTests()
        {
            _fileUploadPage = new FileUploadPage();
            _multipleWindowsPage = new MultipleWindowsPage();
            _hoverActionsPage= new HoverActionsPage();
        }

        #region File Upload Tests
        
        [Fact]
        public void FileUploadSuccessful()
        {
            //arrange
            Random r = new ();
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

        #endregion File Upload Tests

        #region Multiple Windows Tests
        [Fact]
        public void OpenNewWindowSuccessful()
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

        #endregion Multiple Windows Tests

        #region Hover Tests

        [Fact]
        public void ConfirmHover1TextShowSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject1);
            Actions action = new(Driver);
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
        public void ConfirmHover2TextShowSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject2);
            Actions action = new(Driver);
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
        public void ConfirmHover3TextShowSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject3);
            Actions action = new(Driver);
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
        public void ConfirmHover1MoveHideTextSuccessful()
        {
            //arrange
            Driver.Navigate().GoToUrl(_hoverActionsPage.Url);

            //act
            IWebElement hoverable = Driver.FindElement(_hoverActionsPage.HoverObject1);
            Actions action = new(Driver);
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

        #endregion Hover Tests

    }
}
