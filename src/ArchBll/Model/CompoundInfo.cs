using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NPoco;

namespace ArchBll.Model
{
    [TableName("CompoundInfo")]
    public class CompoundInfo
    {
        public int ID { get; set; }

        public string Compound_ID { get; set; }

        public string Structure { get; set; }

        public string Mol
        {
            get { return GetMol(Structure); }
            set { }
        }

        public string GetMol(string value)
        {

            return string.Format("\r\n -ISIS- \r\n\r\n{0}", value);


        }

    }

    public class CompoundQInfo
    {
        public string Compound_ID { get; set; }

        public long Page { get; set; }
            
        public long ItemsPerPage { get; set; }

    }
}
