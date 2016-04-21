using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;
using NPoco;

using ArchLib;
using ArchBll.Model;



namespace ArchBll.Repository
{
    public class UserRepository
    {
        private readonly Database _db;
        public UserRepository([Named("SSO")]Database db)
        {
            _db = db;
        }

        public JsonPager<Employee> PageUser(EmployeeQryInfo qInfo)
        {
            Sql sql = new Sql("select badge,name UserName,[compid] Company,[depcname] Department from [users] where status<>'Loff'");
            if (!string.IsNullOrEmpty(qInfo.UserName))
            {
                sql.Append(" and name like @0", "%" + qInfo.UserName + "%");

            }
            
            if (qInfo.OrderBy != null && qInfo.OrderBy.Length > 0)
            {
                sql.AddOrderBy(qInfo.OrderBy);
            };

            var pageData = _db.Page<Employee>(qInfo.Page, qInfo.ItemsPerPage, sql);

            JsonPager<Employee> ret = new JsonPager<Employee>();
            ret.result = pageData.Items;
            ret.total = pageData.TotalItems;
            return ret;
        }

        public List<Employee> ListUser(EmployeeQryInfo qInfo)
        {
            Sql sql = new Sql("select badge,name UserName,[compid] Company,[depcname] Department from [users] where status<>'Loff'");
            if (!string.IsNullOrEmpty(qInfo.UserName))
            {
                sql.Append(" and name like @0", "%" + qInfo.UserName + "%");

            }


            var pageData = _db.Page<Employee>(qInfo.Page, qInfo.ItemsPerPage, sql);
            return _db.Fetch<Employee>(sql);


        }


        public List<Employee> SearchUser(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return new List<Employee>();
            Sql sql = new Sql("select top 10 badge,name UserName,[compid] Company,[depcname] Department from [users] where status<>'Loff'");
            sql.Append(" and (name like @0 or badge like @0 or email like @0)" , searchText + "%");

            return _db.Fetch<Employee>(sql);

        }

 
    }
}
