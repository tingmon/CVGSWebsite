#pragma checksum "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02e94bb9f6a88ec6397144c8bcaa96218a082552"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Person_Profile), @"mvc.1.0.view", @"/Views/Person/Profile.cshtml")]
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
#line 1 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02e94bb9f6a88ec6397144c8bcaa96218a082552", @"/Views/Person/Profile.cshtml")]
    public class Views_Person_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary form-control spacer-bottom width-150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Person", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Wishlists", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
   Layout = "_Layout"; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
   ViewData["Title"] = Model.Person.GivenName + "s Profile"; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
 if (Model.Profile.Id == Context.Session.GetInt32("loggedInPersonID"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Your Profile</h2>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02e94bb9f6a88ec6397144c8bcaa96218a0825525381", async() => {
                WriteLiteral("Edit Profile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 9 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 12 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
   Write(Model.Profile.GivenName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \'s Profile</h2>\n");
#nullable restore
#line 13 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-group, customLoginDiv\">\n    <table>\n        <tr>\n            <th>Full Name: </th>\n            <td>");
#nullable restore
#line 18 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.GivenName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 18 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
                                    Write(Model.Profile.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\n        </tr>\n        <tr>\n            <th>Address: </th>\n            <td>");
#nullable restore
#line 22 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>City: </th>\n            <td>");
#nullable restore
#line 26 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Province: </th>\n            <td>");
#nullable restore
#line 30 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.ProvinceCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Country: </th>\n            <td>");
#nullable restore
#line 34 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.CountryCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Postal Code: </th>\n            <td>");
#nullable restore
#line 38 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Number: </th>\n            <td>");
#nullable restore
#line 42 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.LandLine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Extension: </th>\n            <td>");
#nullable restore
#line 46 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.Extension);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Fax: </th>\n            <td>");
#nullable restore
#line 50 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.Fax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Email: </th>\n            <td>");
#nullable restore
#line 54 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
           Write(Model.Profile.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n    </table>\n</div>\n");
#nullable restore
#line 58 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
 if (Model.Profile.Id == Context.Session.GetInt32("loggedInPersonID"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Your WishList</h2>\n");
#nullable restore
#line 61 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>");
#nullable restore
#line 64 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
   Write(Model.Profile.GivenName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \'s WishList</h2>\n");
#nullable restore
#line 65 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
 if (Model.Profile.Id == Context.Session.GetInt32("loggedInPersonID"))
{

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02e94bb9f6a88ec6397144c8bcaa96218a08255212617", async() => {
                WriteLiteral("Go to your wishlist");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
                                                                                                                              WriteLiteral(Model.Person.Id);

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
#nullable restore
#line 68 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
                                                                                                                                                                                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"form-group, customLoginDiv\">\n");
#nullable restore
#line 71 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
     if (Model.Wishlist.AddedGameIds.ToString().Trim() != "")
    {
        string gameTitles = ViewBag.GameTitles;
        string[] titleArray = gameTitles.Split(',');

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"tableCart\">\n    <thead>\n        <tr>\n            <th style=\"width: 82em;\">Game Title</th>\n            <th style=\"width: 10em;\">Price</th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 83 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
         foreach (var item in titleArray)
        {
            if (item != "")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td style=\"width: 82em;\">");
#nullable restore
#line 88 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
                        Write(item.Split("Price:")[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td style=\"width: 10em;\">");
#nullable restore
#line 89 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
                        Write(item.Split("Price:")[1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n</tr>                    ");
#nullable restore
#line 90 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
                         }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
#nullable restore
#line 93 "C:\Users\tingmon\Downloads\CVGS\Iteration 3\CVGS'\CVGS'\CVGS Site\Views\Person\Profile.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591