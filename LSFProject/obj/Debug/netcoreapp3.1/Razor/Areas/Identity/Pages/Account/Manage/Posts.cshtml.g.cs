#pragma checksum "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98559e718bed0eb620f47ff7c25d07e05e221d7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage_Posts), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/Posts.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\_ViewImports.cshtml"
using LSFProject.Areas.Identity.Pages.Account.Manage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
using LSFProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98559e718bed0eb620f47ff7c25d07e05e221d7a", @"/Areas/Identity/Pages/Account/Manage/Posts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"690f0c03cff09229d375cf4cc01b1aeca9469723", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"345480b56f5ec35b5d49d6c1d11ff9143a648505", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a28a5a4a24f50c19f2ce68db567d61a935d09bda", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_Posts : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StatusMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/admin-panel/No-button.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/admin-panel/Yes-button.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "ChangeNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "PublishNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "BlockedNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "DeleteNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
  
    ViewData["Title"] = "Новости";
    LSFProjectContext _context = new LSFProjectContext();

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>");
#nullable restore
#line 8 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98559e718bed0eb620f47ff7c25d07e05e221d7a8689", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 9 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.StatusMessage;

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
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Автор</th>
            <th scope=""col"">Заголовок</th>
            <th scope=""col"">Лайки</th>
            <th scope=""col"">Репосты</th>
            <th scope=""col"">Дата</th>
            <th scope=""col"">Просмотры</th>
            <th scope=""col"">Изображение</th>
            <th scope=""col"">Статус</th>
            <th scope=""col""></th>
            <th scope=""col""></th>
            <th scope=""col""></th>
            <th scope=""col""></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 29 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
         foreach (var newsItem in _context.News.Where(news => !news.Blocked).ToList())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"text-center\">\r\n                <th scope=\"row\"><a");
            BeginWriteAttribute("href", " href=\"", 1073, "\"", 1141, 1);
#nullable restore
#line 32 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1080, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1080, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                                                   Write(newsItem.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></th>\r\n                <th><a");
            BeginWriteAttribute("href", " href=\"", 1188, "\"", 1256, 1);
#nullable restore
#line 33 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1195, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1195, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 33 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                                       Write(newsItem.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></th>\r\n                <th><a");
            BeginWriteAttribute("href", " href=\"", 1307, "\"", 1375, 1);
#nullable restore
#line 34 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1314, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1314, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 34 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                                       Write(newsItem.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></th>\r\n                <th><a");
            BeginWriteAttribute("href", " href=\"", 1426, "\"", 1494, 1);
#nullable restore
#line 35 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1433, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1433, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 35 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                                       Write(newsItem.Likes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></th>\r\n                <th><a");
            BeginWriteAttribute("href", " href=\"", 1544, "\"", 1612, 1);
#nullable restore
#line 36 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1551, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1551, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 36 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                                       Write(newsItem.Share);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></th>\r\n                <th><a");
            BeginWriteAttribute("href", " href=\"", 1662, "\"", 1730, 1);
#nullable restore
#line 37 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1669, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1669, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 37 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                                       Write(newsItem.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></th>\r\n                <th><a");
            BeginWriteAttribute("href", " href=\"", 1779, "\"", 1847, 1);
#nullable restore
#line 38 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1786, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1786, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 38 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                                       Write(newsItem.Watching);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></th>\r\n                <th><a");
            BeginWriteAttribute("href", " href=\"", 1900, "\"", 1968, 1);
#nullable restore
#line 39 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1907, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 1907, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("src", " src=\"", 1974, "\"", 2002, 1);
#nullable restore
#line 39 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 1980, newsItem.PreviewPhoto, 1980, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"50\" height=\"40\" /></a></th>\r\n");
#nullable restore
#line 40 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                 if (newsItem.Blocked)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98559e718bed0eb620f47ff7c25d07e05e221d7a18044", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n");
#nullable restore
#line 43 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98559e718bed0eb620f47ff7c25d07e05e221d7a19377", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n");
#nullable restore
#line 47 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th scope=\"col\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98559e718bed0eb620f47ff7c25d07e05e221d7a20679", async() => {
                WriteLiteral("Изменить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-newsId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                       WriteLiteral(newsItem.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-newsId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n");
#nullable restore
#line 49 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                 if (newsItem.Blocked)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th scope=\"col\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98559e718bed0eb620f47ff7c25d07e05e221d7a23307", async() => {
                WriteLiteral("Опубликовать");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-newsId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                            WriteLiteral(newsItem.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-newsId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n");
#nullable restore
#line 52 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <th scope=\"col\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98559e718bed0eb620f47ff7c25d07e05e221d7a25945", async() => {
                WriteLiteral("Заблокировать");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-newsId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                            WriteLiteral(newsItem.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-newsId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n                    <th scope=\"col\"><a");
            BeginWriteAttribute("href", " href=\"", 2917, "\"", 2985, 1);
#nullable restore
#line 56 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
WriteAttributeValue("", 2924, Url.Action("NewsDetails", "Home", new { url = newsItem.Url}), 2924, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-primary\">Просмотреть</a></th>\r\n");
#nullable restore
#line 57 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th scope=\"col\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98559e718bed0eb620f47ff7c25d07e05e221d7a29060", async() => {
                WriteLiteral("Удалить");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-newsId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
                                                                       WriteLiteral(newsItem.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-newsId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["newsId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n            </tr>\r\n");
#nullable restore
#line 60 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\Posts.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LSFProject.Areas.Identity.Pages.Account.Manage.PostsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LSFProject.Areas.Identity.Pages.Account.Manage.PostsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LSFProject.Areas.Identity.Pages.Account.Manage.PostsModel>)PageContext?.ViewData;
        public LSFProject.Areas.Identity.Pages.Account.Manage.PostsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
