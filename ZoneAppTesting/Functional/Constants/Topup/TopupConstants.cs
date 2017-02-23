using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoneAppTesting.Functional.Settings.Topup;

namespace ZoneAppTesting.Functional.Constants.Topup
{
    [TestClass]
    public class TopupConstants
    {
        public static String TopupQuickLaunch   = TopupSettings.Default.TopupQuickLaunch;
        public static String Topup              = TopupSettings.Default.Topup;
        public static String TopupAmount        = TopupSettings.Default.TopupAmount;
        public static String TopupNextButton    = TopupSettings.Default.TopupNextButton;
        public static String Search             = TopupSettings.Default.Search;
        public static String SearchField        = TopupSettings.Default.SearchField;
        public static String PhoneNumberField   = TopupSettings.Default.PhoneNumberField;
        public static String CancelButton       = TopupSettings.Default.CancelButton;
        public static String PhoneTopupClick    = TopupSettings.Default.PhoneTopupClick;
        public static String PhoneTopupImage    = TopupSettings.Default.PhoneTopupImage;
        public static String ProceedButton      = TopupSettings.Default.ProceedButton;
        public static String TELCO              = TopupSettings.Default.TELCO;
        public static String AmountField        = TopupSettings.Default.AmountField;
        public static String SelectedTelco      = TopupSettings.Default.SelectedTelco;
        
        public static String Amount              = "100";
        public static String NonZoneUser         = "Ade House";
        public static String PhoneNumber         = "08143200200";
        public static String SelectedTELCO       = "Airtel";
    }
}
