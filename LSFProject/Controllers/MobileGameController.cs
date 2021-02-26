using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
                if (!System.IO.File.Exists(Config.OpenJsonFileDataBase))
                    System.IO.File.Create(Config.OpenJsonFileDataBase);
                if (!System.IO.File.Exists(Config.PrivateJsonFileDataBase))
                    System.IO.File.Create(Config.PrivateJsonFileDataBase);
                if (!System.IO.File.Exists(Config.FTPServerPathFolder))
                    System.IO.File.Create(Config.FTPServerPathFolder);
                return Content(Path.GetFullPath(Config.OpenJsonFileDataBase) + "\n" + Path.GetFullPath(Config.PrivateJsonFileDataBase) + "\n" + Path.GetFullPath(Config.FTPServerPathFolder));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewOpenFile()
        {
            try
            {
                return Content(Path.GetFullPath(Config.OpenJsonFileDataBase) + System.IO.File.ReadAllText(Config.OpenJsonFileDataBase));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewPrivateFile()
        {
            try
            {
                return Content(Path.GetFullPath(Config.PrivateJsonFileDataBase) + System.IO.File.ReadAllText(Config.PrivateJsonFileDataBase));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewSqlFile()
        {
            try
            {
                return Content(Path.GetFullPath(Config.FTPServerPathFolder) + System.IO.File.ReadAllText(Config.FTPServerPathFolder));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewRsaFile()
        {
            try
            {
                return Content(Path.GetFullPath(Config.RSAOpenKey) + System.IO.File.ReadAllText(Config.RSAOpenKey));
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
            catch (Exception)
            {
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
                if (users != null && await _userManager.CheckPasswordAsync(users, Request.Form["password"]))
                {
                    IQueryable<AspNetUser> user = new LSFProjectContext().AspNetUsers.Where(u => u.Email == Request.Form["login"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(user);

                    EncryptJsonRequestFile(jsSerializeObject);
                    return Content("Seccessful request post!");
                }
                else
                {
                    EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException()));
                    return Content(
                        new ArgumentNullException().Message);
                }
            }
            catch (Exception)
            {
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
                if (Request.Form["sqlRequest"].Contains("SELECT"))
                {
                    IQueryable<AspNetFavTarget> favTargets =
                        new LSFProjectContext().AspNetFavTargets.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(favTargets);
                    EncryptJsonRequestFile(jsSerializeObject);
                }
                else
                {
                    _context.Database.ExecuteSqlRaw((Request.Form["sqlRequest"]));
                }

                return Content("Seccessful request post!");
            }
            catch (Exception)
            {
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
                if (Request.Form["sqlRequest"].Contains("SELECT"))
                {

                    IQueryable<AspNetTarget> traficRules = new LSFProjectContext().AspNetTargets.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(traficRules);

                    EncryptJsonRequestFile(jsSerializeObject);
                }
                else
                {
                    _context.Database.ExecuteSqlRaw((Request.Form["sqlRequest"]));
                }

                return Content("Seccessful request post!");
            }
            catch (Exception)
            {
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
                if (Request.Form["sqlRequest"].Contains("SELECT"))
                {
                    IQueryable<AspNetTraficRule> traficRules = new LSFProjectContext().AspNetTraficRules.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(traficRules);

                    EncryptJsonRequestFile(jsSerializeObject);
                }
                else
                {
                    new LSFProjectContext().Database.ExecuteSqlRaw(Request.Form["sqlRequest"]);
                    _context.SaveChanges();
                }

                return Content("Seccessful request post!");
            }
            catch (Exception)
            {
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

                if (Request.Form["sqlRequest"].Contains("SELECT"))
                {
                    IQueryable<AspNetIcon> icons =
                        new LSFProjectContext().AspNetIcons.FromSqlRaw(Request.Form["sqlRequest"]);
                    string jsSerializeObject = JsonConvert.SerializeObject(icons);

                    EncryptJsonRequestFile(jsSerializeObject);
                }

                return Content("Seccessful request post!");
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        void GetClearJsonRequestFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(Config.OpenJsonFileDataBase),
                    FileMode.OpenOrCreate))
                {
                    fs.SetLength(0);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        void GetClearFtpRequestFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Path.GetFullPath(Config.FTPServerPathFolder), FileMode.OpenOrCreate))
                {
                    fs.SetLength(0);
                }
            }
            catch(Exception)
            {
                // ignored
            }
        }

        void EncryptJsonRequestFile(string jsSerializeObject)
        {
            try
            {
                RSAParameters rsaOpenKey = new RSAParameters()
                {
                    Exponent = new byte[] { 1, 0, 1 },
                    Modulus = new byte[] { 189, 133, 53, 70, 41, 110, 70, 187, 198, 155, 255, 133, 142, 51, 215, 223, 239, 142, 80, 95, 189, 35, 15, 34, 143, 232, 218, 128, 73, 19, 142, 178, 33, 211, 126, 140, 41, 178, 17, 172, 236, 175, 255, 40, 239, 244, 15, 25, 179, 106, 7, 179, 168, 176, 138, 118, 107, 5, 42, 120, 80, 96, 45, 210, 246, 12, 165, 31, 219, 190, 219, 215, 45, 163, 189, 206, 73, 202, 79, 197, 246, 154, 167, 155, 203, 84, 166, 72, 138, 90, 210, 100, 72, 237, 28, 16, 153, 205, 207, 172, 204, 245, 218, 176, 151, 152, 238, 31, 9, 69, 64, 110, 231, 3, 71, 94, 55, 62, 56, 72, 79, 33, 233, 81, 117, 226, 191, 217 }
                };

                using (FileStream sw = new FileStream(Config.OpenJsonFileDataBase, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    sw.Write(Encoding.ASCII.GetBytes(jsSerializeObject));
                }


                using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(rsaOpenKey);

                using (var fstreamIn = new FileStream(Config.OpenJsonFileDataBase, FileMode.OpenOrCreate, FileAccess.Read))
                using (var fstreamOut = new FileStream(Config.PrivateJsonFileDataBase, FileMode.OpenOrCreate, FileAccess.Write))
                {

                    byte[] buf = new byte[64];
                    for (; ; )
                    {
                        int bytesRead = fstreamIn.Read(buf, 0, buf.Length);
                        if (bytesRead == 0) break;
                        byte[] encrypted = bytesRead == buf.Length ? rsa.Encrypt(buf, true) : rsa.Encrypt(buf.Take(bytesRead).ToArray(), true);
                        fstreamOut.Write(encrypted, 0, encrypted.Length);
                    }
                }
                rsa.Dispose();
                string content;
                if (Request.Form.ContainsKey("login"))
                    content = Request.Form["login"] + "," + Request.Form["timeRequest"];
                else
                    content = Request.Form["sqlRequest"] + "," + Request.Form["timeRequest"];


                GetClearFtpRequestFile();
                System.IO.File.WriteAllText(Config.FTPServerPathFolder, content, Encoding.UTF8);
                GetClearJsonRequestFile();

            }
            catch (Exception e)
            {
                GetClearFtpRequestFile();
                System.IO.File.WriteAllText(Config.FTPServerPathFolder, e.Message);
            }
        }

    }
}

