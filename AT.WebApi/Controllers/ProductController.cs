using System.Collections.Generic;
using System.Linq;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using AT.Model.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            return Ok(_productRepository.GetAll().Select(_mapper.Map<Product, ProductDto>));
        }

        [HttpGet("Id")]
        public ActionResult<ProductDto> GetById(int id)
        {
            if (id <= 0) return BadRequest();
            
            return Ok(_mapper.Map<Product, ProductDto>(_productRepository.GetById(id)));

        }

        [HttpPost]
        public ActionResult<ProductDto> Post(ProductDto product)
        {
            var result = _productRepository.Create(_mapper.Map<ProductDto, Product>(product));
            if (result== null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<Product, ProductDto>(result));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _productRepository.Delete(id);
            return result ? (ActionResult) Ok() : NotFound();
        }

        [HttpPut]
        public ActionResult<ProductDto> Put(ProductDto product)
        {
            //Update action
            var result = _productRepository.Update(_mapper.Map<ProductDto, Product>(product));

            return result == null ? (ActionResult) NotFound() : Ok(_mapper.Map<Product, ProductDto>(result));
        }
    }
}
