#pragma checksum "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6359194c97aeb730759e1badbe17e7a47965812a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6359194c97aeb730759e1badbe17e7a47965812a", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5296f2d385c72929854e4cece82adc00d35e2164", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WEB2020Apr_P06_T02.Models.FlightViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Book", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
  
    ViewData["Title"] = "Lion City Airlines | Flight Results";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<br />\n<h1>");
#nullable restore
#line 8 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
Write(TempData["DepartureCountry"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" to ");
#nullable restore
#line 8 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                                Write(TempData["ArrivalCountry"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n<hr />\n<h4>Flight Results</h4>\n");
#nullable restore
#line 11 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""table-responsive"">
        <table id=""search"" class=""table table-striped table-bordered"">
            <thead class=""thead-dark"">
                <tr>
                    <th>From</th>
                    <th>To</th>
                    <th>Departure DateTime</th>
                    <th>Economy Class Price</th>
                    <th>Business Class Price</th>
                    <th>Status</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 27 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>");
#nullable restore
#line 30 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                       Write(item.FlightRoute.DepartureCity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 31 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                       Write(item.FlightRoute.ArrivalCity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 32 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                       Write(item.FlightSchedule.DepartureDateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 33 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                       Write(item.FlightSchedule.EconomyClassPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 34 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                       Write(item.FlightSchedule.BusinessClassPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 35 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                       Write(item.FlightSchedule.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 36 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                         if (item.FlightSchedule.Status == "Opened")
                        {
                            if (Context.Session.GetString("Role") != null)
                            {
                                if (Context.Session.GetString("Role") == "Customer" && (item.FlightSchedule.DepartureDateTime - DateTime.Now).TotalDays > 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6359194c97aeb730759e1badbe17e7a47965812a9079", async() => {
                WriteLiteral("Book");
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
#line 44 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                                             WriteLiteral(item.FlightSchedule.ScheduleId);

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
            WriteLiteral("\n                                    </td>\n");
#nullable restore
#line 46 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                                }
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>Please sign in to book</td>\n");
#nullable restore
#line 51 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                            }

                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>No bookings allowed</td>\n");
#nullable restore
#line 57 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\n");
#nullable restore
#line 59 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </tbody>\n        </table>\n    </div>\n");
#nullable restore
#line 64 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span style=\"color:red\">No record found!</span>\n");
#nullable restore
#line 68 "C:\Users\tanyo\OneDrive\Desktop\tanyongde-web2020apr_p06_t02-1af3e482933b\WEB2020Apr_P06_T02\WEB2020Apr_P06_T02\Views\Home\Search.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WEB2020Apr_P06_T02.Models.FlightViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591