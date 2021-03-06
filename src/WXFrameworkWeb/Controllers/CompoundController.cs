﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WXFrameworkWeb.Controllers
{
    public class CompoundController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetMol()
        {

            string mol =
@"
ChemJSDraw11250914282D

 11 12  0  0  0  0  0  0  0  0  1 V2000
   15.6000   -9.3600    0.0000 N   0  0
   14.2490   -8.5800    0.0000 C   0  0
   14.2490   -7.0200    0.0000 C   0  0
   15.6000   -6.2400    0.0000 C   0  0
   16.9510   -7.0200    0.0000 C   0  0
   16.9510   -8.5800    0.0000 C   0  0
   18.3020   -6.2400    0.0000 O   0  0
   12.8980   -9.3600    0.0000 C   0  0
   11.5470   -8.5800    0.0000 C   0  0
   11.5470   -7.0200    0.0000 C   0  0
   12.8980   -6.2400    0.0000 C   0  0
  1  2  1  0
  2  3  2  0
  3  4  1  0
  4  5  2  0
  5  6  1  0
  6  1  2  0
  5  7  1  0
  8  2  1  0
  8  9  2  0
  9 10  1  0
 10 11  2  0
 11  3  1  0
M  END";
             return new HttpResponseMessage()
            {
                Content = new StringContent(mol)
            };
        }
    }
}
