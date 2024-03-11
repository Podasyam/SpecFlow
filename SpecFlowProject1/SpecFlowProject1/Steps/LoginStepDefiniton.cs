using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class LoginStepDefiniton : PageElements
    {               
        public LoginStepDefiniton(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [Given(@"launch URL")]
        public void GivenLaunchURL()
        {
            try
            {
                driver.Url = "";
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Url launched");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e + "TimeoutException");
            }
        }

        [Given(@"normal user addition screen")]
        public void GivenUserIsOnNormalUserAdditonScreeen()
        {
            try
            {
                bool anytextfield = SearchTextbox.Displayed;
                Assert.AreEqual(anytextfield, true);
                SearchTextbox.Click();
                Console.WriteLine("User is on normal user addition screen");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e + "TimeoutException");
            }
        }

        [Given(@"user is on admin user addition screen")]
        public void GivenUserIsOnAdminUserAdditionScreen()
        {
            try
            {
                System.Threading.Thread.Sleep(8000);
                bool anytextfield = SearchTextbox.Displayed;
                Assert.AreEqual(anytextfield, true);
                SearchTextbox.Click();
                Console.WriteLine("User is on admin user addition screen");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e + "TimeoutException");
            }
        }

        [When(@"navigate to external contact tab")]
        public void WhenEntersNormalUserDetails()
        {
            try
            {
                System.Threading.Thread.Sleep(8000);
                Actions actions = new Actions(driver);
                actions.MoveToElement(LogoImage).Perform();
                ExternalContactsTab.Click();
                //System.Threading.Thread.Sleep(8000);
                //LoginEmailTextbox.SendKeys(loginemail);
                //FirstNameTextbox.SendKeys(firstname);
                //LastNameTextbox.SendKeys(lastname);
                //StatusListBox.SendKeys(status);            
                Console.WriteLine("User enters normal user details");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");                 
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e + "TimeoutException");
            }

        }
        [When(@"access admin user tab")]
        public void WhenEntersAdminUserDetails()
        {
            try
            {
                System.Threading.Thread.Sleep(8000);               
                SearchTextbox.Click();
                //AdminTab.Click();
                //ExternalUsersTab.Click();
                //LoginEmailTextbox.SendKeys(loginemail);
                //FirstNameTextbox.SendKeys(firstname);
                //LastNameTextbox.SendKeys(lastname);
                //StatusListBox.SendKeys(status);
                Console.WriteLine("User enters admin user details");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e + "TimeoutException");
            }
        }
        [Then(@"enter name and password")]
        public void ThenEnterNameAndPassword()
        {
            try
            {
                UserNameTextbox.SendKeys("");
                PasswordTextbox.SendKeys("");
                LoginButton.Click();
                System.Threading.Thread.Sleep(8000);
                Console.WriteLine("User enters name and password");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e + "TimeoutException");
            }
        }
        [Then(@"added as external contact")]
        public void ThenUserShouldBeAddedAsNormalUser()
        {
            try
            {
                AddExtenalContactButton.Click();
                Console.WriteLine("User should be added as normal user");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e + "TimeoutException");
            }
        }
        [Then(@"user should be added as admin user")]
        public void ThenUserShouldBeAddedAsAdminUser()
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                SearchTextbox.Click();
                Console.WriteLine("User should be added as admin user");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e + "NoSuchElementException");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception" + e);
            }
        }

        }


    }
    
    

