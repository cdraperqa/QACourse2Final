using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QACourse2Final.PageObjectModels
{
    public class FileUploadPage
    {
        public string Url = "https://the-internet.herokuapp.com/upload";

        public string ChooseFileId = "file-upload";
        public By ChooseFile => By.Id(ChooseFileId);


    }
}
