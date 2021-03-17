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
        public static string Role => "Role";
        public static string UserList => "UserList";
        public static string EditRolesUser => "EditRolesUser";
        public static string CreateRole => "CreateRole";
        public static string Posts => "Posts";
        public static string Files => "Files";
        public static string UploadPhoto => "UploadPhoto";
        public static string AddedPost => "AddedPost";
        public static string RemovePosts => "RemovePosts";
        public static string Sliders => "Sliders";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
        public static string RoleNavClass(ViewContext viewContext) => PageNavClass(viewContext, Role);
        public static string UserListNavClass(ViewContext viewContext) => PageNavClass(viewContext, UserList);
        public static string EditRolesUserNavClass(ViewContext viewContext) => PageNavClass(viewContext, EditRolesUser);
        public static string CreateRoleNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateRole);
        public static string PostsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Posts);
        public static string AddedPostNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddedPost);
        public static string FilesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Files);
        public static string UploadPhotoNavClass(ViewContext viewContext) => PageNavClass(viewContext, UploadPhoto);
        public static string RemovePostsNavClass(ViewContext viewContext) => PageNavClass(viewContext, RemovePosts); 
        public static string SlidersNavClass(ViewContext viewContext) => PageNavClass(viewContext, Sliders);




        public static string AspNetTargets => "AspNetTargets";
        public static string AddAspNetTarget => "AddAspNetTarget";
        public static string Znaks => "Znaks";
        public static string UploadZnaks => "UploadZnaks";
        public static string TargetsNavClass(ViewContext viewContext) => PageNavClass(viewContext, AspNetTargets);
        public static string AddTargetNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddAspNetTarget);
        public static string ZnaksNavClass(ViewContext viewContext) => PageNavClass(viewContext, Znaks);
        public static string UploadZnaksNavClass(ViewContext viewContext) => PageNavClass(viewContext, UploadZnaks);




        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
