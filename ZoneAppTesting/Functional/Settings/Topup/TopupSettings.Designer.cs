﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZoneAppTesting.Functional.Settings.Topup {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class TopupSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static TopupSettings defaultInstance = ((TopupSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new TopupSettings())));
        
        public static TopupSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.Button[@text=\'Top-Up\' and @index=\'3\']")]
        public string TopupQuickLaunch {
            get {
                return ((string)(this["TopupQuickLaunch"]));
            }
            set {
                this["TopupQuickLaunch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.Button[@text=\'Top-Up\' and @index=\'0\']")]
        public string Topup {
            get {
                return ((string)(this["Topup"]));
            }
            set {
                this["Topup"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.EditText[@text=\'Enter Amount\' and @index=\'1\']")]
        public string TopupAmount {
            get {
                return ((string)(this["TopupAmount"]));
            }
            set {
                this["TopupAmount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.Button[@text=\'Next\' and @index=\'0\']")]
        public string TopupNextButton {
            get {
                return ((string)(this["TopupNextButton"]));
            }
            set {
                this["TopupNextButton"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.TextView[@content-desc=\'Phone Number\' and @index=\'0\']")]
        public string Search {
            get {
                return ((string)(this["Search"]));
            }
            set {
                this["Search"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("com.appzonegroup.dejavuandroid.zoneRevamp:id/search")]
        public string SearchField {
            get {
                return ((string)(this["SearchField"]));
            }
            set {
                this["SearchField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.ImageView[@index=\'1\']")]
        public string PhoneTopupImage {
            get {
                return ((string)(this["PhoneTopupImage"]));
            }
            set {
                this["PhoneTopupImage"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.TextView[@text=\'Phone Number\' and @index=\'0\']")]
        public string PhoneTopupClick {
            get {
                return ((string)(this["PhoneTopupClick"]));
            }
            set {
                this["PhoneTopupClick"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.EditText[@index=\'0\']")]
        public string PhoneNumberField {
            get {
                return ((string)(this["PhoneNumberField"]));
            }
            set {
                this["PhoneNumberField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.Button[@text=\'Proceed\' and @index=\'2\']")]
        public string ProceedButton {
            get {
                return ((string)(this["ProceedButton"]));
            }
            set {
                this["ProceedButton"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.Button[@text=\'Cancel\' and @index=\'1\']")]
        public string CancelButton {
            get {
                return ((string)(this["CancelButton"]));
            }
            set {
                this["CancelButton"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.ImageView[@index=\'1\']")]
        public string TELCO {
            get {
                return ((string)(this["TELCO"]));
            }
            set {
                this["TELCO"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.EditText[@text=\'Enter Amount\' and @index=\'1\']")]
        public string AmountField {
            get {
                return ((string)(this["AmountField"]));
            }
            set {
                this["AmountField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("//android.widget.TextView[@index=\'0\']")]
        public string SelectedTelco {
            get {
                return ((string)(this["SelectedTelco"]));
            }
            set {
                this["SelectedTelco"] = value;
            }
        }
    }
}
