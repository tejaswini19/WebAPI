
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HWCommonModel.Models;




namespace HWApi.Controllers
{
    public class HWController : ApiController
    {
        HWData hw = new HWData { data = "Hello World" };

        public IHttpActionResult Get()
        {
            return Ok(hw);
        }
    }
}
