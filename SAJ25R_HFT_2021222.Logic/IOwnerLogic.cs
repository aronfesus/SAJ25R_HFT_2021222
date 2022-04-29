using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Logic
{
    public interface IOwnerLogic
    {
        public IList<Owner> GetAllOwners();

        public Owner GetOwnerById(int ownerId);

        public void AddOwner(Owner owner);

        public void JobUpdate(Owner owner);

        public void RemoveByOwnerId(int ownerId);

        //4
        public List<OwnersGuns> OwnsGuns();
    }
}
