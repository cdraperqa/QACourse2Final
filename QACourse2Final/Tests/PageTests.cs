using QACourse2Final.Tests;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QACourse2Final.PageObjectModels;

namespace QACourse2Final.Tests
{
    public sealed class PageTests : BaseTest
    {
        IWebDriver _driver;
        DatePickerPage _datePickerPage;
        FileUploadPage _fileUploadPage;

        public PageTests()
        {
            _datePickerPage = new DatePickerPage();
            _fileUploadPage = new FileUploadPage();
        }

        [Fact]
        public void ConfirmFileUpload()
        {
            //arrange
            Driver.Navigate().GoToUrl(_fileUploadPage.Url);

            Thread.Sleep(3000);
            //act
            string uploadFile = Path.GetFullPath("pants1.jpg");
                //@"C:\Users\abbar\source\repos\QACourse2Final\QACourse2Final\DataFile\pants1.jpg";

            Driver.FindElement(By.Id("file-upload")).SendKeys(uploadFile);
            Driver.FindElement(By.Id("file-submit")).Submit();

            //Wait for Upload Window to appear(may not be necessary in some cases)
            Thread.Sleep(2000);

            //SendKeys.SendWait(@"{Enter}");

            //WebElement addFile = Driver.FindElement(_fileUploadPage.ChooseFile);
            //addFile.Click();
            //addFile.SendKeys("pants1.jpg");

            //Driver.FindElement(_fileUploadPage.ChooseFile).SendKeys("pants1.jpg");
            //Driver.FindElement(_fileUploadPage.ChooseFile).SendKeys(Keys.Enter);

            //IWebElement addFile = Driver.FindElement(_fileUploadPage.ChooseFile).Click();
            // Mention the own path of the file location

            // Add file method 
            //addFile.SendKeys("pants1.jpg");// For setting a profile picture

            //assert
            //string dateSelected = Driver.FindElement(By.XPath(calendarObjectXPath1)).Text;
            //dateSelected.Should().Be("3/15/2023");
            Thread.Sleep(1000);
        }

    }
}
