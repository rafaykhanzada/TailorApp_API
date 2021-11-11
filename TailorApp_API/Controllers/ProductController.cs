﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorApp_API.Helpers;
using TailorApp_API.Repository;

namespace TailorApp_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [Route("allproducts")]
        public ResponseHelper GetAllProduct()
        {
            var data = _productRepository.GetAll();
            return new ResponseHelper(1, data, new ErrorDef());
        }
    }
}