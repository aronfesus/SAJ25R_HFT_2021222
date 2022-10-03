using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using SAJ25R_HFT_2021222.Endpoint.Services;
using SAJ25R_HFT_2021222.Logic;
using SAJ25R_HFT_2021222.Models.Tables;
using System.Collections.Generic;

namespace SAJ25R_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GunController : ControllerBase
    {

        IGunLogic gunLogic;
        IHubContext<SignalRHub> hub;

        public GunController(IGunLogic gunLogic, IHubContext<SignalRHub> hub)
        {
            this.gunLogic = gunLogic;
            this.hub = hub;

        }

        // GET: api/<ManagerController>
        [HttpGet]
        public IEnumerable<Gun> Get()
        {
            return gunLogic.GetAllGuns();
        }

        // GET api/<ManagerController>/5
        [HttpGet("{id}")]
        public Gun Get(int id)
        {
            return gunLogic.GetGunById(id);
        }

        // POST api/<ManagerController>
        [HttpPost]
        public void Post([FromBody] Gun value)
        {

            gunLogic.AddGun(value);
            this.hub.Clients.All.SendAsync("GunCreated", value);
        }

        // PUT api/<ManagerController>/5
        [HttpPut]
        public void Put([FromBody] Gun gun)
        {
            gunLogic.PriceUpdate(gun);
            this.hub.Clients.All.SendAsync("GunUpdated", gun);
        }

        // DELETE api/<ManagerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var gunToDelete = this.gunLogic.GetGunById(id);
            gunLogic.RemoveGunById(id);
            this.hub.Clients.All.SendAsync("GunUpdated", gunToDelete);
        }
    }
}
