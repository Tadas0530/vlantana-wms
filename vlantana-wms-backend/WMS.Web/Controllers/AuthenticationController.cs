using Microsoft.AspNetCore.Mvc;
using vlantana_wms_backend.Contracts.Web;
using vlantana_wms_backend.Contracts.Web.UserCredentials;
using vlantana_wms_backend.Data;
using vlantana_wms_backend.Models.Auth;

namespace vlantana_wms_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet(Name = "GetGreeting")]
        public IActionResult GetGreeting()
        {
            return Content("Greetings I am working!");
        }

        [HttpPost("register", Name = "Register")]
        public JsonResult Register([FromBody] UserCredentials userCredentials)
        {
            UserCredentialsResponse response = new UserCredentialsResponse();

            var newUserCredentials = new UserCredentials { UserName = userCredentials.UserName, Email = userCredentials.Email, Password = userCredentials.Password };

            using (var context = new DataContext())
            {
                var existingCredentials = context.Credentials.FirstOrDefault(u => u.Email == userCredentials.Email);

                if (existingCredentials == null)
                {
                    // Create credfentials
                    context.Credentials.Add(newUserCredentials);

                    // Creating account
                    var newUser = new User { Name = newUserCredentials.UserName, Email = newUserCredentials.Email,
                        CompanyId = null, PhoneNumber = null, Role = null, PhotoPath = null, UserCredentials = newUserCredentials };

                    newUserCredentials.User = newUser;

                    context.User.Add(newUser);
                    context.SaveChanges();

                    return new JsonResult(newUser);
                } else
                {
                    return new JsonResult(new ErrorResponse { Status = "404", Message = "User already exists" });
                }
            }
        }

        //    [HttpPost("login", Name = "Login")]
        //    public JsonResult Login([FromBody] UserCredentials userCredentials)
        //    {
        //        if (userCredentials.Password != null && userCredentials.Email.Trim() != null)
        //        {
        //            return new JsonResult(new ErrorResponse { Status = "500", Message = "No credentials provided" });
        //        }

        //        using (var context = new DataContext())
        //        {
        //            var emailExists = context.User.FirstOrDefault(u => u.Email == userCredentials.Email);

        //            if (emailExists != null)
        //            {
        //                var user = context.Credentials.FirstOrDefault(c => userCredentials.Password.Equals(c.Password));


        //                context.User.Add(newUser);
        //                context.SaveChanges();

        //                return new JsonResult(newUser);
        //            }
        //            else
        //            {
        //                return new JsonResult(new ErrorResponse { Status = "404", Message = "Wrong username or password" });
        //            }
        //        }
        //    }
    }
}