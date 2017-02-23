using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoneAppTesting.Functional.Settings.Ask;

namespace ZoneAppTesting.Functional.Constants.Ask
{
    [TestClass]
    public class AskConstants
    {
        public static String AskDescription         = AskSettings.Default.AskDescription;
        public static String AskAddImage            = AskSettings.Default.AskAddImage;
        public static String AskAmount              = AskSettings.Default.AskAmount;
        public static String AskButton              = AskSettings.Default.AskButton;
        public static String AskButtonGo            = AskSettings.Default.AskButtonGo;
        public static String SelectImageGallery     = AskSettings.Default.SelectImageGallery;
        public static String ImageViewGallery       = AskSettings.Default.ImageViewGallery;
        public static String AskFromInside          = AskSettings.Default.AskFromInside;
        public static String GlobalContactList      = AskSettings.Default.GlobalContactList;
        public static String AskQuickLaunch         = AskSettings.Default.AskQuickLaunch;

        public static String Description = "I found this nice on Zone marketplace, kindly assist in paying for it.";
        public static String Amount = "100";
    }
}
