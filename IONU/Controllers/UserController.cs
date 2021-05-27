using IONU.Data;
using IONU.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IUserRepo _user { get; }

        public UserController(IUserRepo user)
        {

            _user = user;

        }
        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> getUser()
        {
            var c = await _user.GetUsers();
            return Json(c);
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task AddUser([FromBody] User user)
        {
            await _user.AddUser(user);
        }

        [HttpPost]
        [Route("DeletUser/{Id}")]
        public async Task DeletUser(int Id)
        {
            await _user.DeletUser(Id);
        }

        [HttpGet("")]
        [Route("GetUser/{Id}")]
        public async Task<ActionResult<User>> GetUser(int Id)
        {
            var users = await _user.GetUser(Id);
            if (users != null)
            {
                return Json(users);
            }

            return NotFound("no user");
        }
    }
}
