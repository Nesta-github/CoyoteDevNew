//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebNesta.Coyote.Geral.Domain.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Login {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Login() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebNesta.Coyote.Geral.Domain.Resource.Login", typeof(Login).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;b&gt;Hello, Coyote user!&lt;/b&gt;&lt;br /&gt;You have requested to reset your Coyote Contracts login password.&lt;/p&gt;.
        /// </summary>
        internal static string login_email_subject_recuperacao_senha {
            get {
                return ResourceManager.GetString("login_email_subject_recuperacao_senha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;br /&gt;&lt;br /&gt;&lt;p&gt; This is your temporary password to access the system:.
        /// </summary>
        internal static string login_email_text_recuperacao_senha {
            get {
                return ResourceManager.GetString("login_email_text_recuperacao_senha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password Recovery.
        /// </summary>
        internal static string login_label_recuperacao_senha {
            get {
                return ResourceManager.GetString("login_label_recuperacao_senha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email not registered..
        /// </summary>
        internal static string login_validacao_email_nao_cadastrado {
            get {
                return ResourceManager.GetString("login_validacao_email_nao_cadastrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email must be filled in..
        /// </summary>
        internal static string login_validacao_email_preenchido {
            get {
                return ResourceManager.GetString("login_validacao_email_preenchido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email sent with temporary password..
        /// </summary>
        internal static string login_whatsapp_senha_enviada {
            get {
                return ResourceManager.GetString("login_whatsapp_senha_enviada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to System access password has been recovered. \n*{0}*.
        /// </summary>
        internal static string login_whatsapp_text_recuperacao_senha {
            get {
                return ResourceManager.GetString("login_whatsapp_text_recuperacao_senha", resourceCulture);
            }
        }
    }
}
