#pragma checksum "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Customer\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee9b38a2b59f0ea2c7824094475a5fde6ee0f370"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ChangePassword), @"mvc.1.0.view", @"/Views/Customer/ChangePassword.cshtml")]
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
#line 1 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\_ViewImports.cshtml"
using WEB2020Apr_P06_T02;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\_ViewImports.cshtml"
using WEB2020Apr_P06_T02.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee9b38a2b59f0ea2c7824094475a5fde6ee0f370", @"/Views/Customer/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5296f2d385c72929854e4cece82adc00d35e2164", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB2020Apr_P06_T02.Models.Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Customer/ChangePassword"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Customer\ChangePassword.cshtml"
  
    ViewData["Title"] = "Member's Area | Change Password";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<style>\n    .input {\n        margin-bottom: 20px;\n        height: 45px;\n        width: 55%;\n        font-size: 23px;\n    }\n\n    .inputWrapper label {\n        display: block;\n    }\n</style>\n\n\n<h1>Change Password</h1>\n<hr />\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee9b38a2b59f0ea2c7824094475a5fde6ee0f3705092", async() => {
                WriteLiteral(@"
    <!-- go to the customer controller and changepassword action(a method)-->
    <fieldset class=""loginFieldset"">
        <div class=""inputWrapper"">
            <label for=""currentPass"">Current Password:</label>
            <input class=""input"" type=""password"" name=""currentPass"" placeholder=""Current Password *""
                   id=""currentPass"" required /><br />
        </div>

        <div class=""inputWrapper"">
            <label for=""newPass"">New Password:</label>
            <input class=""input"" type=""password"" name=""newPass"" placeholder=""New Password *""
                   id=""newPass"" required /><br />
        </div>

        <div class=""inputWrapper"">
            <label for=""currentPass"">Confirm Password:</label>
            <input class=""input"" type=""password"" name=""confirmPass"" placeholder=""Confirm Password *""
                   id=""confirmPass"" required /><br />
        </div>
        <input type=""submit"" id=""btnChangePass"" value=""Change Password"" style=""width:30%; height:45px; font-size: 23px;"" /");
                WriteLiteral(">\n        <br />\n        <span style=\"color:red;\">");
#nullable restore
#line 44 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Customer\ChangePassword.cshtml"
                            Write(TempData["Failure"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\n        <span style=\"color:green;\">");
#nullable restore
#line 45 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Customer\ChangePassword.cshtml"
                              Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\n    </fieldset>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB2020Apr_P06_T02.Models.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
