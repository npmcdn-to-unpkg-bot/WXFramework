using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NPoco;

using ArchLib;
using ArchBll.Model;
using ArchBll.Repository;
using ArchBll.Session;


namespace ResourceUtilWeb.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserRepository _us;

        private readonly ExcelMappingUtil _mp;

        private readonly SessionManager _sm;
        public UserController(UserRepository us, SessionManager sm, ExcelMappingUtil mp)
        {
            _us = us;
            _mp = mp;
            _sm = sm;
        }
        public JsonPager<Employee> PageUser(EmployeeQryInfo qInfo)
        {
            var ret = _us.PageUser(qInfo);
            return ret;
        }

        [HttpGet]
        public List<Employee> SearchUser(string searchText)
        {


            return _us.SearchUser(searchText);
        }

        [HttpPost]
        public HttpResponseMessage Export(EmployeeQryInfo qInfo)
        {


            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var ret = _us.ListUser(qInfo);
            //ExcelMappingUtil mp = new ExcelMappingUtil();
            string fileName = _mp.ExportToFile<Employee>(ret);

            return new HttpResponseMessage()
            {
                Content = new StringContent(fileName)
            };
        }


        [HttpGet]
        public void ShowError()
        {
            throw new ApplicationException("remote message");
        }



        [HttpGet]
        public void ChangeRole(string roleID)
        {
            _sm.UserInfo.RoleID = roleID;
        }
    }
}
