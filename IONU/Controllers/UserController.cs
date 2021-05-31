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
        [Route("getUser/{ID}")]
        public async Task<ActionResult<ResoultForUser>> getUser(int ID)
        {
            ResoultForUser resoult = new ResoultForUser();

            resoult.user = await _user.GetUser(ID);

            if (resoult.user != null)
            {

                resoult.Massage = "موجود";
                resoult.statusCode = 200;
                return Json(resoult);


            }
            else {
                resoult.Massage = "غير موجود ";
                resoult.statusCode = 404;
                return Json(resoult);
            
            }
            
            
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
        [HttpGet("")]
        [Route("GetALL")]
        public async Task<ActionResult<User>> GetALL()
        {
            var users = await _user.GetUsers();
            if (users != null)
            {
                return Json(users);
            }

            return Json(users);
        }
    }
}
