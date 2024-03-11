using System.Net;
using AutoMapper;
using be_aspnet_demo.models.user;
using Microsoft.AspNetCore.Mvc;
using be_aspnet_demo.models.exceptions;
using be_aspnet_demo.models.paging;
using be_aspnet_demo.models.user.dto;
using be_aspnet_demo.models.user.form;

namespace be_aspnet_demo.controllers
{
    public class UsersController : BaseController
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserQueryForm queries)
        {
            var userQueries = _mapper.Map<UserQuery>(queries);
            var response = await _userService.GetAllAsync(userQueries);
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var maybeUser = await _userService.FindById(id);
            if (maybeUser == null)
            {
                return Handle(new EntityNotFound(id.ToString()));
            }

            return Ok(maybeUser);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDTO model)
        {
            var result = await _userService.AddAsync(model);

            return Ok(result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UserDTO userDto)
        {
            bool result;
            
            Console.WriteLine(userDto.ToString());
            
            var user = _mapper.Map<User>(userDto);

            try
            {
                result = await _userService.Update(id, user);
            }
            catch (Exception e)
            {
                return Handle(e);
            }

            return Ok(result);
        }
        
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool result;
            try
            {
                result = await _userService.Delete(id);
            }
            catch (Exception e)
            {
                return Handle(e);
            }

            return Ok(result);
        }
    }
}