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
    public class GunLogic : IGunLogic
    {
        private IGunRepository gunRepo;
        private IOwnerRepository ownerRepo;

        public GunLogic(IGunRepository gunRepo, IOwnerRepository ownerRepo)
        {
            this.gunRepo = gunRepo;
            this.ownerRepo = ownerRepo;
        }

        public void AddGun(Gun gun)
        {
            if (gun.GunName == null)
                throw new NullReferenceException("Name was null!");

            if (gun.GunName == "")
                throw new ArgumentException("Name was empty string!");

            this.gunRepo.InsertElement(gun);
        }

        public double AvgPrice()
        {
            return gunRepo.GetAll().Average(x => x.Price);
        }


        //avg gun price by owner
        public IEnumerable<KeyValuePair<string, double>> AvgValueByOwner()
        {
            return from x in gunRepo.GetAll()
                   group x by x.Owner.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Price));
        }



        public void PriceUpdate(Gun gun)
        {
            this.gunRepo.PriceUpdate(gun);
        }

        public IList<Gun> GetAllGuns()
        {
            return this.gunRepo.GetAll().ToList();
        }

        public Gun GetGunById(int serialNumber)
        {
            return this.gunRepo.GetById(serialNumber);
        }

        //guns with their owners
        public List<GunsOwners> GunsOwns()
        {
            var q = (from gun in this.gunRepo.GetAll().ToList()
                     join owner in this.ownerRepo.GetAll().ToList() on gun.OwnerId equals owner.OwnerId
                     select new GunsOwners() { OwnName = owner.Name, SerialNumber = gun.SerialNumber }).ToList();
            return q;
        }

        //gun weight for owners
        public IEnumerable<KeyValuePair<string, double>> SumWeightByOwner()
        {
            return from x in gunRepo.GetAll()
                   group x by x.Owner.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Sum(w => w.Weight));
        }

        public void RemoveGunById(int serialNumber)
        {
            this.gunRepo.RemoveById(serialNumber);
        }
    }
}
