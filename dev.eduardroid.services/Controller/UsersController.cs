using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dev.eduardroid.services.Data;
using dev.eduardroid.services.Data.Entities;
using dev.eduardroid.services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dev.eduardroid.services.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IServiceRepository _repository;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;

        public UsersController(
              IServiceRepository repository
            , ILogger<UsersController> logger
            , IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_repository.GetAllUsers()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Failed to get users");
            }
            
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetById(Int32 id)
        {
            try
            {
                var user = _repository.GetUserById(id);

                if (user != null)
                    return Ok(_mapper.Map<User,UserViewModel>(user));
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Failed to get users");
            }
        }

        [HttpPost]
        //[ProducesResponseType(201)]
        //[ProducesResponseType(400)]
        public IActionResult Post([FromBody]UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = _mapper.Map<UserViewModel, User>(model);

                    _repository.AddEntity(newUser);

                    if (_repository.SaveAll())
                        return Created($"/api/orders/{newUser.Id}", _mapper.Map<User, UserViewModel>(newUser));
                    else
                        return BadRequest("Failed to save user");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Failed to save users");
            }
        }
    }
}
