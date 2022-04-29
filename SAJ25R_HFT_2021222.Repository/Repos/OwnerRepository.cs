using SAJ25R_HFT_2021222.Models.Tables;
using SAJ25R_HFT_2021222.Repository.DbContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Repository.Repos
{
    public class OwnerRepository : Repository<Owner>, IOwnerRepository
    {
        private GunDbContext ctx;

        public OwnerRepository(GunDbContext ctx)
            : base(ctx)
        {
            this.ctx = ctx;
        }

        public void JobUpdate(Owner owner)
        {
            var oldOwner = this.GetById(owner.OwnerId);
            oldOwner.Job = owner.Job;
            this.ctx.SaveChanges();
        }

        public override Owner GetById(int id)
        {
            return this.ctx.Owners.Where(i => i.OwnerId == id).FirstOrDefault();
        }

        public override void RemoveById(int id)
        {
            this.ctx.Remove(this.ctx.Owners.Where(i => i.OwnerId == id).FirstOrDefault());
            this.ctx.SaveChanges();
        }
    }
}
