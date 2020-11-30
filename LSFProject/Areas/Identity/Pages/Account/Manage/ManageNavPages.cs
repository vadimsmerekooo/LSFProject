using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string Email => "Email";

        public static string ChangePassword => "ChangePassword";

        public static string DownloadPersonalData => "DownloadPersonalData";

        public static string DeletePersonalData => "DeletePersonalData";

        public static string ExternalLogins => "ExternalLogins";

        public static string PersonalData => "PersonalData";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";
        public static string Role => "Role";
        public static string UserList => "UserList";
        public static string EditRolesUser => "EditRolesUser";
        public static string CreateRole => "CreateRole";
        public static string Posts => "Posts";
        public static string AddedPost => "AddedPost";
        public static string RemovePosts => "RemovePosts";
        public static string Sliders => "Sliders"; 

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string DownloadPersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DownloadPersonalData);

        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        public static string RoleNavClass(ViewContext viewContext) => PageNavClass(viewContext, Role);

        public static string UserListNavClass(ViewContext viewContext) => PageNavClass(viewContext, UserList); 

        public static string EditRolesUserNavClass(ViewContext viewContext) => PageNavClass(viewContext, EditRolesUser);

        public static string CreateRoleNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateRole);
        public static string PostsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Posts);
        public static string AddedPostNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddedPost);
        public static string RemovePostsNavClass(ViewContext viewContext) => PageNavClass(viewContext, RemovePosts); 
        public static string SlidersNavClass(ViewContext viewContext) => PageNavClass(viewContext, Sliders);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
