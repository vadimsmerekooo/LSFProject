using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LSFProject.Controllers
{
    [Authorize(Roles = ("Admin,Manager"))]
    public class UpdateInputController : Controller
    {
        public ActionResult UpdatePhotoInput()
        {
            string resultHtmlList = string.Empty;
            foreach (AspNetFile photoItem in new LSFProjectContext().AspNetFiles.Where(f => f.Photo))
            {
                resultHtmlList += $"<li class=\"select__item\"><div style=\"display: flex;\"><img src=\"{photoItem.Path}\" height = \"50\" width = \"50\"/><h4 style = \"margin-left: 50px;\">{@photoItem.Title}</h4></div></li>";
            }
            return Content(resultHtmlList);
        }
    }
}
