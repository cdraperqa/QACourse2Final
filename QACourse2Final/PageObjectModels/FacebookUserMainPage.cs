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

        public string PhotoUploadButtonXPath = "//*[@id=\'mount_0_0_A+\']/div/div[1]/div/div[3]/div/div/div/div[1]/div[1]/div/div/div[4]/div[2]/div/div[1]/div[2]/div/div[2]/div/div/div/div/div[1]/div/div/div/div/span/div/div[1]/h2/span/span/a";
        public By PhotoUploadButton => By.XPath(PhotoUploadButtonXPath);
    }
}
