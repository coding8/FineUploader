using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUploader.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase qqfile)//qqfile是个固定的名称！
        {
            if (qqfile != null && qqfile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(qqfile.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                try
                {
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    qqfile.SaveAs(path);
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, error = ex.Message }, "text/html");
                }
            }
            //qqfile.SaveAs(Server.MapPath("~/Upload/") + qqfile.FileName);
            //var filename = Path.Combine(Server.MapPath("~/App_Data"), qqfile.FileName);
            //qqfile.SaveAs(filename);
            //返回的json要写success=true，告诉fineuploader操作成功了。
            //http://stackoverflow.com/questions/16742116/fine-uploader-server-side-code-saves-uploaded-file-but-client-displays-upload
            return Json(new { success = true, name = qqfile.FileName }, "text/html");
        }
        public ActionResult Test()
        {
            return Content("hello world");
        }
    }
}