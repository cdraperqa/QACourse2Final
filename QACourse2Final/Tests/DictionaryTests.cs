using OpenQA.Selenium;
using QACourse2Final.PageObjectModels;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions.Execution;

namespace QACourse2Final.Tests
{
    public sealed class DictionaryTests : BaseTest
    {
        DictionaryMainPage _dictionaryMainPage;
        DictionaryDefinitionPage _dictionaryDefinitionPage;

        private const string _searchedWord = "pants";

        public DictionaryTests()
        {
            _dictionaryMainPage = new DictionaryMainPage();
            _dictionaryDefinitionPage = new DictionaryDefinitionPage();
        }

        [Fact]
        public void ConfirmMainPageLoads()
        {
            //arrange
            Driver.Navigate().GoToUrl(_dictionaryMainPage.Url);

            //act

            //assert
            Driver.Title.Should().Be("Dictionary.com | Meanings & Definitions of English Words");
        }

        [Fact]
        public void ConfirmWordSearchResults()
        {
            //arrange
            Driver.Navigate().GoToUrl(_dictionaryMainPage.Url);

            //act
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_dictionaryMainPage.SearchInput).Displayed);

            Driver.FindElement(_dictionaryMainPage.SearchInput).SendKeys(_searchedWord + Keys.Enter);

            wait.Until(c => Driver.FindElement(_dictionaryDefinitionPage.DefinedWord).Displayed);

            //assert
            using (new AssertionScope())
            {
                Driver.Url.Should().Be(_dictionaryDefinitionPage.Url(_searchedWord));
            }
        }

        [Fact]
        public void ConfirmAudioPronunciationExists()
        {
            //arrange
            Driver.Navigate().GoToUrl(_dictionaryDefinitionPage.Url(_searchedWord));

            //act
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(20));
            wait.Until(c => Driver.FindElement(_dictionaryDefinitionPage.AudioPronunciation).Displayed);

            //assert
            using (new AssertionScope())
            {
                Driver.FindElement(_dictionaryDefinitionPage.DefinedWord).Text.Should().Be(_searchedWord);
                Driver.FindElement(_dictionaryDefinitionPage.AudioPronunciation).Displayed.Should().BeTrue();
            }
        }

        [Fact]
        public void ConfirmWordOfTheDay()
        {
            //arrange
            Driver.Navigate().GoToUrl(_dictionaryMainPage.Url);

            //act
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(20));
            wait.Until(c => Driver.FindElement(_dictionaryMainPage.WordOfTheDayButton).Displayed);

            Driver.FindElement(_dictionaryMainPage.WordOfTheDayButton).Click();

            wait.Until(c => Driver.FindElement(_dictionaryMainPage.WordOfTheDay).Displayed);

            //assert
            Driver.FindElement(_dictionaryMainPage.WordOfTheDay).Displayed.Should().BeTrue();
        }


    }
}
