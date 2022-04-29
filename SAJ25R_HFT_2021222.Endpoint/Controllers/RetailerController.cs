using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAJ25R_HFT_2021222.Logic;
using SAJ25R_HFT_2021222.Models.Tables;
using System.Collections.Generic;

namespace SAJ25R_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RetailerController : ControllerBase
    {

        IRetailerLogic retailerLogic;

        public RetailerController(IRetailerLogic retailerLogic)
        {
            this.retailerLogic = retailerLogic;
        }

        // GET: api/<RetailerController>
        [HttpGet]
        public IEnumerable<Retailer> Get()
        {
            return retailerLogic.GetAllRetailers();
        }

        // GET api/<RetailerController>/5
        [HttpGet("{id}")]
        public Retailer Get(int id)
        {
            return retailerLogic.GetRetailerById(id);
        }

        // POST api/<RetailerController>
        [HttpPost]
        public void Post([FromBody] Retailer value)
        {
            retailerLogic.AddRetailer(value);
        }

        // PUT api/<RetailerController>/5
        [HttpPut]
        public void Put([FromBody] Retailer retailer)
        {
            retailerLogic.PositionUpdate(retailer);
        }

        // DELETE api/<RetailerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            retailerLogic.RemoveRetailerById(id);
        }
    }
}
