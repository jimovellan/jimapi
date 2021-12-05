using AutoMapper;
using jim.api.services.inter;
using jim.common.Exceptions;
using jim.models.Dto.User;
using jim.models.Entity.Common;
using jim.models.Entity.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jim.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,
                              ILogger<UserController> log,
                              IMapper mapper)
        {
            _userService = userService;
            _log = log;
            _mapper = mapper;

        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<CustomResponse<IList<UserDto>>> Get()
        {
            IList<UserDto> usersDto = new List<UserDto>();
            try
            {

                _log.LogTrace("Obteniendo todos los usuarios");
                var users = await _userService.GetAllUsersAsync();
                if (users != null)
                {
                    usersDto = _mapper.Map<IList<UserDto>>(users);
                }
                return CustomResponse.Ok(usersDto);
            }
            catch (Exception ex)
            {
                var msg = common.Errors.Common.GenericError();
                _log.LogError(ex, msg);
                return CustomResponse.Fail<IList<UserDto>>(msg);


            }

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<CustomResponse<User>> Get(string id)
        {

            try
            {
                _log.LogTrace("Obteniendo usuario por id {0}", id);
                var user = await _userService.GetUserAsync(id);
                return CustomResponse.Ok(user);
            }
            catch (CustomException ex)
            {
                _log.LogError(ex, ex.Message);
                return CustomResponse.Fail<User>(ex.Message);

            }
            catch (Exception ex)
            {
                var msg = common.Errors.Common.GenericError();
                _log.LogError(ex, msg);
                return CustomResponse.Fail<User>(ex.Message);


            }


        }


    }
}
