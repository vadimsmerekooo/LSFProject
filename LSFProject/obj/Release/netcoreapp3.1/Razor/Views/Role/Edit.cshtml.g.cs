#pragma checksum "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83f1684814949d2acce46b452a83423bf8d01667"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Edit), @"mvc.1.0.view", @"/Views/Role/Edit.cshtml")]
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
#line 1 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\_ViewImports.cshtml"
using LSFProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\_ViewImports.cshtml"
using LSFProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83f1684814949d2acce46b452a83423bf8d01667", @"/Views/Role/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8e64e53f0ea5e29e5c4992ad57ccdd7e6f23037", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChangeRoleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./UserList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
  
    ViewData["Title"] = "Изменение роли";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid container-fluid-site\">\r\n    <h2>Изменение ролей для пользователя ");
#nullable restore
#line 9 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
                                    Write(Model.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83f1684814949d2acce46b452a83423bf8d016675391", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 324, "\"", 345, 1);
#nullable restore
#line 12 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
WriteAttributeValue("", 332, Model.UserId, 332, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <div class=\"form-group\">\r\n");
#nullable restore
#line 14 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
             foreach (IdentityRole role in Model.AllRoles)
            {
                if (role.Name != "Admin" && User.IsInRole("Admin"))
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"checkbox\" name=\"roles\"");
                BeginWriteAttribute("value", " value=\"", 603, "\"", 621, 1);
#nullable restore
#line 18 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
WriteAttributeValue("", 611, role.Name, 611, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                           ");
#nullable restore
#line 19 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
                       Write(Model.UserRoles.Contains(role.Name) ? "checked=\"checked\"" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(" /> ");
#nullable restore
#line 19 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
                                                                                             Write(role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <br />\r\n");
#nullable restore
#line 20 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Views\Role\Edit.cshtml"
                }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n        <button type=\"submit\" class=\"btn btn-primary\">Сохранить</button>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83f1684814949d2acce46b452a83423bf8d016677860", async() => {
                    WriteLiteral("Назад к списку пользователей");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChangeRoleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
