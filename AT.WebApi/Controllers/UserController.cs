using System.Collections.Generic;
using System.Linq;
using AT.IDataAccess.IRepository;
using AT.Model.Common;
using AT.Model.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AT.WebApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return Ok(_userRepository.GetAll().Select(_mapper.Map<User, UserDto>));
        }

        [HttpGet("Id")]
        public ActionResult<UserDto> GetById(int id)
        {
            if (id <= 0) return BadRequest();

            return Ok(_mapper.Map<User, UserDto>(_userRepository.GetById(id)));
        }

        [HttpPost]
        public ActionResult<UserDto> Post(UserDto user)
        {
            var result = _userRepository.Create(_mapper.Map<UserDto, User>(user));
            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<User, UserDto>(result));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _userRepository.Delete(id);
            return result ? (ActionResult) Ok() : NotFound();
        }

        [HttpPut]
        public ActionResult Put(UserDto user)
        {
            //Update action
            var result = _userRepository.Update(_mapper.Map<UserDto,User>(user));

            return result == null ? (ActionResult)NotFound() : Ok(result);
        }

    }
}