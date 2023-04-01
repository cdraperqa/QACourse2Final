using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class MultipleWindowsPage
    {
        public string Url = "https://the-internet.herokuapp.com/windows";

        string openNewPageLinkText = "Click Here";
        public By OpenNewPageLink => By.LinkText(openNewPageLinkText);
 }
}
