using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NPoco;
using Ninject;

using ArchLib;
using ArchBll.Model;

namespace ArchBll.Repository
{
    public class A2Repository
    {

        private Database _db;

        public A2Repository([Named("App")]Database db)
        {
            _db = db;
        }

        public List<CompoundInfo> GetCompoundList()
        {
            string sql = @"SELECT 
top 10
[id]
      
      ,[COMPOUND_ID]
      ,[Structure]
      ,[Structure__mol]
      ,[jdecode]

      ,[Compound_Description]
  FROM [dbo].[CompoundLibrary]
  order by id desc ";
            return _db.Fetch<CompoundInfo>(sql);

        }

        public JsonPager<CompoundInfo> PageComoundList(CompoundQInfo qInfo)
        {
            Sql sql = new Sql("select  * from  [dbo].[CompoundLibrary] where 1 = 1  ");
            Page<CompoundInfo> pagedata = _db.Page<CompoundInfo>(qInfo.Page, qInfo.ItemsPerPage, sql);
            JsonPager<CompoundInfo> ret = new JsonPager<CompoundInfo>();
            ret.result = pagedata.Items;
            ret.total = pagedata.TotalItems;
            return ret;

        }


        public string GetMsg()
        {
            return "hello world2";
        }
    }
}
