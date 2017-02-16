﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShipmentsAPI.Controllers
{
    [Authorize]
    public class ShipmentsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}