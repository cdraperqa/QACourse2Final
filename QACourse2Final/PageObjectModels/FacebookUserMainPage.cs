using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class FacebookUserMainPage
    {
        public string Url = "https://www.facebook.com/profile.php?id=100091383433240";

        string bornOnSectionXPath = "//*[contains(text()='Born on August 31, 2000']";
        public By BornOnSection => By.XPath(bornOnSectionXPath);

    }
}
