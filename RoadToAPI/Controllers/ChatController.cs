using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadToAPI.Model;

namespace RoadToAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyOrigin")]
    [Authorize]
    [ApiController]
    public class ChatController : ControllerBase
    {
        // GET: api/Chat
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Chat/
        [HttpPost]
        public IActionResult Get([FromBody] Message msg)
        {
            string reply = "";
            if (msg.message.Equals("Hello", StringComparison.OrdinalIgnoreCase))
            {
                reply = "Chao ban, minh la test";
            }
            if (msg.message.Equals("Ban ten gi", StringComparison.OrdinalIgnoreCase))
            {
                reply = "Minh ten la JOHN CENA";
            }
            if (msg.message.Equals("May biet bo may la ai khong", StringComparison.OrdinalIgnoreCase))
            {
                reply = "Ban ten la: "+msg.userName;
            }

            return Ok(new { type = "sender",message = reply });
        }

       
    }
}
