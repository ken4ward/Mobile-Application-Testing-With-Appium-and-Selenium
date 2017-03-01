using System;
using OpenQA.Selenium;
using ZoneAppTesting.Functional.Reusables.AuthReusables;
using ZoneAppTesting.Functional.Constants.Auth;
using OpenQA.Selenium.Appium.Android;
using ZoneAppTesting.Functional.Utils.Auth;

namespace ZoneAppTesting.Functional.Suits.Auth
{
    public class AuthSuit : Base.Base
    {
        AuthReusables AuthReusables;
        
        public AuthSuit() { }
        public AuthSuit(AndroidDriver<IWebElement> driver) : base(driver) { }

        public static String[] ParametersValuesOne = { AuthConstant.PhoneNumber, AuthConstant.Lengthier };
        public static String[] ParameterValaueTwo = {AuthConstant.Password, AuthConstant.Shorter };
        public static String[] ParameterValueThree = {AuthConstant.VerifyPassword, AuthConstant.SpaceCharacter };

        public void ZoneLoginParams()
        {
            AuthReusables = new AuthReusables(_driver);
            foreach(string valueOne in ParametersValuesOne)
            {
                foreach(string valueTwo in ParameterValaueTwo)
                {
                    foreach (string valueThree in ParameterValueThree)
                    {
                        AuthReusables.ZoneAuthentication(valueOne, valueTwo, valueThree);
                    }
                }
            }
        }

        public void ProfilePageRegistration(String FirstName, String LastName, String Email)
        {
            if (CheckIfElementExist(AuthConstant.ContinueButton) == true) { _driver.FindElementByXPath(AuthConstant.ContinueButton).Click(); }
            if (CheckIfElementExist(AuthConstant.ReEnterPasswordButton) == true) { _driver.FindElementByXPath(AuthConstant.ReEnterPasswordButton).Click(); }

            _driver.FindElementByXPath(AuthConstant.FirstNameField).Clear();
            _driver.FindElementByXPath(AuthConstant.FirstNameField).SendKeys(FirstName);

            _driver.FindElementByXPath(AuthConstant.LastNameField).Clear();
            _driver.FindElementByXPath(AuthConstant.LastNameField).SendKeys(LastName);

            _driver.FindElementByXPath(AuthConstant.EmailField).Clear();
            _driver.FindElementByXPath(AuthConstant.EmailField).SendKeys(Email);

            _driver.FindElementByXPath(AuthConstant.GenderField).Click();
            _driver.FindElementByXPath(AuthConstant.LInearLayout).Click();
            _driver.FindElementById(AuthConstant.DateOfBirth).Click();

            int counter = 0;
            while (counter < 10)
            {
                SelectDateOfBirth(AuthConstant.LinearLayoutYear, AuthConstant.DatePickerYear);
                counter++;
            }
            DoneAndSignUp(AuthConstant.DoneButton, AuthConstant.SignUpButton);
            AddBankAccount(AuthConstant.AddMoreAccount, AuthConstant.AccountNumber, AuthConstant.ActualNumber,
                AuthConstant.BankName, AuthConstant.SelectedBankName, AuthConstant.AddAccountButton);
            SetDefaultAccount(AuthConstant.SelectorHeader, AuthConstant.SetupButton);
        }

        public void SocialSignup(String SocialIcon, String DateFieldVisible, String FirstNameField, String LastNameField, String EmailField, String SignupButton)
        {
            new AuthUtils(_driver).WaitPageLoadByXPath(DateFieldVisible);
            DateOfBirthAndGender();
            if (FirstNameField != String.Empty && LastNameField != String.Empty && EmailField != String.Empty)
            {
                _driver.FindElementByXPath(SignupButton).Click();
            }
        }

        public void DateOfBirthAndGender()
        {
            _driver.FindElementByXPath(AuthConstant.GenderField).Click();
            _driver.FindElementByXPath(AuthConstant.LInearLayout).Click();
            _driver.FindElementById(AuthConstant.DateOfBirth).Click();

            int counter = 0;
            while (counter < 10)
            {
                SelectDateOfBirth(AuthConstant.LinearLayoutYear, AuthConstant.DatePickerYear);
                counter++;
            }
            DoneAndSignUp(AuthConstant.DoneButton, AuthConstant.SignUpButton);
            AddBankAccount(AuthConstant.AddMoreAccount, AuthConstant.AccountNumber, AuthConstant.ActualNumber,
                AuthConstant.BankName, AuthConstant.SelectedBankName, AuthConstant.AddAccountButton);
            SetDefaultAccount(AuthConstant.SelectorHeader, AuthConstant.SetupButton);
        }

        public void SelectDateOfBirth(String LinearLayoutYear, String DatePickerYear)
        {
            _driver.FindElementByXPath(LinearLayoutYear).Click();
            _driver.FindElementById(DatePickerYear).Click();
        }

        public void AddBankAccount(String AddMoreAccount, String AccountNumber, String ActualNumber, String BankName, String SelectedBankName, String AddAccountButton)
        {
            _driver.FindElementById(AddMoreAccount).Click();
            _driver.FindElementById(AccountNumber).SendKeys(ActualNumber);
            _driver.FindElementById(BankName).Click();
            _driver.FindElementByXPath(SelectedBankName).Click();
            _driver.FindElementById(AddAccountButton).Click();
        }

        public void SetDefaultAccount(String SelectorHeader, String SetupButton)
        {
            _driver.FindElementById(SelectorHeader).Click();
            _driver.FindElementById(SetupButton).Clear();
        }

        public void DoneAndSignUp(String DoneButton, String SignupButton)
        {
            _driver.FindElementById(DoneButton).Click();
            _driver.FindElementByXPath(SignupButton).Click();
        }

        public Boolean CheckIfElementExist(String CheckForElement)
        {
            try
            {
                _driver.FindElementByXPath(CheckForElement);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
    }
}
