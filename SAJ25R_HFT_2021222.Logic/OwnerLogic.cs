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
    public class OwnerLogic : IOwnerLogic
    {
        IOwnerRepository ownerRepo;

        public OwnerLogic(IOwnerRepository ownerRepo)
        {
            this.ownerRepo = ownerRepo;
        }

        public void AddOwner(Owner owner)
        {
            if (owner.Name == null)
            {
                throw new NullReferenceException("Name cant be null!");
            }
            if (owner.Name == "")
            {
                throw new ArgumentException("Name cant be empty!");
            }

            this.ownerRepo.InsertElement(owner);

        }

        public void JobUpdate(Owner owner)
        {
            this.ownerRepo.JobUpdate(owner);
        }

        public IList<Owner> GetAllOwners()
        {
            return this.ownerRepo.GetAll().ToList();
        }

        public Owner GetOwnerById(int ownerId)
        {
            return this.ownerRepo.GetById(ownerId);
        }

        //owner with their guns
        public List<OwnersGuns> OwnsGuns()
        {
            var q = (from owner in this.ownerRepo.GetAll().ToList()
                     group owner by owner.Name into g
                     select new OwnersGuns()
                     {
                         OwnName = g.Key,
                         Guns = (from owner in g
                                 from gun in owner.Guns
                                 select (gun)).ToList()
                     }).ToList();
            return q;
        }



        public void RemoveByOwnerId(int ownerId)
        {
            this.ownerRepo.RemoveById(ownerId);

        }
    }
}
