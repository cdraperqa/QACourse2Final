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

        string chooseFileId = @"file-upload";
        public By ChooseFile => By.Id(chooseFileId);

        string submitFileId = @"file-submit";
        public By SubmitFile => By.Id(submitFileId);

        string uploadedFilesId = @"uploaded-files";
        public By UploadedFiles => By.Id(uploadedFilesId);
    }
}
