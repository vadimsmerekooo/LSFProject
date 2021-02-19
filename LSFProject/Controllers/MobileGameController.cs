using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LSFProject.Controllers
{
    public class MobileGameController : Controller
    {
        public ActionResult PostAspNetUsersActionResult()
        {
            try
            {
                if (Request.Form.Count == 0)
                    if (Request.Form["privatePassword"] != "GHGH*&^fvf544345GHG66$")
                        if (!Request.Form.ContainsKey("sqlRequest"))
                            if (!Request.Form["sqlRequest"].Contains("AspNetUsers"))
                            {
                                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                                    new ArgumentNullException("One of the required parameters is null or not valid!")));
                                return Content("Error Access on file return object. File Clear!");
                            }
            }
            catch (Exception exception)
            {
                EncryptJsonRequestFile(JsonConvert.SerializeObject(
                        new ArgumentNullException("One of the required parameters is null or not valid!")));
                return Content(
                    new ArgumentNullException("One of the required parameters is null or not valid!").Message);
            }


            using (LSFProjectContext _context = new LSFProjectContext())
            {
                IQueryable<AspNetUser> user = _context.AspNetUsers.FromSqlRaw(Request.Form["sqlRequest"]);
                string jsSerializeObject = JsonConvert.SerializeObject(user);

                EncryptJsonRequestFile(jsSerializeObject);

                return Content("Seccessful request post!");
            }

            return Content("Why Not??? ");

        }

        public void GetClearJsonRequestFile() => System.IO.File.WriteAllText(Config.OpenJsonFileDataBase, "");



        void EncryptJsonRequestFile(string jsSerializeObject)
        {
            RSAParameters rsaOpenKey = new RSAParameters();
            XmlSerializer formatter = new XmlSerializer(typeof(RSAParameters));

            string inputFile = Config.OpenJsonFileDataBase;
            string outputFile = Config.PrivateJsonFileDataBase;

            using (FileStream fsOpenFileStream = new FileStream(Config.RSAOpenKey, FileMode.Open))
            {
                rsaOpenKey = (RSAParameters)formatter.Deserialize(fsOpenFileStream);
            }

            System.IO.File.WriteAllText(inputFile, jsSerializeObject);


            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaOpenKey);

                using (var fstreamIn = new FileStream(inputFile, FileMode.OpenOrCreate, FileAccess.Read))
                using (var fstreamOut = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write))
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

                GetClearJsonRequestFile();
            }
        }
    }
}
