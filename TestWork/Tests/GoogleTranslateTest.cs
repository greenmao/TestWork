using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using TestWork.Pages;

namespace TestWork.Tests
{
    class GoogleTranslateTest : BaseTest
    {
        GoogleTranslatePage googleTranslatePage;

        [SetUp]
        public void beforeTest()
        {
            webDriverManager.getWebDriver.Navigate().GoToUrl("https://translate.google.com/");
            googleTranslatePage = new GoogleTranslatePage(webDriverManager.getWebDriver);
        }

        [Test]
        public void English_To_Ukrainian()
        {
            string engText = "Some text";
            string ukrText = "Якийсь текст";

            googleTranslatePage = new GoogleTranslatePage(webDriverManager.getWebDriver);
            googleTranslatePage.expandDropdownMoreLanguagesSource().selectEnglishLanguage();
            googleTranslatePage.expandDropdownMoreLanguagesTarget().selectUkrainianLanguage();
            googleTranslatePage.fillInputSource(engText);
            Assert.AreEqual(true, googleTranslatePage.checkInputTranslationEquals(ukrText), "Text in field 'Translation' is not equal the expected!");
        }

        [Test]
        public void Ukrainian_To_English()
        {
            string ukrText = "Якийсь текст 1*~!+_)(&#$^%@";
            string engText = "Some text 1*~!+_)(&#$^%@";

            googleTranslatePage = new GoogleTranslatePage(webDriverManager.getWebDriver);
            googleTranslatePage.expandDropdownMoreLanguagesSource().selectUkrainianLanguage();
            googleTranslatePage.expandDropdownMoreLanguagesTarget().selectEnglishLanguage();
            googleTranslatePage.fillInputSource(ukrText);
            Assert.AreEqual(true, googleTranslatePage.checkInputTranslationEquals(engText), "Text in field 'Translation' is not equal the expected!");
        }

        [Test]
        public void Check_Button_Swap()
        {
            string ukrText = "Якийсь текст";

            googleTranslatePage.expandDropdownMoreLanguagesSource().selectUkrainianLanguage();
            googleTranslatePage.expandDropdownMoreLanguagesTarget().selectEnglishLanguage();
            googleTranslatePage.fillInputSource(ukrText);
            googleTranslatePage.clickButtonSwapLanguages();
            Assert.AreEqual(true, googleTranslatePage.checkInputTranslationEquals(ukrText), "Text in field 'Translation' is not equal the expected!");
        }
    }
}
