using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class FacebookLoginPage
    {
        public string Url = "https://www.facebook.com/";

        public string UsernameInputId = "email";
        public By UsernameInput => By.Id(UsernameInputId);

        public string PasswordInputId = "pass";
        public By PasswordInput => By.Id(PasswordInputId);

        public string LoginButtonXPath = "/html/body/div[1]/div[1]/div[1]/div/div/div/div[2]/div/div[1]/form/div[2]/button";  //can't use id because it changes each page load
        public By LoginButton => By.XPath(LoginButtonXPath);

        public string BadLoginMessageXPath = "//*[@id=\'email_container\']/div[2]";
        public By BadLoginMessage => By.XPath(BadLoginMessageXPath);

    }
}
