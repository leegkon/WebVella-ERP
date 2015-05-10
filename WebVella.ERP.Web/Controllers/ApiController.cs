﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebVella.ERP.Api;
using WebVella.ERP.Api.Models;
using System.Net;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebVella.ERP.Web.Controllers
{
    public class ApiController : Controller
    {

        IERPService service;

        public ApiController(IERPService service)
        {
            this.service = service;
        }


        // Get all entity definitions
        // GET: api/v1/en_US/meta/entity/list/
        [AcceptVerbs(new[] { "GET" }, Route = "api/v1/en_US/meta/entity/list")]
        public IActionResult MetaEntitiesList()
        {
            EntityManager manager = new EntityManager(service.StorageService);
            EntityListResponse response = manager.ReadEntities();

            if (response.Errors.Count > 0)
                Context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return Json(response);
        }

        // Create an entity
        // POST: api/v1/en_US/meta/entity
        [AcceptVerbs(new[] { "POST" }, Route = "api/v1/en_US/meta/entity")]
        public IActionResult CreateEntity([FromBody]InputEntity submitObj)
        {
            EntityManager manager = new EntityManager(service.StorageService);
            EntityResponse response = manager.CreateEntity(submitObj);

            if (response.Errors.Count > 0)
                Context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return Json(response);
        }
    }
}