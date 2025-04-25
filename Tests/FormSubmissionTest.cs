using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using POMFramework.Pages;
using System.IO;
using OfficeOpenXml;
using POMFramework;

namespace POMFramework.Tests
{
    [TestFixture]
    public class FormSubmissionTest
    {
        private IWebDriver _driver;
        private PracticeFormPage _practiceFormPage;

        [SetUp]
        public void SetUp()
        {
            ReportManager.InitializeReport();
            _driver = new ChromeDriver();
            _practiceFormPage = new PracticeFormPage(_driver);
        }

        [Test]
        public void TestFormSubmission()
        {
            try
            {
                // Navigate to the form
                _practiceFormPage.NavigateTo("https://demoqa.com/automation-practice-form");

                // Add a wait mechanism to ensure the form is fully loaded before interacting with it
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => _practiceFormPage.IsFormLoaded());

                // Fill all form fields
                _practiceFormPage.EnterFirstName("John");
                _practiceFormPage.EnterLastName("Doe");
                _practiceFormPage.EnterEmail("johndoe@example.com");
                _practiceFormPage.SelectGender("Male");
                _practiceFormPage.EnterMobileNumber("1234567890");
                _practiceFormPage.EnterDateOfBirth("01 Jan 1990");
                _practiceFormPage.EnterSubjects("Maths");
                //_practiceFormPage.SelectHobbies("Reading");
                _practiceFormPage.EnterAddress("123 Main St, Anytown, USA");
                _practiceFormPage.SelectState("NCR");
                _practiceFormPage.SelectCity("Delhi");
                _practiceFormPage.SubmitForm();

                // Save input to Excel
                string filePath = "FormSubmissionData.xlsx";
                FileInfo fileInfo = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Count == 0
                        ? package.Workbook.Worksheets.Add("Form Data")
                        : package.Workbook.Worksheets[0];

                    int row = worksheet.Dimension?.Rows + 1 ?? 1;
                    worksheet.Cells[row, 1].Value = "John";
                    worksheet.Cells[row, 2].Value = "Doe";
                    worksheet.Cells[row, 3].Value = "johndoe@example.com";
                    worksheet.Cells[row, 4].Value = "Male";
                    worksheet.Cells[row, 5].Value = "1234567890";
                    worksheet.Cells[row, 6].Value = "01 Jan 1990";
                    worksheet.Cells[row, 7].Value = "Maths";
                    worksheet.Cells[row, 8].Value = "Reading";
                    worksheet.Cells[row, 9].Value = "123 Main St, Anytown, USA";
                    worksheet.Cells[row, 10].Value = "NCR";
                    worksheet.Cells[row, 11].Value = "Delhi";

                    package.Save();
                }

                // Verify successful submission
                Assert.IsTrue(_practiceFormPage.IsSubmissionSuccessful(), "Form submission was not successful.");
                ReportManager.LogTestResult("TestFormSubmission", "Pass");
            }
            catch (Exception ex)
            {
                ReportManager.LogTestResult("TestFormSubmission", "Fail", ex.Message);
                throw;
            }
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}