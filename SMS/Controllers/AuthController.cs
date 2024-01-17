using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Interfaces;
using SMS.Models;
using SMS.ViewModel;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class AuthController : Controller
    {
        private readonly IAuth _auth;
        ResponseModel res = new ResponseModel();
        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost("UserRegistration")]
      
        public ResponseModel UserRegistration(RegistrationVM registrationVM)
        {
           var result= _auth.UserRegistration(registrationVM);
            if (result.Status == "200")
            {
                res.Response = "Successfully Register";
            }
            else
            {
                res.Response = "Failed";
            }
            return res;
        }

        [HttpPost("UserLogin")]
 
        public ResponseModel UserLogin(LoginVM loginVM)
        {
           var result= _auth.UserLogin(loginVM);
            if (result.Status == "403")
            {
                res.Response = "Invalid Username OR Password";
                return res;
            }
            res.Response = "Successfully Login";
            res.Status = result.Status;
            res.Token=result.Token;
            return res;
        }
     
    }
}
