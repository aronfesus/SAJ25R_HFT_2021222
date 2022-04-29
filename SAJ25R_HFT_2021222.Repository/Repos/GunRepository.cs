using SAJ25R_HFT_2021222.Models.Tables;
using SAJ25R_HFT_2021222.Repository.DbContextFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Repository.Repos
{
    public class GunRepository : Repository<Gun>, IGunRepository
    {
        private GunDbContext ctx;

        public GunRepository(GunDbContext ctx)
            : base(ctx)
        {
            this.ctx = ctx;
        }
        public void PriceUpdate(Gun gun)
        {
            var oldGun = GetById(gun.SerialNumber);
            oldGun.Price = gun.Price;
            ctx.SaveChanges();

        }

        public override Gun GetById(int id)
        {
            return this.ctx.Guns.Where(g => g.SerialNumber == id).FirstOrDefault();
        }

        public override void RemoveById(int id)
        {
            this.ctx.Remove(this.ctx.Guns.Where(g => g.SerialNumber == id).FirstOrDefault());
            this.ctx.SaveChanges();
        }
    }
}
