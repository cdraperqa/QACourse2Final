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

        public string OpenNewPageLinkText = "Click Here";
        public By OpenNewPageLink => By.LinkText(OpenNewPageLinkText);

        //public By SelectDay => By.("    -webkit-text-size-adjust: 100%;\r\n    -webkit-tap-highlight-color: rgba(0,0,0,0);\r\n    direction: ltr;\r\n    list-style: none;\r\n    font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif;\r\n    font-size: 13px;\r\n    line-height: 20px;\r\n    border-spacing: 0;\r\n    border-collapse: collapse;\r\n    user-select: none;\r\n    box-sizing: border-box;\r\n    text-align: center;\r\n    width: 20px;\r\n    height: 20px;\r\n    border-radius: 4px;\r\n    border: none;\r\n    padding: 4px 5px;\r\n    background-image: -webkit-linear-gradient(top, #0088cc, #0044cc);\r\n    background-repeat: repeat-x;\r\n    border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);\r\n    color: #fff;\r\n    text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);\r\n    background-color: #0044cc;")

        //public string calendarObjectXPath = "td.day[],'<DAY>')]";
        //public string CalendarObjectXPath(long day) => calendarObjectXPath.Replace("<DAY>", day.ToString());
        //// public By CalendarObject => By.Id(calendarObjectXPath.Replace("<DAY>", day.ToString()));Open

    }
}
