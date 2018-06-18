using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PO_Messenger.Models;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace PO_Messenger.Controllers
{
    public class LoguserController : Controller
    {
        // GET: Loguser
        public ActionResult UserMain()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(Email email_obj)
        {

            FileOperationWritter(email_obj);
            return View("MessageSent");
        }

        public ActionResult CheckHistory()
        {

            FileOperationReader();
            return View();
        }

        public void FileOperationWritter(Email email_obj)
        {
            string name = (String)Session["userName"];
            FileStream fs = new FileStream("C:\\Users\\wkret\\source\\repos\\PO_Messenger\\PO_Messenger\\Uzytkownicy\\"+name+".txt",
               FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(email_obj.Contents);
            sw.WriteLine(email_obj.RecipientEmial);
            sw.WriteLine(email_obj.MessageType);
            sw.Close();
        }
        public void FileOperationReader()
        {
            string name = (String)Session["userName"];

            try
            {
                FileStream fs = new FileStream("C:\\Users\\wkret\\source\\repos\\PO_Messenger\\PO_Messenger\\Uzytkownicy\\" + name + ".txt",
                    FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string DataFromFile = sr.ReadToEnd();
                sr.Close();

                ViewBag.FileData = DataFromFile;
            }
            catch(Exception ex)
            {
                ViewBag.FileData = ex.ToString();
            }

        }
    }
}