using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;

namespace TestWork.Pages
{
    class GoogleTranslatePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'tlid-open-source-language-list')]")]
        private IWebElement dropdownMoreLanguagesSource;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'tlid-open-target-language-list')]")]
        private IWebElement dropdownMoreLanguagesTarget;

        [FindsBy(How = How.XPath, Using = "//div[@class='swap-wrap']")]
        private IWebElement buttonSwapLanguages;

        [FindsBy(How = How.Id, Using = "source")]
        private IWebElement inputSource;

        [FindsBy(How = How.XPath, Using = "//span[@class='tlid-translation translation']")]
        private IWebElement inputTranslation;

        public GoogleTranslatePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        /// <summary>
        /// get all text from input 'Translation'
        /// </summary>
        /// <returns> text </returns>
        private string getTextFromInputTranslation()
        {
            return string.Concat(inputTranslation.FindElements(By.XPath(".//*")).ToList().Select(e => e.Text));
        }

        /// <summary>
        /// send text to field 'Source'
        /// </summary>
        /// <param name="value"> some text </param>
        public void fillInputSource(string value)
        {
            inputSource.Clear();
            inputSource.SendKeys(value);
        }

        /// <summary>
        /// expand dropdown 'More Languages' for source field
        /// </summary>
        /// <returns> popup with languages </returns>
        public LanguagesSelectionPopup expandDropdownMoreLanguagesSource()
        {
            dropdownMoreLanguagesSource.Click();
            return new LanguagesSelectionPopup(driver);
        }

        /// <summary>
        /// expand dropdown 'More Languages' for target field
        /// </summary>
        /// <returns> popup with languages </returns>
        public LanguagesSelectionPopup expandDropdownMoreLanguagesTarget()
        {
            dropdownMoreLanguagesTarget.Click();
            return new LanguagesSelectionPopup(driver);
        }

        /// <summary>
        /// check that text in input 'Translation' equals to some expected text
        /// </summary>
        /// <param name="value"> expected text </param>
        /// <returns> true - equals </returns>
        public bool checkInputTranslationEquals(string value)
        {
            if (getTextFromInputTranslation().Replace(" ", "").ToLower().Replace("\n", "").Replace("\t", "").Equals(value.Replace(" ", "").ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// click button 'Swap Languages'
        /// </summary>
        public void clickButtonSwapLanguages()
        {
            buttonSwapLanguages.Click();
        }
    }
}
