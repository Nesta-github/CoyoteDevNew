#pragma checksum "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7e38e6cd0d1b345449039248af2048021fb1498"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Index), @"mvc.1.0.view", @"/Views/Login/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\_ViewImports.cshtml"
using WebNesta.Coyote.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\_ViewImports.cshtml"
using WebNesta.Coyote.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7e38e6cd0d1b345449039248af2048021fb1498", @"/Views/Login/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da64e788ddf03f5467cf3c41f48b81377d6dfc93", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Login_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebNesta.Coyote.Web.ViewModel.LoginViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/refresh.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("lkbRefreshCaptcha"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Login/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e38e6cd0d1b345449039248af2048021fb14986111", async() => {
                WriteLiteral(@"

    <!--Html.AntiForgeryToken() -->
    <div class=""row"" style=""padding-left: 50px; padding-right: 50px; margin-top: -10px;"">
        <label class=""titulo"">Login</label>
    </div>

    <div class=""row m-3"">
        <a href=""#"" class=""m-auto ajuda"" id=""btnAjudaLogin"">

            <span>");
#nullable restore
#line 21 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml"
             Write(WebNesta.Coyote.Web.App_GlobalResources.Login.ResourceManager.GetString("label_1"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span><i class=""fas fa-question-circle ml-2""></i>
        </a>
    </div>

    <div style=""display:none"" class=""row justify-content-center"">
        <!--Url.Action(""SignIn"", ""Login"",new { provider = ""google"" })-->
        <a href=""/Login/SignIn?provider=google"" class=""col-5 btn_login_external mr-2"">
            <p>Google</p>
            <i class=""fab fa-google""></i>
        </a>

        <a href=""/Login/SignIn?provider=azure"" class=""col-5 btn_login_external ml-2"">
            <p>AD Azure</p>
            <i class=""fab fa-microsoft""></i>
        </a>

    </div>
");
                WriteLiteral("\r\n    <div class=\"row\">\r\n        <div class=\"col-c1\">\r\n            <div class=\"c-left\">\r\n                <label>");
#nullable restore
#line 57 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml"
                  Write(WebNesta.Coyote.Web.App_GlobalResources.Login.ResourceManager.GetString("label_3"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@":</label>
            </div>
            <div class=""c-right"">
                <div class=""dxeTextBoxSys dxeTextBox_COYOTE dxeTextBoxDefaultWidthSys"">
                    <div class=""dxic"">
                        <input type=""text"" id=""txtLogin"" class=""dxeEditArea_COYOTE dxeEditAreaSys"" placeholder=""Clique Aqui"" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-c1"">
            <div class=""c-left"">
                <label");
                BeginWriteAttribute("class", " class=\"", 2324, "\"", 2332, 0);
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 71 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml"
                           Write(WebNesta.Coyote.Web.App_GlobalResources.Login.ResourceManager.GetString("label_4"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@":</label>
            </div>
            <div class=""c-right"">
                <div class=""dxeTextBoxSys dxeTextBox_COYOTE dxeTextBoxDefaultWidthSys"">
                    <div class=""dxic"" style=""border: none !important;width:100%;"">
                        
                        <input type=""password"" id=""txtPassword"" class=""dxeEditArea_COYOTE dxeEditAreaSys"" style=""border: none !important;"" placeholder=""Clique Aqui"" />
                    </div>
                </div>
            </div>
        </div>
    </div> 
    
    <div class=""row m-2"">
        <span class=""text-danger"">");
                WriteLiteral(@"</span>
    </div>

    <div class=""row opts-login"">
        <div class=""col-6 p-0"">
            <label id=""lblRemember"" class=""container"" style=""font-size: 12px;"">
                <input type=""checkbox"" id=""chkRemember"" name=""remember"">
                <span class=""checkmark""></span>
                ");
#nullable restore
#line 93 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml"
           Write(WebNesta.Coyote.Web.App_GlobalResources.Login.ResourceManager.GetString("label_5"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </label>\r\n        </div>\r\n        <div class=\"col-6 p-0\" style=\"font-size: 11px; text-align: right; line-height: 20px;\">\r\n            <a href=\"#\" id=\"btnEsqueciMinhaSenha\" class=\"link_esqueci\">");
#nullable restore
#line 97 "E:\ProjetoAlex\CoyoteDevNew\webnesta\WebApps\WebNesta.Coyote.Web\Views\Login\Index.cshtml"
                                                                  Write(WebNesta.Coyote.Web.App_GlobalResources.Login.ResourceManager.GetString("label_6"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n        </div>\r\n    </div>\r\n    \r\n    <div id=\"dvCaptcha\" style=\"display:none\" class=\"row\">\r\n        <div class=\"col-12\" style=\"text-align: center;\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a7e38e6cd0d1b345449039248af2048021fb149811190", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        </div>
        <div id=""dvCaptchaWords"" style=""text-align:center"" class=""col-12"">
            <div id=""imgCaptcha""></div>
        </div>
        <div class=""col-c1"">
            <div class=""c-left"">
            </div>
            <div class=""c-right"">
                <div class=""dxeTextBoxSys dxeTextBox_COYOTE dxeTextBoxDefaultWidthSys"">
                    <div class=""dxic"">
                        <input type=""text"" id=""txtCaptcha"" class=""dxeEditArea_COYOTE dxeEditAreaSys"" placeholder=""Digite o código CAPTCHA acima:"" />
                        <input type=""hidden"" id=""hfCatpchaCodeKey""/>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class=""row"">
        <input type=""button"" class=""btn_login text-center"" name=""btnLogin"" value=""Login"" id=""btnLogin"" />
        <input type=""button"" style=""display:none;"" class=""btn_login text-center"" name=""btnEntraCaptcha"" value=""Entrar"" id=""btnEntraCaptcha"" />
        <input type=""button");
                WriteLiteral("\" style=\"display:none;\" class=\"btn_login text-center\" name=\"btnCancelarCaptcha\" value=\"Cancelar\" id=\"btnCancelarCaptcha\" />\r\n    </div>\r\n\r\n");
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebNesta.Coyote.Web.ViewModel.LoginViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
