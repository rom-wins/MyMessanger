using Microsoft.AspNetCore.Mvc;
using MyMessanger;
using Newtonsoft.Json;

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messanger : ControllerBase
    {
        static List<Message> ListOfMessages = new List<Message>();
        // GET api/<Messanger>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string OutputString = "Not found";
            if ((id < ListOfMessages.Count) && (id >= 0))
            {
                OutputString = JsonConvert.SerializeObject(ListOfMessages[id]);
            }
            Console.WriteLine($"Запрошено сообщение № {id} : {OutputString}");
            return OutputString;
        }

        // POST api/<Messanger>
        [HttpPost]
        public IActionResult SendMessage([FromBody] Message msg)
        {
            if (msg == null)
            {
                Console.WriteLine(213);
                return BadRequest();
            }

            ListOfMessages.Add(msg);
            Console.WriteLine($"Всего сообщений: {ListOfMessages.Count} Посланное сообщение: {msg}");
            return new OkResult();
        }

    }
}
