using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Logic
{
    public interface IRetailerLogic
    {

        public IList<Retailer> GetAllRetailers();

        public Retailer GetRetailerById(int sellerId);

        public void AddRetailer(Retailer retailer);

        public void PositionUpdate(Retailer retailer);

        public void RemoveRetailerById(int sellerId);

        //5
        public List<RetailersOwners> RetOwns();

    }
}
