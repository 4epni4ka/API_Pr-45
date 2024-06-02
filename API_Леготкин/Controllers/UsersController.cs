using API_Леготкин.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using API_Леготкин.Model;
using System.Linq;

namespace API_Леготкин.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersController:Controller
    {
        [Route("SingIn")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult SingIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null)
                return StatusCode(403);
            try
            {
                Users User = new UsersContext().Users.Where(x => x.Login == Login && x.Password == Password).First();

                return Json(User);
            }
            catch (Exception exp)
            {
                return StatusCode(500);
            }
        }
    }
}
