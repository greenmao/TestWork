using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace TestWork.Pages
{
    class LanguagesSelectionPopup
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='language-list'][not(@style='display: none;')]//div[contains(@class, 'list_en_checkmark')]/..")]
        private IWebElement labelEnglishLanguage;

        [FindsBy(How = How.XPath, Using = "//div[@class='language-list'][not(@style='display: none;')]//div[contains(@class, 'list_uk_checkmark')]/..")]
        private IWebElement labelUkrainianLanguage;

        public LanguagesSelectionPopup(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        /// <summary>
        /// click with JavaScriptExecutor
        /// </summary>
        public void selectEnglishLanguage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", labelEnglishLanguage);
        }

        /// <summary>
        /// click with JavaScriptExecutor
        /// </summary>
        public void selectUkrainianLanguage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", labelUkrainianLanguage);
        }
    }
}
