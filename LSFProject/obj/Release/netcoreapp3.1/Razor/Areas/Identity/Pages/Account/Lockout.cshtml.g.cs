#pragma checksum "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Lockout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41d31a61bfd853d3074896bae4e54e0b4b2dc068"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Lockout), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Lockout.cshtml")]
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
#line 1 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\_ViewImports.cshtml"
using LSFProject.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\_ViewImports.cshtml"
using LSFProject.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using LSFProject.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41d31a61bfd853d3074896bae4e54e0b4b2dc068", @"/Areas/Identity/Pages/Account/Lockout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"690f0c03cff09229d375cf4cc01b1aeca9469723", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"345480b56f5ec35b5d49d6c1d11ff9143a648505", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Lockout : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/bg/stop_mvd.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-left: 30px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Lockout.cshtml"
  
    ViewData["Title"] = "Аккаунт заблокирован";
    string years = (Model.lockoutEndTime.Value.Days / 365).ToString();
    string days = (Model.lockoutEndTime.Value.Days % 365).ToString();
    string hourse = Model.lockoutEndTime.Value.Hours.ToString();
    string minute = Model.lockoutEndTime.Value.Minutes.ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid container-fluid-site text-center\" style=\"margin-top: 100px; margin-bottom: 100px;\">\r\n    <div>\r\n        <h1 class=\"text-danger\">");
#nullable restore
#line 13 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Lockout.cshtml"
                           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <h2 class=\"text-center text-danger\">До конца блокировки осталось: ");
#nullable restore
#line 14 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Lockout.cshtml"
                                                                     Write(years);

#line default
#line hidden
#nullable disable
            WriteLiteral(" лет ");
#nullable restore
#line 14 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Lockout.cshtml"
                                                                                Write(days);

#line default
#line hidden
#nullable disable
            WriteLiteral(" дней ");
#nullable restore
#line 14 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Lockout.cshtml"
                                                                                           Write(hourse);

#line default
#line hidden
#nullable disable
            WriteLiteral(" часов ");
#nullable restore
#line 14 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Lockout.cshtml"
                                                                                                         Write(minute);

#line default
#line hidden
#nullable disable
            WriteLiteral(" минут</h2>\r\n        <p class=\"text-danger\" style=\"font-size: 20px;\">К сожалению, Ваш аккаунт заблокирован, на срок 200 лет!<br />При воможности, свяжитесь с администрацией сайта, для уточнения причины.</p>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "41d31a61bfd853d3074896bae4e54e0b4b2dc0687105", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LockoutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LockoutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LockoutModel>)PageContext?.ViewData;
        public LockoutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
