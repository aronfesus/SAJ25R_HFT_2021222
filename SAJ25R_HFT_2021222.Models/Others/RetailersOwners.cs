using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Models.Others
{
    public class RetailersOwners
    {
        public string RetName { get; set; }

        public List<string> Owners { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is RetailersOwners)
            {
                RetailersOwners other = obj as RetailersOwners;
                return this.RetName == other.RetName;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

    }
}
