using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using SAJ25R_HFT_2021222.Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Logic
{
    public class RetailerLogic : IRetailerLogic
    {

        IRetailerRepository retailerRepo;

        public RetailerLogic(IRetailerRepository retailerRepo)
        {
            this.retailerRepo = retailerRepo;
        }

        public void AddRetailer(Retailer retailer)
        {
            if (retailer.Name == null)
            {
                throw new NullReferenceException("Name cant be null!");
            }
            if (retailer.Name == null)
            {
                throw new ArgumentException("Name cant be empty!");
            }

            this.retailerRepo.InsertElement(retailer);
        }

        public void PositionUpdate(Retailer retailer)
        {
            this.retailerRepo.PositionUpdate(retailer);
        }

        public IList<Retailer> GetAllRetailers()
        {
            return this.retailerRepo.GetAll().ToList();
        }

        public Retailer GetRetailerById(int sellerId)
        {
            return this.retailerRepo.GetById(sellerId);
        }

        public void RemoveRetailerById(int sellerId)
        {
            this.retailerRepo.RemoveById(sellerId);
        }

        public List<RetailersOwners> RetOwns()
        {
            var q = (from retailer in this.retailerRepo.GetAll().ToList()
                     group retailer by retailer.Name into g
                     select new RetailersOwners()
                     {
                         RetName = g.Key,
                         Owners = (from retailer in g
                                   from owner in retailer.Owners
                                   select (owner)).ToList()
                     }).ToList();
            return q;
        }
    }
}
