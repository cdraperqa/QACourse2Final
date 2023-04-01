using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QACourse2Final.PageObjectModels
{
    public class DemoQAFormPage
    {
        public string Url = "https://demoqa.com/automation-practice-form";

        string datePickerId = "datepicker";
        public By DatePicker => By.Id(datePickerId);

        string calendarMonthClass = "datepicker-switch";
        public By CalendarMonth => By.ClassName(calendarMonthClass);

        string calendarDayClass = "day";
        public By CalendarDay => By.ClassName(calendarDayClass);
            
        string selectDatePartialLink = "15";
        public By SelectDate => By.LinkText(selectDatePartialLink);
        
    }
}
