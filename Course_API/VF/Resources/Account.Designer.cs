﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Course_API.Resources {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Account {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Account() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Course_API.Resources.Account", typeof(Account).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string IncorrectPassword {
            get {
                return ResourceManager.GetString("IncorrectPassword", resourceCulture);
            }
        }
        
        public static string UsetNotFound {
            get {
                return ResourceManager.GetString("UsetNotFound", resourceCulture);
            }
        }
        
        public static string InvalidPinCode {
            get {
                return ResourceManager.GetString("InvalidPinCode", resourceCulture);
            }
        }
        
        public static string PinCodeExpired {
            get {
                return ResourceManager.GetString("PinCodeExpired", resourceCulture);
            }
        }
        
        public static string RegisterFail {
            get {
                return ResourceManager.GetString("RegisterFail", resourceCulture);
            }
        }
        
        public static string SendPinCodeFailed {
            get {
                return ResourceManager.GetString("SendPinCodeFailed", resourceCulture);
            }
        }
    }
}
