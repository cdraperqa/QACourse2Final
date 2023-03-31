using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class DatePickerPage
    {
        public string Url = "http://webdriveruniversity.com/Datepicker/index.html";

        public string DatePickerId = "datepicker";
        public By DatePicker => By.Id(DatePickerId);

        //public string calendarObjectXPath = "//td[contains(text(), '<DAY>')]";
        //public string CalendarObjectXPath(long day) => calendarObjectXPath.Replace("<DAY>", day.ToString());
        //// public By CalendarObject => By.Id(calendarObjectXPath.Replace("<DAY>", day.ToString()));

    }
}
