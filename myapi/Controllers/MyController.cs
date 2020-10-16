using System;
using Microsoft.AspNetCore.Mvc;
using mylib;

namespace myapi.Controllers
{
    [Route("/")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private ClassLib MyLib { get; }

        public MyController(ClassLib mylib) => MyLib = mylib;

        [HttpGet]
        [Route("callmylib")]
        public IActionResult CallMyLib()
        {
            return Ok(MyLib.Call("Jane"));
        }
    }
}
