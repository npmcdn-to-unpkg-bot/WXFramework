using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WXFrameworkWeb.Ashx;

namespace WXFrameworkWeb.Controllers
{
    public class UploadController : ApiController
    {


        public HttpResponseMessage PostFile()
        {
            //TODO:upload error handle
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/TempFiles/" + Path.GetFileName(postedFile.FileName));
                    postedFile.SaveAs(filePath);

                    try
                    {

                        docfiles.Add(filePath);
                    }
                    catch (Exception ex)
                    {

                        result = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }
                    finally
                    {
                        File.Delete(filePath);
                    }


                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        private bool IsImage(string ext)
        {
            return ext == ".gif" || ext == ".jpg" || ext == ".png";
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
        public HttpResponseMessage PostFileNew()
        {
            //TODO:upload error handle
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                //var docfiles = new List<string>();
                //foreach (string file in httpRequest.Files)
                //string file = httpRequest.Files[0];
                //{
                var postedFile = httpRequest.Files[0];
                var filePath = HttpContext.Current.Server.MapPath("~/TempFiles/" + Path.GetFileName(postedFile.FileName));
                postedFile.SaveAs(filePath);

                /*
                try
                {

                    docfiles.Add(filePath);
                }
                catch (Exception ex)
                {

                    result = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
               */


                //}
                FilesStatus f = new FilesStatus();
                f.name = postedFile.FileName;
                f.url = "api/upload/" + postedFile.FileName;
                f.thumbnail_url = @"data:image/png;base64," + EncodeFile(filePath);
                result = Request.CreateResponse(HttpStatusCode.Created, f);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        public HttpResponseMessage PostSimpleFile()
        {
            //TODO:upload error handle
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/TempFiles/" + Path.GetFileName(postedFile.FileName));
                    postedFile.SaveAs(filePath);

                    try
                    {

                        //docfiles.Add(filePath);
                        string msg = "导入了1000条数据";
                        docfiles.Add(msg);
                    }
                    catch (Exception ex)
                    {

                        result = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }
                    finally
                    {
                        File.Delete(filePath);
                    }


                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}