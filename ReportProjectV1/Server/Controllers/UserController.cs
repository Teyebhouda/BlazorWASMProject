using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ReportProjectV1.Client.Services;
using ReportProjectV1.Shared.Models;

namespace ReportProjectV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /*

        private readonly IGenericServices<User> _UserService;

        public UserController(IGenericServices<User> IUserService)
        {
            _UserService = IUserService;

        }


        [HttpGet]

        public IEnumerable<User> Get()
        {
            return _UserService.GetAll();
        }
        
            [HttpGet("{id}")]
            public ActionResult<User> Get(int id)
            {
                    var User= _UserService.GetById(id);

                    if (User== null)
                    {
                        return NotFound();
                    }

                    return User;
                }
        

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            _UserService.AddObject(user);

            return CreatedAtAction(nameof(Get), new { id = user.IDUser }, user);
        }
        
                [HttpPut]
                public IActionResult Put(int id, User user)
                {
                    if (id != user.IDUser)
                    {
                        return BadRequest();
                    }

                    _UserService.Update(user);

                    return NoContent();
                }
        

        
        [HttpPatch("{id}")]
    public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<User> patch)
    {
        var res = (User)((OkObjectResult)Get(id).Result).Value;
        if (res != null)
        {
            patch.ApplyTo(res);
            return Ok();
        }
        return NotFound();
    }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _UserService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _UserService.DeleteObject(user);

            return NoContent();
        }
         */
    }

}

