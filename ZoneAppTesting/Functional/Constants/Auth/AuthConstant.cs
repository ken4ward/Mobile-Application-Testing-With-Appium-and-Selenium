using System;
using ZoneAppTesting.Functional.Settings.Auth;

namespace ZoneAppTesting.Functional.Constants.Auth
{
    public class AuthConstant
    {
        public static String AppiumServerURL     = AuthSettings.Default.AppiumServerURL;
        public static String GetStartedButton    = AuthSettings.Default.GetStartedButton;
        public static String GetStartedLayout    = AuthSettings.Default.GetStartedLayout;

        public static String HTCDesire626sDevice        = AuthSettings.Default.HTCDesire626sDevice;
        public static String HTCDesire626sVersionNumber = AuthSettings.Default.HTCDesire626sVersionNumber;
        public static String ZoneAppActivity            = AuthSettings.Default.ZoneAppActivity;
        public static String ZonePackageName            = AuthSettings.Default.ZonePackageName;

        public static String LoginTextPage          = AuthSettings.Default.LoginTextPage;
        public static String PasswordField          = AuthSettings.Default.PasswordField;
        public static String PhoneNumberField       = AuthSettings.Default.PhoneNumberField;
        public static String ProceedButton          = AuthSettings.Default.ProceedButton;
        public static String VerifyPasswordField    = AuthSettings.Default.VerifyPasswordField;
        public static String InviteCodeField        = AuthSettings.Default.InviteCodeField;
        public static String VerifyInviteButton     = AuthSettings.Default.VerifyInviteButton;

        public static String FirstNameField         = AuthSettings.Default.FirstNameField;
        public static String LastNameField          = AuthSettings.Default.LastNameField;
        public static String DateOfBirthField       = AuthSettings.Default.DateOfBirthField;
        public static String DatePickerYearButton   = AuthSettings.Default.DatePickerYearButton;
        public static String GenderField            = AuthSettings.Default.GenderField;
        public static String EmailField             = AuthSettings.Default.EmailField;
        public static String SignUpButton           = AuthSettings.Default.SignUpButton;
        public static String GenderSelect           = AuthSettings.Default.GenderSelect;
        
        public static String LInearLayout           = AuthExtended.Default.LInearLayout;
        public static String DateOfBirth            = AuthExtended.Default.DateOfBirth;
        public static String LinearLayoutYear       = AuthExtended.Default.LinearLayoutYear;
        public static String DatePickerYear         = AuthExtended.Default.DatePickerYear;
        public static String AddMoreAccount         = AuthExtended.Default.AddMoreAccount;
        public static String AccountNumber          = AuthExtended.Default.AccountNumber;
        public static String AddAccountButton       = AuthExtended.Default.AddAccountButton;
        public static String BankName               = AuthExtended.Default.BankName;
        public static String SelectedBankName       = AuthExtended.Default.SelectedBankName;
        public static String DoneButton             = AuthExtended.Default.DoneButton;
        
        public static String SetupButton            = AuthExtended.Default.SetupButton;
        public static String SelectorHeader         = AuthExtended.Default.SelectorHeader;

        public static String ExistingUser           = AuthExtended.Default.ExistingUser;
        public static String ContinueButton         = AuthExtended.Default.ContinueButton;

        public static String LoginLink              = AuthExtended.Default.LoginLink;
        public static String LoginButton            = AuthExtended.Default.LoginButton;
        public static String LoginPhoneNumber       = AuthExtended.Default.LoginPhoneNumber;
        public static String LoginPassword          = AuthExtended.Default.LoginPassword;

        public static String SideBar                = AuthExtended.Default.SideBar;
        public static String OldPassword            = AuthExtended.Default.OldPassword;
        public static String NewPassword            = AuthExtended.Default.NewPassword;
        public static String ConfirmNewPassword     = AuthExtended.Default.ConfirmNewPassword;
        public static String SaveNewPassowrdButton  = AuthExtended.Default.SaveNewPassowrdButton;
        public static String ChangePassword         = AuthExtended.Default.ChangePassword;
        public static String LoginPasswordField     = AuthExtended.Default.LoginPasswordField;
        public static String ReEnterPasswordButton  = AuthExtended.Default.ReEnterPasswordButton;
        public static String ForgotPasswordButton   = AuthExtended.Default.ForgotPasswordButton;

        public static String SelectProfileImage     = AuthExtended.Default.SelectProfileImage;
        public static String Camera                 = AuthExtended.Default.Camera;
        public static String Documents              = AuthExtended.Default.Documents;
        public static String Gallery                = AuthExtended.Default.Gallery;
        public static String ProfileImage           = AuthExtended.Default.ProfileImage;

        public static String SlideIcons         = AuthExtended.Default.SlideIcons;
        public static String SendSlide          = AuthExtended.Default.SendSlide;
        public static String PaySlide           = AuthExtended.Default.PaySlide;
        public static String MerchantSlide      = AuthExtended.Default.MerchantSlide;
        public static string AskSlide           = AuthExtended.Default.AskSlide;
        public static String LabelPresentOnPage = AuthExtended.Default.LabelPresentOnPage;
        public static String ZoneIcon           = AuthExtended.Default.ZoneIcon;
        public static String SelectImage        = AuthExtended.Default.SelectImage;
        public static String AccountEmail       = AuthExtended.Default.AccountEmail;
        public static String AllowAccessEmail   = AuthExtended.Default.AllowAccessEmail;
        public static String DenyAccessEmail    = AuthExtended.Default.DenyAccessEmail;
        
        public static String GoogleSignup        = AuthExtended.Default.GoogleSignup;
        public static String FacebookSignup      = AuthExtended.Default.FacebookSignup;
        public static String FacebookLoginButton = AuthExtended.Default.FacebookLoginButton;
        public static String FacebookPassword    = AuthExtended.Default.FacebookPassword;
        public static String FacebookUsername    = AuthExtended.Default.FacebookUsername;
        public static String FBUsername = "ken4ward@yahoo.com";
        public static String FBPassword = "f201115@Adea";

        public static String FirstName          = "Akehindegbegbon";
        public static String LastName           = "Adeoya";
        public static String Email              = "kadeoya@appzonegroup.com";
        public static String ActualNumber       = "1713001424";

        public static String PhoneNumber        = "08143200203";
        public static String Password           = "abcd1234";
        public static String VerifyPassword     = "abcd1234";
        public static String NewPasswordText    = "aaaaaa";
        

        public static String Lengthier          = "123456789012345";
        public static String Shorter            = "1234567890";
        public static String SpecialCharacter   = "$%&*@<>";

        public static String SpecialCharacterWithInt    = "4.";
        public static String SpecialCharacterWithString = "@%^&*#string";
        public static String SpaceCharacter             = "123  abc";

        public static String MyInviteCode               = "z8tD";

        public static String SlidePay       = "Pay for Goods with Ease";
        public static String SlideMerchant  = "Merchant Services";
        public static String SlideAsk       = "Ask for Money from Friends";
        public static String SlideSend      = "Send Money to Friends";
    }

    public class AuthValidation
    {
        public static String ImageContainerValidation = AuthSettings.Default.ImageContainerValidation;
    }
}
