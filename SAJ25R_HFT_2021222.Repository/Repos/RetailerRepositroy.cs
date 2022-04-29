using SAJ25R_HFT_2021222.Models.Tables;
using SAJ25R_HFT_2021222.Repository.DbContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Repository.Repos
{
    public class RetailerRepositroy : Repository<Retailer>, IRetailerRepository
    {

        private GunDbContext ctx;

        public RetailerRepositroy(GunDbContext ctx)
            : base(ctx)
        {
            this.ctx = ctx;
        }
        public void PositionUpdate(Retailer retailer)
        {
            var oldRet = this.GetById(retailer.SellerId);
            oldRet.Position = retailer.Position;
            this.ctx.SaveChanges();
        }

        public override Retailer GetById(int id)
        {
            return this.ctx.Retailers.Where(i => i.SellerId == id).FirstOrDefault();
        }

        public override void RemoveById(int id)
        {
            this.ctx.Remove(this.ctx.Retailers.Where(o => o.SellerId == id).FirstOrDefault());
            this.ctx.SaveChanges();
        }
    }
}
