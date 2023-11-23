using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Dal;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<GetUserDto>> GetUseryId(int id)
        {
            var list = new List<string>();
            try
            {
                var user =await _userService.getUserById(id);
                if (user == null)
                {
                    list.Add("Kullanıcı bulunamadı.");
                    return BadRequest(new { code = StatusCode(1001), message = list, type = "error" });
                }
                return Ok(user);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<string>> AddUser(AddUserDto userDto)
        {
            var list = new List<string>();
            try
            {
                var result =await _userService.AddUser(userDto);
                if (result > 0)
                {
                    list.Add("Ekleme işlemi başarılı");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                list.Add("Ekleme işlemi başarısız.");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}