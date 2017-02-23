using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoneAppTesting.Functional.Settings.Merchant;

namespace ZoneAppTesting.Functional.Constants.Merchant
{
    public class MerchantConstant
    {
        public static String Merchant               = MerchantSettings.Default.Merchant;
        public static String NextButton             = MerchantSettings.Default.NextButton;
        public static String PayButton              = MerchantSettings.Default.PayButton;
        public static String PaymentItemSelect      = MerchantSettings.Default.PaymentItemSelect;
        public static String AmountField            = MerchantSettings.Default.AmountField;
        public static String CustomerIDField        = MerchantSettings.Default.CustomerIDField;
        public static String SelectedMerchant       = MerchantSettings.Default.SelectedMerchant;
        public static String SelectedPaymentItem    = MerchantSettings.Default.SelectedPaymentItem;
        public static String SubscriptionButton     = MerchantSettings.Default.SubscriptionButton;
        public static String TransactionSummary     = MerchantSettings.Default.TransactionSummary;
        public static String SummaryElements        = MerchantSettings.Default.SummaryElements;

        public static String RealMerchant       = "Swift";
        public static String CustomerID         = "123456";
        public static String SubscriptionText   = "Swift 4G Subscription";
        public static String RealSelected       = "Swift Services~";
        public static String TransactionFee = "100";
        public static String Amount = "100";
    }
}
