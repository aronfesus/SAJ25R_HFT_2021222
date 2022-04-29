using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Logic
{
    public interface IGunLogic
    {
        public IList<Gun> GetAllGuns();

        public Gun GetGunById(int serialNumber);

        public void AddGun(Gun gun);

        public void PriceUpdate(Gun gun);

        public void RemoveGunById(int serialNumber);

        double AvgPrice();

        //1
        IEnumerable<KeyValuePair<string, double>> AvgValueByOwner();

        //2
        IEnumerable<KeyValuePair<string, double>> SumWeightByOwner();

        //3
        public List<GunsOwners> GunsOwns();
    }
}
