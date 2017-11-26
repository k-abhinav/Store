using Store.Core.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/User/GetUser/{name}")]
        public HttpResponseMessage GetUser(string name)
        {
            var user = _userService.GetUser(name);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
