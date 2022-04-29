using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAJ25R_HFT_2021222.Logic;
using SAJ25R_HFT_2021222.Models.Others;
using System.Collections.Generic;

namespace SAJ25R_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {

        IOwnerLogic ownerLogic;
        IRetailerLogic retailerLogic;
        IGunLogic gunLogic;

        public StatController(IOwnerLogic ownerLogic, IRetailerLogic retailerLogic, IGunLogic gunLogic)
        {
            this.ownerLogic = ownerLogic;
            this.retailerLogic = retailerLogic;
            this.gunLogic = gunLogic;
        }

        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<GunsOwners> GunsOwns()
        {
            return gunLogic.GunsOwns();
        }


        [HttpGet]
        public IEnumerable<OwnersGuns> OwnsGuns()
        {
            return ownerLogic.OwnsGuns();
        }

        [HttpGet]
        public IEnumerable<RetailersOwners> RetOwns()
        {
            return retailerLogic.RetOwns();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AvgValueByOwner()
        {
            return gunLogic.AvgValueByOwner();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> SumWeightByOwner()
        {
            return gunLogic.SumWeightByOwner();
        }


        // GET api/<StatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
