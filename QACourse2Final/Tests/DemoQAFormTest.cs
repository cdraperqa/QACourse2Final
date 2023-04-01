using OpenQA.Selenium;
using QACourse2Final.PageObjectModels;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions.Execution;
using OpenQA.Selenium.Interactions;

namespace QACourse2Final.Tests
{
    //  Well, this final project been a crash and burn of epic proportions. I got stuck while using poorly picked sites and wasted all my time
    //  hitting a wall, assuming I was doing it incorrectly and not that the sites were poor choices. (Social media sites seemed like a good exmaple for file uploads
    //  but have few Ids and randomly changing XPaths.) I restarted this project at least 7 times. I've missed the deadline but will keep going until I finish
    //  for the satisfaction of completing it, along with the knowledge gained. I know it won't be finished before this is graded, but it's been a great session anyway. 
    //  I'm grateful this session was offered and that I participated. Thanks for all the great classes!

    public sealed class DemoQAFormTest : BaseTest
    {
        DemoQAFormPage _demoQAFormPage;

        public DemoQAFormTest()
        {
            _demoQAFormPage = new DemoQAFormPage();
        }

        #region File Upload Tests

        [Fact]
        public void FirstTest()
        {
            //arrange

            //act

            //assert
            using (new AssertionScope())
            {
            }
        }

        #endregion File Upload Tests

    }
}
