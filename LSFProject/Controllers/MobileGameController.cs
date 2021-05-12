using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LSFProject.Controllers
{
    public class MobileGameController : Controller
    {
        private UserManager<LSFUser> _userManager;
        private LSFProjectContext _context = new LSFProjectContext();
        public MobileGameController(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Folder(string path)
        {
            string key = string.Empty;
            foreach (var item in Directory.GetDirectories(path))
            {
                key += item + "\n";
            }
            foreach (var item in Directory.GetFiles(path))
            {
                key += item + "\n";
            }
            return Content(key);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateFiles()
        {
            try
            {
                if (!System.IO.File.Exists(Config.PrivateJsonFileDataBase))
                    System.IO.File.Create(Config.PrivateJsonFileDataBase);
                if (!System.IO.File.Exists(Config.FTPServerPathFolder))
                    System.IO.File.Create(Config.FTPServerPathFolder);
                return Content(Path.GetFullPath(Config.PrivateJsonFileDataBase) + "\n" + Path.GetFullPath(Config.FTPServerPathFolder));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFile(string path = "")
        {
            try
            {
                if (System.IO.File.Exists("wwwroot/" + path))
                {
                    System.IO.File.Delete("wwwroot/" + path);
                    return Content(path + " удален");
                }
                else
                    return Content(path + " не найден");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult PostAspNetUsersActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }

                if (!Request.Form.ContainsKey("sqlRequest"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                IQueryable<AspNetUser> user = _context.AspNetUsers.FromSqlRaw(Request.Form["sqlRequest"]);
                _context.SaveChanges();
                string jsSerializeObject = JsonConvert.SerializeObject(user);

                EncryptJsonRequestFile(jsSerializeObject);
                return Content("Seccessful request post!");
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }

        }

        public async Task<IActionResult> PostUserSignInActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (!Request.Form.ContainsKey("password"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (!Request.Form.ContainsKey("login"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                var users = await _userManager.FindByNameAsync(Request.Form["login"]);
                if (users != null && await _userManager.CheckPasswordAsync(users, Request.Form["password"] + "!"))
                {
                    EncryptJsonRequestFile("true");
                    _context.AspNetUsers.FirstOrDefault(u => u.UserName == Request.Form["login"]).LastEntry = DateTime.Now;
                    return Content("Seccessful request post!");
                }
                else
                {
                    EncryptJsonRequestFile("false");
                    return Content(
                        new ArgumentNullException().Message);
                }
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }
        }

        public ActionResult PostAspNetFavTargetsActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }

                if (!Request.Form.ContainsKey("sqlRequest"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                if (Request.Form["sqlRequest"][0].Contains("SELECT"))
                {
                    IQueryable<AspNetFavTarget> favTargets = _context.AspNetFavTargets.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(favTargets);
                    EncryptJsonRequestFile(jsSerializeObject);
                }
                else
                {
                    _context.Database.ExecuteSqlRaw((Request.Form["sqlRequest"]));
                }

                return Content("Seccessful request post!");
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }

        }

        public ActionResult PostAspNetTargetsActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }

                if (!Request.Form.ContainsKey("sqlRequest"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                if (Request.Form["sqlRequest"][0].Contains("SELECT"))
                {
                    var traficRules = _context.AspNetTargets.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(traficRules);

                    EncryptJsonRequestFile(jsSerializeObject);
                }
                else
                {
                    _context.Database.ExecuteSqlRaw(Request.Form["sqlRequest"]);
                }

                return Content("Seccessful request post!");
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }

        }

        public ActionResult PostAspNetTraficRulesActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }

                if (!Request.Form.ContainsKey("sqlRequest"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                if (Request.Form["sqlRequest"][0].Contains("SELECT"))
                {
                    IQueryable<AspNetTraficRule> traficRules = new LSFProjectContext().AspNetTraficRules.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(traficRules);

                    EncryptJsonRequestFile(jsSerializeObject);
                }
                else
                {
                    new LSFProjectContext().Database.ExecuteSqlRaw(Request.Form["sqlRequest"]);
                }

                return Content("Seccessful request post!");
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }

        }
        
        public ActionResult PostAspNetIconsActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }

                if (!Request.Form.ContainsKey("sqlRequest"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                if (Request.Form["sqlRequest"][0].Contains("SELECT"))
                {
                    IQueryable<AspNetIcon> icons = _context.AspNetIcons.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(icons);

                    EncryptJsonRequestFile(jsSerializeObject);
                }
                else
                {
                    _context.Database.ExecuteSqlRaw(Request.Form["sqlRequest"]);
                }

                return Content("Seccessful request post!");
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }

        }



        public ActionResult PostAspNetFilesActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }

                if (!Request.Form.ContainsKey("sqlRequest"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                if (Request.Form["sqlRequest"][0].Contains("SELECT"))
                {
                    IQueryable<AspNetFile> files = _context.AspNetFiles.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(files);

                    EncryptJsonRequestFile(jsSerializeObject);
                }

                return Content("Seccessful request post!");
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }

        }

        void EncryptJsonRequestFile(string jsSerializeObject)
        {
            try
            {
                CreateFiles();
                System.IO.File.WriteAllText(Config.PrivateJsonFileDataBase, jsSerializeObject);
                System.IO.File.WriteAllText(Config.PrivateJsonFileDataBase, EncodeTo64(jsSerializeObject));
                
                string content;
                if (Request.Form.ContainsKey("login"))
                    content = Request.Form["login"] + "," + Request.Form["timeRequest"];
                else
                    content = Request.Form["sqlRequest"] + "," + Request.Form["timeRequest"];

                
                System.IO.File.WriteAllText(Config.FTPServerPathFolder, content, Encoding.Default);
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(Config.FTPServerPathFolder, ex.Message);
            }
        }
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                = System.Text.Encoding.UTF8.GetBytes(toEncode);
            string returnValue
                = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }






        public ActionResult PostMiddleFingerActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
                if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }

                if (!Request.Form.ContainsKey("sqlRequest"))
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content("Error Access on file return object. File Clear!");
                }
            }
            catch (Exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    new ArgumentNullException()));
                return Content(
                    new ArgumentNullException().Message);
            }

            try
            {
                if (Request.Form["sqlRequest"][0].Contains("SELECT"))
                {
                    IQueryable<MiddleFinger> files = _context.MiddleFinger.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(files);

                    EncryptJsonRequestFile(jsSerializeObject);
                }

                return Content("Seccessful request post!");
            }
            catch (Exception ex)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                    ex.Message));
                return NotFound();
            }

        }
    }
}

