using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

using NPoco;

using ArchLib;

namespace ArchLib
{
    public static class NPocoExtend
    {
        
        public static JsonPager<T> NGTablePage<T>(this Database database, long page, long itemsPerPage, Sql sql)
        {
            var pageData = database.Page<T>(page, itemsPerPage, sql);
            JsonPager<T> ret = new JsonPager<T>();
            ret.result = pageData.Items;
            ret.total = pageData.TotalItems;
            return ret;
        }

        public static Sql AddOrderBy(this Sql sql, string[] orderBys)
        {
            string sqlStr = " ORDER BY ";
            foreach (var orderBy in orderBys)
            {
                string orderByField = orderBy.Substring(1, orderBy.Length - 1);
                string orderByParam = orderBy.Substring(0, 1) == "+" ? " ASC " : " DESC ";
                sqlStr += string.Format(" {0} {1},", orderByField, orderByParam);
            }
            sqlStr = sqlStr.Substring(0, sqlStr.Length - 2);
            sql.Append(sqlStr);
            return sql;
        }

        public static DataTable QueryDataTale(this Database database, string sql, params object[] args)
        {
            DataTable dt = new DataTable();
            database.OpenSharedConnection();
            try
            {
                using (var cmd = database.CreateCommand(database.Connection, sql, args))
                {
                    IDataReader r;
                    try
                    {
                        r = cmd.ExecuteReader();
                        dt.Load(r);
                        //OnExecutedCommand(cmd);
                    }
                    catch (Exception x)
                    {
                        //OnException(x);
                        throw;
                    }

                }
            }
            finally
            {
                database.CloseSharedConnection();
            }
            return dt;
        }
    }
}
