#pragma checksum "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11c5a8c7a88b68b88f637734b49a0a6804b46ab4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Manage_EditRolesUser), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Manage/EditRolesUser.cshtml")]
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
#line 3 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11c5a8c7a88b68b88f637734b49a0a6804b46ab4", @"/Areas/Identity/Pages/Account/Manage/EditRolesUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"690f0c03cff09229d375cf4cc01b1aeca9469723", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"345480b56f5ec35b5d49d6c1d11ff9143a648505", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a28a5a4a24f50c19f2ce68db567d61a935d09bda", @"/Areas/Identity/Pages/Account/Manage/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Manage_EditRolesUser : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./UserList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "EditRolesUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 5 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
  
    ViewData["Title"] = "Изменение роли";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid container-fluid-site\">\r\n    <h2>Изменение ролей для пользователя ");
#nullable restore
#line 10 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
                                    Write(Model.modelRole.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11c5a8c7a88b68b88f637734b49a0a6804b46ab46601", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 355, "\"", 386, 1);
#nullable restore
#line 13 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
WriteAttributeValue("", 363, Model.modelRole.UserId, 363, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <div class=\"form-group\">\r\n");
#nullable restore
#line 15 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
             foreach (IdentityRole role in Model.modelRole.AllRoles)
            {
                if (role.Name == "Admin" && !User.IsInRole("Admin"))
                {

                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <hr />\r\n                    <div style=\"display: inline-flex;\">\r\n                        <input type=\"checkbox\"  name=\"roles\"");
                BeginWriteAttribute("value", " value=\"", 807, "\"", 825, 1);
#nullable restore
#line 25 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
WriteAttributeValue("", 815, role.Name, 815, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                               ");
#nullable restore
#line 26 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
                           Write(Model.modelRole.UserRoles.Contains(role.Name) ? "checked=\"checked\"" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(" style=\"margin-top: 5px;\"/> <h5 style=\"margin-left: 15px;\"> ");
#nullable restore
#line 26 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
                                                                                                                                                                   Write(role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h5>\r\n                    </div>\r\n                    <br />\r\n");
#nullable restore
#line 29 "C:\Users\Vadim\Desktop\GitHub\LSFProject\LSFProject\Areas\Identity\Pages\Account\Manage\EditRolesUser.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n        <button type=\"submit\" class=\"btn btn-primary\">Сохранить</button>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "11c5a8c7a88b68b88f637734b49a0a6804b46ab49664", async() => {
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditRolesUserModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EditRolesUserModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<EditRolesUserModel>)PageContext?.ViewData;
        public EditRolesUserModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
