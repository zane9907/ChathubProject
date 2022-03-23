using Chathub.Logic;
using Chathub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageLogic logic;
        IHubContext<SignalRHub> hub;

        public MessageController(IMessageLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return logic.GetAll();
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public Message Get(int id)
        {
            return logic.Get(id);
        }

        // POST api/<MessageController>
        [HttpPost]
        public void Post([FromBody] Message value)
        {
            logic.Create(value);
            hub.Clients.All.SendAsync("MessageCreated", value);
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message value)
        {
            logic.Update(value);

        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
