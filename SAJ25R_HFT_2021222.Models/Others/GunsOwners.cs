using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Models.Others
{
    public class GunsOwners
    {
        public string OwnName { get; set; }

        public int SerialNumber { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is GunsOwners)
            {
                GunsOwners other = obj as GunsOwners;
                return this.OwnName == other.OwnName &&
                       this.SerialNumber == other.SerialNumber;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return OwnName + " " + SerialNumber;
        }
    }
}
