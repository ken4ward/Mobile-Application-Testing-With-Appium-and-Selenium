using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using ZoneAppTesting.Functional.Constants.Auth;
using ZoneAppTesting.Functional.Utils.Auth;

namespace ZoneAppTesting
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        private static String AppiumServerURL;

        public UnitTest1()
        {
            AppiumServerURL = GetConfigurationProperty("AppiumServerURL", AuthConstant.AppiumServerURL);
            AuthUtils.WaitTime();
        }
        private static String GetConfigurationProperty(String environmentKey, String defaultValue)
        {
            String returnValue = defaultValue;
            String environmentValue = System.Environment.GetEnvironmentVariable(environmentKey);

            if (environmentValue != null)
            {
                returnValue = environmentValue;
            }
            return returnValue;
        }


        [TestMethod]
        public void HTCDesire626sDeviceRunner()
        {
            DesiredCapabilities DesiredCapability = DesiredCapabilities.Android();
            DesiredCapability.SetCapability("deviceName", AuthConstant.HTCDesire626sDevice);
            DesiredCapability.SetCapability(CapabilityType.BrowserName, "Android");
            DesiredCapability.SetCapability(CapabilityType.Version, AuthConstant.HTCDesire626sVersionNumber);
            DesiredCapability.SetCapability("platformName", "Android");
            DesiredCapability.SetCapability("appPackage", AuthConstant.ZonePackageName);
            DesiredCapability.SetCapability("appActivity", AuthConstant.ZoneAppActivity);

            DesiredCapabilityBrowser(DesiredCapability);
        }

        public void DesiredCapabilityBrowser(DesiredCapabilities DesiredCapability)
        {
            try
            {
                driver = new RemoteWebDriver(new Uri(AuthConstant.AppiumServerURL), DesiredCapability);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(200));
            }

            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {
                if (driver != null)
                {
                    // driver.Close();
                }
            }
        }
    }
}
