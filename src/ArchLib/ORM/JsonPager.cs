using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NPoco;

namespace ArchLib
{
    public class JsonPager<T>
    {
        public List<T> result { get; set; }
        public long total { get; set; }

        public static JsonPager<T> ConverFrom(Page<T> pageData)
        {
            var ret = new JsonPager<T>();
            ret.result = pageData.Items;
            ret.total = pageData.TotalItems;
            return ret;
        }
    }
}
