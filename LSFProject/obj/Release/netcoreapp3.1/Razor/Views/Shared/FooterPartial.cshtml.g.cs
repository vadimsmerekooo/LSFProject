#pragma checksum "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8738a7f1aafc8990d15c326a2d2f78d71d791bca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_FooterPartial), @"mvc.1.0.view", @"/Views/Shared/FooterPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\GitHub\LSFProject\LSFProject\Views\_ViewImports.cshtml"
using LSFProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\LSFProject\LSFProject\Views\_ViewImports.cshtml"
using LSFProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
using LSFProject.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8738a7f1aafc8990d15c326a2d2f78d71d791bca", @"/Views/Shared/FooterPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8e64e53f0ea5e29e5c4992ad57ccdd7e6f23037", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_FooterPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "NewsDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
  
    LSFProjectContext _context = new LSFProjectContext();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""footer-widget style-two"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-sm-6 col-lg-3 "">
                <div class=""single-widget"">
                    <h3 class=""font-green"">О нас</h3>
                    <div class=""footer-logo"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8738a7f1aafc8990d15c326a2d2f78d71d791bca5352", async() => {
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
            WriteLiteral("\r\n                    </div>\r\n                    <p class=\"footer-about-text\">");
#nullable restore
#line 15 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                                            Write(Config.SiteTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n\r\n                </div>\r\n            </div>\r\n            <div class=\"col-sm-6 col-lg-3\">\r\n                <div class=\"single-widget\">\r\n                    <h3 class=\"font-per\">Последние посты</h3>\r\n");
#nullable restore
#line 22 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                     foreach(AspNetNews newsItem in _context.AspNetNews)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"sin-post\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 940, "\"", 1045, 1);
#nullable restore
#line 25 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
WriteAttributeValue("", 946, Config.DomainName + _context.AspNetFiles.FirstOrDefault(p => p.Id == newsItem.PreviewPhoto).Path, 946, 99, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1046, "\"", 1130, 1);
#nullable restore
#line 25 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
WriteAttributeValue("", 1052, _context.AspNetFiles.FirstOrDefault(p => p.Id == newsItem.PreviewPhoto).Title, 1052, 78, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"150\">\r\n                            <div class=\"post-brif\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8738a7f1aafc8990d15c326a2d2f78d71d791bca8299", async() => {
#nullable restore
#line 27 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                                                                                                           Write(newsItem.PreviewText);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-url", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                                                                                     WriteLiteral(newsItem.Url);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["url"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-url", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["url"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <p>");
#nullable restore
#line 28 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                              Write(newsItem.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 31 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
            <div class=""col-sm-6 col-lg-3"">
                <div class=""single-widget"">
                    <h3 class=""font-sky"">Последние Твиты</h3>
                    <div class=""sin-twitter"">
                        <p><a class=""twitter-icon""");
            BeginWriteAttribute("href", " href=\"", 1798, "\"", 1805, 0);
            EndWriteAttribute();
            WriteLiteral(@">Мы создали новую игру</a> Если вы еще не пробовали игру об основах безопасности жизнедеятельности, самое время попробывать! <a href=""#"">LSFProject/KSFJ2kfSF</a>  </p>
                    </div>
                </div>
            </div>
            <div class=""col-sm-6 col-lg-3"">
                <div class=""single-widget"">
                    <h3 class=""font-orange"">Контакты</h3>
                    <div class=""footer-contact"">
                        <div class=""sin-con"">
                            <i class=""fa fa-instagram""></i>
                            <p><a");
            BeginWriteAttribute("href", " href=\"", 2387, "\"", 2406, 1);
#nullable restore
#line 48 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
WriteAttributeValue("", 2394, Config.Inst, 2394, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 48 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                                                 Write(Config.InstTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n                        </div>\r\n                        <div class=\"sin-con\">\r\n                            <i class=\"fa fa-phone\"></i>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2601, "\"", 2623, 2);
            WriteAttributeValue("", 2608, "tel:", 2608, 4, true);
#nullable restore
#line 52 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
WriteAttributeValue("", 2612, Config.Tel, 2612, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 52 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                                                 Write(Config.Tel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </div>\r\n                        <div class=\"sin-con\">\r\n                            <i class=\"fa fa-envelope\"></i>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 2811, "\"", 2837, 2);
            WriteAttributeValue("", 2818, "mailto:", 2818, 7, true);
#nullable restore
#line 56 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
WriteAttributeValue("", 2825, Config.Mail, 2825, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 56 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                                                     Write(Config.Mail);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!--Footer widget area end-->
<!--Footer area start-->
<div class=""footer-area"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-sm-12 col-md-6"">
                <p>&copy; ");
#nullable restore
#line 70 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                     Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 70 "D:\GitHub\LSFProject\LSFProject\Views\Shared\FooterPartial.cshtml"
                                        Write(Config.SiteHeader);

#line default
#line hidden
#nullable disable
            WriteLiteral(". Разработка - Дипломный проект(\"Вадим&Дима\")</p>\r\n            </div>\r\n            <div class=\"col-sm-12 col-md-6\">\r\n                <ul class=\"social-icon float-right\">\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3449, "\"", 3456, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-youtube\"></i></a></li>\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3524, "\"", 3531, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-behance\"></i></a></li>\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3599, "\"", 3606, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-linkedin\"></i></a></li>\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3675, "\"", 3682, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-instagram\"></i></a></li>\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3752, "\"", 3759, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-twitter\"></i></a></li>\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 3827, "\"", 3834, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-facebook\"></i></a></li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
