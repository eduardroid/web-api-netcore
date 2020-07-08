using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dev.eduardroid.services.Data;
using dev.eduardroid.services.Data.Entities;
using dev.eduardroid.services.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dev.eduardroid.services.Controller
{
    [Route("api/users/{userid}/navigationrights")]
    public class NavigationRightsController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ILogger<NavigationRightsController> _logger;
        private readonly IMapper _mapper;

        public NavigationRightsController(IServiceRepository serviceRepository
            , ILogger<NavigationRightsController> logger
            , IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int userId)
        {
            var user = _serviceRepository.GetUserById(userId);

            if (user != null)
            {
                return Ok(_mapper.Map<IEnumerable<NavigationRight>, IEnumerable<NavigationRightViewModel>>(user.Rights));
            }
            else {
                return NotFound();            
            }

            //return BadRequest("Failed to get navigationRights");
        }


        [HttpGet("{navigationRightId:int}")]
        public IActionResult Get(int userId,int navigationRightId)
        {
            var user = _serviceRepository.GetUserById(userId);

            if (user != null)
            {
                var navigationRight = user.Rights.Where(r => r.Id == navigationRightId).FirstOrDefault();

                if (navigationRight != null)
                    return Ok(_mapper.Map<NavigationRight, NavigationRightViewModel>(navigationRight));
                else
                    return NotFound("Right not found");

            }
            else
            {
                return NotFound("user not found");
            }
        }
    }
}