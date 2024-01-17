using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Interfaces;
using SMS.Models;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : Controller
    {
        ResponseModel res = new ResponseModel();
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpGet("GetAllRegisteredUser")]
        public ResponseModel GetAllRegisteredUser()
        {
            var result = _user.GetAllRegisteredUser();
            if (result.Status == "200")
            {
                res.Response = result.Response;
                return result;
            }
            return result;
        }

        [HttpPost("GetUserById")]
        public ResponseModel GetUserById(int id)
        {
            var result=_user.GetUserById(id);
            res.Response = result.Response;
            res.Status = result.Status;
            return res;
        }

        [HttpDelete("DeleteUser/{id}")]
      
        
        public ResponseModel DeleteUser(int id)
        {
            var result= _user.DeleteUser(id);
            if (result.Status == "200")
            {
                res.Response = result.Response; 
            }
            else
            {
                res.Response= result.Response;
            }
            return res;
        }

    }
}
