using OpenQA.Selenium;

namespace QACourse2Final.PageObjectModels
{
    public class DemoQAFormPage
    {
        public string Url = "https://demoqa.com/automation-practice-form";

        string dateOfBirthInputId = "dateOfBirthInput";
        public By DateOfBirthInput => By.Id(dateOfBirthInputId);

        string calendarPreviousMonthCss = "[class='react-datepicker__navigation react-datepicker__navigation--previous']";
        public By CalendarPreviousMonth => By.CssSelector(calendarPreviousMonthCss);

        string calendarNextMonthCss = "[class='react-datepicker__navigation react-datepicker__navigation--next']";
        public By CalendarNextMonth => By.CssSelector(calendarNextMonthCss);

        string calendarMonthDropDownCss = "[class='react-datepicker__month-select']";
        public By CalendarMonthDropDown => By.CssSelector(calendarMonthDropDownCss);

        string calendarYearDropDownCss = "[class='react-datepicker__year-select']";
        public By CalendarYearDropDown => By.CssSelector(calendarYearDropDownCss);

        string calendarMonthYearSelectCss = "[class='react-datepicker__current-month react-datepicker__current-month--hasYearDropdown react-datepicker__current-month--hasMonthDropdown']";
        public By CalendarMonthYearSelect => By.CssSelector(calendarMonthYearSelectCss);

        string calendarSelectDayCss = "[class*='react-datepicker__day react-datepicker__day--<DAY>']";
        public By CalendarSelectDay(string SelectedDay) => By.CssSelector(calendarSelectDayCss.Replace("<DAY>", SelectedDay));

        string firstNameInputId = "firstName";
        public By FirstNameInput => By.Id(firstNameInputId);

        string lastNameInputId = "lastName";
        public By LastNameInput => By.Id(lastNameInputId);

        string userEmailInputId = "userEmail";
        public By UserEmailInputId => By.Id(userEmailInputId);

        string genderMaleRadioId = "gender-radio-1";
        public By GenderMalelRadioId => By.Id(genderMaleRadioId);

        string genderFemaleRadioId = "gender-radio-2";
        public By GenderFemalelRadioId => By.Id(genderFemaleRadioId);

        string genderOtherRadioId = "gender-radio-3";
        public By GenderOtherRadio => By.Id(genderOtherRadioId);

        string mobileNumberId = "userNumber";
        public By MobileNumber => By.Id(mobileNumberId);

        string subjectsContainerId = "subjectsContainer";
        public By SubjectsContainer => By.Id(subjectsContainerId);

        string hobbiesSportsCheckboxId = "hobbies-checkbox-1";
        public By HobbiesSportsCheckbox => By.Id(hobbiesSportsCheckboxId);

        string hobbiesReadingCheckboxId = "hobbies-checkbox-2";
        public By HobbiesReadingCheckbox => By.Id(hobbiesReadingCheckboxId);

        string hobbiesMusicCheckboxId = "hobbies-checkbox-3";
        public By HobbiesMusicCheckbox => By.Id(hobbiesMusicCheckboxId);

    }
}
