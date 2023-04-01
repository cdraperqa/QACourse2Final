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

        string hoverObject1XPath = "//*[@id=\'content\']/div/div[1]/img";
        public By HoverObject1 => By.XPath(hoverObject1XPath);

        string hoverText1XPath = "//*[@id=\"content\"]/div/div[1]/div/h5";
        public By HoverText1 => By.XPath(hoverText1XPath);

        string hoverObject2XPath = "//*[@id=\'content\']/div/div[2]/img";
        public By HoverObject2 => By.XPath(hoverObject2XPath);

        string hoverText2XPath = "//*[@id=\'content\']/div/div[2]/div/h5";
        public By HoverText2 => By.XPath(hoverText2XPath);

        string hoverObject3XPath = "//*[@id=\'content\']/div/div[3]/img";
        public By HoverObject3 => By.XPath(hoverObject3XPath);

        string hoverText3XPath = "//*[@id=\'content\']/div/div[3]/div/h5";
        public By HoverText3 => By.XPath(hoverText3XPath);
    }
}
