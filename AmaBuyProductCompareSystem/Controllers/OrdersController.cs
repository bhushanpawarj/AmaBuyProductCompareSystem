using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmaBuyProductCompareSystem.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;

namespace AmaBuyProductCompareSystem.Controllers {
    public class OrdersController : ApiController {


        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions) {

            
            IEnumerable<AmazonProduct> Products = null;
            var sql = "SELECT * FROM AmazonProducts";
            using (var db = new ProductsDataEntities()) {

                Products = db.Database.SqlQuery<AmazonProduct>(sql).ToList();
            }

            return Request.CreateResponse(DataSourceLoader.Load(Products, loadOptions));


        }

    }
}