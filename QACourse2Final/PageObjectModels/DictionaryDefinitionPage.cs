using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class DictionaryDefinitionPage
    {
        string url = "https://www.dictionary.com/browse/<word>";
        public string Url(string word) => url.Replace("<word>", word);

        string definedWordCss = "#top-definitions-section > div.css-1gvu524.e1wg9v5m7 > div.css-jv03sw.e1wg9v5m6 > h1";
        public By DefinedWord => By.CssSelector(definedWordCss);

        string audioPronunciationClass = @"css-5e54wk";
        
        public By AudioPronunciation => By.ClassName(audioPronunciationClass);  
    }
}
