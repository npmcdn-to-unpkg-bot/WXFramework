﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WXFrameworkWeb.Controllers
{
    public class FileController : ApiController
    {

        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\TempFiles\";

        /// <summary>
        ///   Get all photos
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            /*
            var photos = new List<PhotoViewModel>();

            var photoFolder = new DirectoryInfo(workingFolder);

            await Task.Factory.StartNew(() =>
            {
                photos = photoFolder.EnumerateFiles()
                  .Where(fi => new[] { ".jpg", ".bmp", ".png", ".gif", ".tiff" }
                    .Contains(fi.Extension.ToLower()))
                  .Select(fi => new PhotoViewModel
                  {
                      Name = fi.Name,
                      Created = fi.CreationTime,
                      Modified = fi.LastWriteTime,
                      Size = fi.Length / 1024
                  })
                  .ToList();
            });
            
            return Ok(new { Photos = photos });
             */
            return Ok();
        }

         [HttpGet]
        public string Get(string fileName)
        {
            return "value";
        }

       [HttpGet]
        public void Delete(string fileName)
        {
            var filePath = Directory.GetFiles(workingFolder, fileName)
        .FirstOrDefault();
            File.Delete(filePath);
        }
        /// <summary>
        ///   Delete photo
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
      
        //public async Task<IHttpActionResult> Delete(string fileName)
        //{
        //    if (!FileExists(fileName))
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        var filePath = Directory.GetFiles(workingFolder, fileName)
        //          .FirstOrDefault();

        //        await Task.Factory.StartNew(() =>
        //        {
        //            if (filePath != null)
        //                File.Delete(filePath);
        //        });
        //        /*
        //        var result = new PhotoActionResult
        //        {
        //            Successful = true,
        //            Message = fileName + "deleted successfully"
        //        };
        //        return Ok(new { message = result.Message });
        //         */
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        /*
        //        var result = new PhotoActionResult
        //        {
        //            Successful = false,
        //            Message = "error deleting fileName " + ex.GetBaseException().Message
        //        };
        //         */
        //        return BadRequest(ex.GetBaseException().Message);
        //    }
        //}

        /// <summary>
        ///   Add a photo
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Add()
        {
            /*
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }
            try
            {
                var provider = new CustomMultipartFormDataStreamProvider(workingFolder);

                await Request.Content.ReadAsMultipartAsync(provider);

                var photos =
                  provider.FileData
                    .Select(file => new FileInfo(file.LocalFileName))
                    .Select(fileInfo => new PhotoViewModel
                    {
                        Name = fileInfo.Name,
                        Created = fileInfo.CreationTime,
                        Modified = fileInfo.LastWriteTime,
                        Size = fileInfo.Length / 1024
                    }).ToList();
                return Ok(new { Message = "Photos uploaded ok", Photos = photos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
             */
            return Ok();
        }

        /// <summary>
        ///   Check if file exists on disk
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool FileExists(string fileName)
        {
            var file = Directory.GetFiles(workingFolder, fileName)
              .FirstOrDefault();

            return file != null;
        }

        /*
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

        / DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
         */
    }
}