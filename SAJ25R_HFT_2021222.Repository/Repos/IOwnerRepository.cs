using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Repository.Repos
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        void JobUpdate(Owner owner);
    }
}
