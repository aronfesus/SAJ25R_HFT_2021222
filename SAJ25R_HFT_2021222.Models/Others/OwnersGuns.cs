using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Models.Others
{
    public class OwnersGuns
    {
        public string OwnName { get; set; }

        public List<Gun> Guns { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is OwnersGuns)
            {
                OwnersGuns other = obj as OwnersGuns;
                return this.OwnName == other.OwnName;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

    }
}
