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
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace QACourse2Final.PageObjectModels
{
    public class DatePickerPage
    {
        public string Url = "http://webdriveruniversity.com/Datepicker/index.html";

        public string DatePickerId = "datepicker";
        public By DatePicker => By.Id(DatePickerId);

    }
}
