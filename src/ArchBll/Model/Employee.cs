using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NPoco;

using ArchLib;

namespace ArchBll.Model
{


    public class Employee
    {
        [Title("工号")]
        public string Badge { get; set; }

        [Title("姓名")]
        public string UserName { get; set; }

        [Title("部门")]
        public string Department { get; set; }

        [Title("公司")]
        public string Company { get; set; }

    }

     public class EmployeeQryInfo
    {
      
        public string Badge { get; set; }

        public string UserName { get; set; }

        public string Department { get; set; }

        public string Company { get; set; }

        public long Page { get; set; }
            
        public long ItemsPerPage { get; set; }

        public string[] OrderBy { get; set; }


    }
}




