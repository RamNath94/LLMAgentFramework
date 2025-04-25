using OpenQA.Selenium;

namespace POMFramework.Pages
{
    public class PracticeFormPage : BasePage
    {
        private readonly IWebDriver _driver;
        private IWebElement FirstNameField => Driver.FindElement(By.Id("firstName"));
        private IWebElement LastNameField => Driver.FindElement(By.Id("lastName"));
        private IWebElement EmailField => Driver.FindElement(By.Id("userEmail"));
        private IWebElement GenderMaleRadio => Driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
        private IWebElement MobileNumberField => Driver.FindElement(By.Id("userNumber"));
        private IWebElement SubmitButton => Driver.FindElement(By.Id("submit"));
        private IWebElement SuccessMessage => Driver.FindElement(By.CssSelector(".modal-content"));
        private IWebElement DateOfBirthField => Driver.FindElement(By.Id("dateOfBirthInput"));

        public PracticeFormPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void EnterFirstName(string firstName)
        {
            FirstNameField.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LastNameField.SendKeys(lastName);
        }

        public void EnterEmail(string email)
        {
            EmailField.SendKeys(email);
        }

        public void SelectGender(string gender)
        {
            if (gender == "Male")
            {
                GenderMaleRadio.Click();
            }
            // Add more conditions for other genders if needed
        }

        public void EnterMobileNumber(string mobileNumber)
        {
            MobileNumberField.SendKeys(mobileNumber);
        }

        public void EnterDateOfBirth(string dateOfBirth)
        {
            DateOfBirthField.Clear();
            DateOfBirthField.SendKeys(dateOfBirth);
            DateOfBirthField.SendKeys(Keys.Enter);
        }

        public void SelectHobbies(string hobby)
        {
            var hobbyCheckbox = _driver.FindElement(By.XPath($"//label[text()='{hobby}']/preceding-sibling::input[@type='checkbox']"));
            ScrollToElement(hobbyCheckbox); // Scroll to the checkbox
            HideAds(); // Hide any obstructing ads
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", hobbyCheckbox); // Ensure it's centered
            if (!hobbyCheckbox.Selected)
            {
                try
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", hobbyCheckbox); // Use JavaScript click to avoid interception
                }
                catch (ElementClickInterceptedException)
                {
                    // Retry clicking after a short delay
                    System.Threading.Thread.Sleep(500);
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", hobbyCheckbox);
                }
            }
        }

        public void EnterSubjects(string subject)
        {
            var subjectsInput = _driver.FindElement(By.Id("subjectsInput"));
            subjectsInput.SendKeys(subject);
            subjectsInput.SendKeys(Keys.Enter);
        }

        public void EnterAddress(string address)
        {
            var addressField = _driver.FindElement(By.Id("currentAddress"));
            addressField.Clear();
            addressField.SendKeys(address);
        }

        public void SelectState(string state)
        {
            var stateDropdown = _driver.FindElement(By.Id("state"));
            ScrollToElement(stateDropdown); // Scroll to the state dropdown
            stateDropdown.Click();
            var stateOption = _driver.FindElement(By.XPath($"//div[contains(text(), '{state}')]"));
            ScrollToElement(stateOption); // Scroll to the state option
            stateOption.Click();
        }

        public void SelectCity(string city)
        {
            var cityDropdown = _driver.FindElement(By.Id("city"));
            cityDropdown.Click();
            var cityOption = _driver.FindElement(By.XPath($"//div[contains(text(), '{city}')]"));
            cityOption.Click();
        }

        public void HideAds()
        {
            try
            {
                var iframes = Driver.FindElements(By.CssSelector("iframe[id^='google_ads_iframe']"));
                foreach (var iframe in iframes)
                {
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].style.display='none';", iframe);
                }
            }
            catch (NoSuchElementException)
            {
                // If no iframe is found, proceed without any action
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HideAds failed: {ex.Message}");
            }
        }

        public void ScrollToElement(IWebElement element)
        {
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ScrollToElement failed: {ex.Message}");
            }
        }

        public void SubmitForm()
        {
            HideAds(); // Hide ads before clicking submit
            ScrollToElement(SubmitButton); // Scroll to the Submit button
            SubmitButton.Click();
        }

        public bool IsSubmissionSuccessful()
        {
            return SuccessMessage.Displayed;
        }

        public bool IsFormLoaded()
        {
            try
            {
                // Replace with a unique element on the form to verify it is loaded
                return _driver.FindElement(By.Id("firstName")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}