using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class DictionaryMainPage
    {
        public string Url = "https://www.dictionary.com/";

        string searchInputId = @"global-search";
        public By SearchInput => By.Id(searchInputId);

        string wordOfTheDayButtonId = @"pagesmenu-tab-word-of-the-day";
        public By WordOfTheDayButton => By.Id(wordOfTheDayButtonId);

        string wordOfTheDayLink = "Word of the Day";
        public By WordOfTheDay => By.LinkText(wordOfTheDayLink);

    }
}
