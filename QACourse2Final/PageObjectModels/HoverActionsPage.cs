using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class HoverActionsPage
    {
        public string Url = "https://the-internet.herokuapp.com/hovers";

        public string HoverObject1XPath = "//*[@id=\'content\']/div/div[1]/img";
        public By HoverObject1 => By.XPath(HoverObject1XPath);

        public string HoverText1XPath = "//*[@id=\"content\"]/div/div[1]/div/h5";
        public By HoverText1 => By.XPath(HoverText1XPath);

        public string HoverObject2XPath = "//*[@id=\'content\']/div/div[2]/img";
        public By HoverObject2 => By.XPath(HoverObject2XPath);

        public string HoverText2XPath = "//*[@id=\'content\']/div/div[2]/div/h5";
        public By HoverText2 => By.XPath(HoverText2XPath);

        public string HoverObject3XPath = "//*[@id=\'content\']/div/div[3]/img";
        public By HoverObject3 => By.XPath(HoverObject3XPath);

        public string HoverText3XPath = "//*[@id=\'content\']/div/div[3]/div/h5";
        public By HoverText3 => By.XPath(HoverText3XPath);
    }
}
