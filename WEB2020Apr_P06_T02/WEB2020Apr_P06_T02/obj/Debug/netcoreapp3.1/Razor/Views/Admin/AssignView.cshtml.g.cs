#pragma checksum "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0283da035e1135f373f85a8b9adcc1ed36f2c6bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AssignView), @"mvc.1.0.view", @"/Views/Admin/AssignView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0283da035e1135f373f85a8b9adcc1ed36f2c6bb", @"/Views/Admin/AssignView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5296f2d385c72929854e4cece82adc00d35e2164", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AssignView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WEB2020Apr_P06_T02.Models.AssignViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AssignView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Admin/_ViewFlightCrew.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/StaffMain"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
  
    ViewData["Title"] = "View Route and Schedule";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h4 class=""PageTitle"">View Schedule</h4>
<!-- Display a list of RouteID -->
<div class=""table-responsive"">
    <table id=""viewSchedule"" class=""table table-striped table-bordered"">
        <thead class=""thead-dark"">
            <tr>
                <th>Schedule ID</th>
                <th>Flight Number</th>
                <th>Statue</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 18 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
             foreach (var item in Model.FlightScheduleList)
            {
                string selectedRow = "";
                if (ViewData["selectedScheduleId"].ToString()
                 == item.RouteId.ToString())
                {
                    // Highlight the selected row
                    selectedRow = "class='table-primary'";
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr ");
#nullable restore
#line 27 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
               Write(Html.Raw(selectedRow));

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    <td>");
#nullable restore
#line 28 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
                   Write(item.ScheduleId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 29 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
                   Write(item.FlightNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 30 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
                   Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                    <td>\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0283da035e1135f373f85a8b9adcc1ed36f2c6bb7829", async() => {
                WriteLiteral("View Crew");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
                             WriteLiteral(item.ScheduleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </td>\n                </tr>\n");
#nullable restore
#line 37 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n</div>\n<!-- Display a list of Schedule ID for each RouteID -->\n");
#nullable restore
#line 42 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
 if (ViewData["selectedScheduleId"].ToString() != "")
{
    if (Model.FlightCrewList.Count != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h5>\n            Flight Crew in ScheduleID\n            ");
#nullable restore
#line 48 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
       Write(ViewData["selectedScheduleId"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" :\n        </h5>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0283da035e1135f373f85a8b9adcc1ed36f2c6bb11421", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 51 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 52 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h5>NO FLIGHT CREW!</h5>\n");
#nullable restore
#line 56 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Admin\AssignView.cshtml"
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0283da035e1135f373f85a8b9adcc1ed36f2c6bb13631", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WEB2020Apr_P06_T02.Models.AssignViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
