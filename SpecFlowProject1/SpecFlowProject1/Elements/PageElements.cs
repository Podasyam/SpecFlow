using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class PageElements
    {

        public IWebDriver driver;

        public PageElements(IWebDriver driver)
        {
            this.driver = driver;

        }
        public IWebElement FindElement(string locator, int timeoutSeconds)// Wait the element is available in a certain interval of time
        {
                //FluentWait Declaration           
                DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(400);
                return fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(locator)));                
        }
        public IWebElement UserNameTextbox
        {
            get
            {
                string _Xpath = "//input[@name='username']";
                FindElement(_Xpath, 20);
                IWebElement _usernametxtbox = driver.FindElement(By.XPath("//input[@name='username']"));                
                return _usernametxtbox;
            }
        }
        public IWebElement PasswordTextbox
        {
            get
            {
                string _Xpath = "//input[@name='password']";
                FindElement(_Xpath, 3);
                IWebElement _passwordtxtbox = driver.FindElement(By.XPath("//input[@name='password']"));                
                return _passwordtxtbox;
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                string _Xpath = "//button[@title='Login']";
                FindElement(_Xpath, 3);
                IWebElement _loginbutton = driver.FindElement(By.XPath("//button[@title='Login']"));               
                return _loginbutton;
            }
        }
        public IWebElement SearchTextbox
        {
            get
            {
                string _Xpath = "//input[@placeholder='Search']";
                FindElement(_Xpath, 3);
                IWebElement _searchtxtbox = driver.FindElement(By.XPath("//input[@placeholder='Search']"));               
                return _searchtxtbox;
            }
        }

        public IWebElement LogoImage
        {
            get
            {
                string _Xpath = "//img[@alt='logo']";
                FindElement(_Xpath, 3);
                IWebElement _admintab = driver.FindElement(By.XPath("//img[@alt='logo']"));
                return _admintab;
            }
        }
        public IWebElement AdminTab
        {
            get
            {
                string _Xpath = "/html/body/viracor-app/landingpage-cmp/div/imssidebar-cmp/div/p-scrollpanel/div/div[1]/div/ul/li[2]/a/span";
                FindElement(_Xpath, 3);
                IWebElement _admintab = driver.FindElement(By.XPath("/html/body/viracor-app/landingpage-cmp/div/imssidebar-cmp/div/p-scrollpanel/div/div[1]/div/ul/li[2]/a/span"));
                return _admintab;
            }
        }
        public IWebElement ExternalUsersTab
        {
            get
            {
                string _Xpath = "//span[@class='menuitem-text'][normalize-space()='External Users']";
                FindElement(_Xpath, 3);
                IWebElement _externaluserstab = driver.FindElement(By.XPath("//span[@class='menuitem-text'][normalize-space()='External Users']"));
                return _externaluserstab;
            }
        }
        public IWebElement ExternalContactsTab
        {
            get
            {
                string _Xpath = "//a[@href='#/home/clinicalteam']";
                FindElement(_Xpath, 3);
                IWebElement _externalContactstab = driver.FindElement(By.XPath("//a[@href='#/home/clinicalteam']"));
                return _externalContactstab;
            }
        }

        public IWebElement FirstNameFilterBox
        {
            get
            {
                string _Xpath = "//*[@id='VRC_ExternalUser_filterLastName_2']";
                FindElement(_Xpath, 3);
                IWebElement _firstNameFilterBox = driver.FindElement(By.Id("VRC_ExternalUser_filterLastName_2"));
                return _firstNameFilterBox;
            }
        }
        public IWebElement LoginEmailTextbox
        {
            get
            {
                IWebElement _loginemailtextbox = driver.FindElement(By.XPath("//input[@name='loginEmail']"));
                return _loginemailtextbox;
            }
        }
        public IWebElement FirstNameTextbox
        {
            get
            {
                IWebElement _firstnametextbox = driver.FindElement(By.XPath("//input[@name='firstName']"));
                return _firstnametextbox;
            }
        }
        public IWebElement LastNameTextbox
        {
            get
            {
                IWebElement _lastnametextbox = driver.FindElement(By.XPath("//input[@name='lastName']"));
                return _lastnametextbox;
            }
        }
        public IWebElement StatusListBox
        {
            get
            {
                IWebElement _statuslistbox = driver.FindElement(By.XPath("//select[@id='statusId']"));
                return _statuslistbox;
            }
        }
        public IWebElement AddExtenalContactButton
        {
            get
            {
                IWebElement _addexternalcontactbutton = driver.FindElement(By.XPath("//button[@title='Add Contact']"));
                return _addexternalcontactbutton;
            }
        }
       



    }
}
    

