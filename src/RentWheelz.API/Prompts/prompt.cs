////Create a controller based on the following prompt:
////1. Register : This api is used for registering a new user to the application.
////URL http://localhost:4000/register
////Method POST
////Request
//// {
////  userName:"krishna",
////  userEmail:"krishna@abc.com",
////  userPassword:"krishna@123",
////  proofId:"U101"
//// }
//// route should be http://localhost:4000/register


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace RentWheelz.API.Controllers
//{
//    [ApiController]
//    [Route("Register")]
//    public class RegisterController : ControllerBase
//    {
//        [HttpPost]
//        public IActionResult Register([FromBody] User user)
//        {
//            return Ok();
//        }
//    }

//    public class User
//    {
//        public string userName { get; set; }
//        public string userEmail { get; set; }
//        public string userPassword { get; set; }
//        public string proofId { get; set; }
//    }
//}
