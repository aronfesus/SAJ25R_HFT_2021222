using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SAJ25R_HFT_2021222.Endpoint.Services;
using SAJ25R_HFT_2021222.Logic;
using SAJ25R_HFT_2021222.Models.Tables;
using System.Collections.Generic;

namespace SAJ25R_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        IOwnerLogic ownerLogic;
        IHubContext<SignalRHub> hub;

        public OwnerController(IOwnerLogic ownerLogic, IHubContext<SignalRHub> hub)
        {
            this.ownerLogic = ownerLogic;
            this.hub = hub;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return ownerLogic.GetAllOwners();
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return ownerLogic.GetOwnerById(id);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            ownerLogic.AddOwner(value);
            this.hub.Clients.All.SendAsync("OwnerCreated", value);
        }

        // PUT api/<OwnerController>/5
        [HttpPut]
        public void Put([FromBody] Owner owner)
        {
            ownerLogic.JobUpdate(owner);
            this.hub.Clients.All.SendAsync("OwnerUpdated", owner);
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ownerToDelete = this.ownerLogic.GetOwnerById(id);
            ownerLogic.RemoveByOwnerId(id);
            this.hub.Clients.All.SendAsync("OwnerUpdated", ownerToDelete);
        }
    }
}
