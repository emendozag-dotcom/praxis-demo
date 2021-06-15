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
    public class ProductTypeController : ControllerBase
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypeController(IRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductTypeDto>> GetAll()
        {
            return Ok(_productTypeRepository.GetAll().Select(_mapper.Map<ProductType,ProductTypeDto>));
        }

        [HttpGet("Id")]
        public ActionResult<ProductTypeDto> GetById(int id)
        {
            if (id <= 0) return BadRequest();

            return Ok(_mapper.Map<ProductType, ProductTypeDto>(_productTypeRepository.GetById(id)));

        }

        [HttpPost]
        public ActionResult<ProductTypeDto> Post(ProductTypeDto productType)
        {
            var result = _productTypeRepository.Create(_mapper.Map<ProductTypeDto, ProductType>(productType));
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<ProductType, ProductTypeDto>(result));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _productTypeRepository.Delete(id);
            return result ? (ActionResult)Ok() : NotFound();
        }

        [HttpPut]
        public ActionResult<ProductTypeDto> Put(ProductTypeDto productType)
        {
            //Update action
            var result = _productTypeRepository.Update(_mapper.Map<ProductTypeDto, ProductType>(productType));

            return result == null ? (ActionResult)NotFound() : Ok(_mapper.Map < ProductType, ProductTypeDto > (result));
        }
    }
}
