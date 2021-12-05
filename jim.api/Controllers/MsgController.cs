using AutoMapper;
using jim.api.services.inter;
using jim.api.Services.inter;
using jim.common.Exceptions;
using jim.models.Dto.Msg;
using jim.models.Entity.Common;
using jim.models.Entity.Msgs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jim.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgController : ControllerBase
    {
        private readonly IMessageService _msgService;
        private readonly ILogger _log;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MsgController(IMessageService msgService,
                             ILogger<MsgController> log,
                             IUserService userService,
                             IMapper mapper)
        {
            _msgService = msgService;
            _log = log;
            _userService = userService;
            _mapper = mapper;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<CustomResponse> Post([FromBody] CreateMsgDto msgDto)
        {
            try
            {
                _log.LogTrace("Recibido mensage");
                var msg = Msg.Create(msgDto.Body);
                await _msgService.AddMessageAsync(msg);
                return CustomResponse.Ok();
            }
            catch (CustomException ex)
            {
                _log.LogError(ex, ex.Message);
                return CustomResponse.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                var msgError = common.Errors.Common.GenericError();
                _log.LogError(ex, msgError);
                return CustomResponse.Fail(msgError);

            }


        }

        // PUT api/<ValuesController>/5
        [HttpPut("{userId}")]
        public async Task<CustomResponse> Put(string userId, [FromBody] CreateMsgDto msgDto)
        {
            _log.LogDebug("Receiving msg to user {0}", userId);
            try
            {

                var msg = Msg.Create(msgDto.Body, userId);
                await _msgService.AddMessageAsync(msg);
                return CustomResponse.Ok();
            }
            catch (CustomException ex)
            {
                _log.LogError(ex, ex.Message);
                return CustomResponse.Fail(ex.Message);
            }
            catch (Exception ex)
            {

                var msgError = common.Errors.Common.GenericError();
                _log.LogError(ex, msgError);
                return CustomResponse.Fail(msgError);
            }
        }


    }
}
