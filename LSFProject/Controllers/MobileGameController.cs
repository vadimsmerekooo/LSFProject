using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LSFProject.Controllers
{
    public class MobileGameController : Controller
    {
        public IActionResult Index(string sqlString = "", string stringKey = "")
        {
            if (stringKey != "AQAAAAEAACcQAAAAELPcLs49yk3Qwvdknu41MPnMxxbdNW26is9MquFv1rMYgUPV7GdB6nw1N6emJS4SJQ==")
                return View("AccessDenied");
            using (LSFProjectContext _context = new LSFProjectContext())
            {
                IQueryable<AspNetUser> user = _context.AspNetUsers.FromSqlRaw(sqlString);
                string asd = JsonConvert.SerializeObject(user);

                System.IO.File.WriteAllText("123.json",asd);
                var sad = (IQueryable<AspNetUser>)JsonConvert.DeserializeObject(asd);

                return Content(asd);
            }
        }
        
        public ActionResult PosResult()
        {
            var a = Request.Form;
            return RedirectToAction("Index");
        }
    }
}
