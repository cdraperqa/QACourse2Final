using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QACourse2Final.PageObjectModels;

namespace QACourse2Final.Tests
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver Driver;

        public BaseTest()
        {
            IWebDriver driver = new ChromeDriver();
            Driver = driver;
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
