using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Models.Tables
{
    public class Owner
    {
        public Owner()
        {
            this.Guns = new HashSet<Gun>();
        }

        public Owner(int sellerId, int age, string name, string job, string address)
        {
            this.SellerId = sellerId;
            this.Age = age;
            this.Name = name;
            this.Job = job;
            this.Address = address;
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int OwnerId { get; set; }

        [ToString]
        public int SellerId { get; set; }

        [ToString]
        public int Age { get; set; }

        [ToString]
        public string Name { get; set; }

        [ToString]
        public string Job { get; set; }

        [ToString]
        public string Address { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Retailer Retailer { get; set; }

        [NotMapped]
        public virtual ICollection<Gun> Guns { get; set; }

        public override string ToString()
        {
            string x = " ";

            foreach (var item in this.GetType().GetProperties().Where(x =>
            x.GetCustomAttribute<ToStringAttribute>() != null))
            {
                x += "   ";
                x += item.Name + "\t=> ";
                x += item.GetValue(this);
                x += "\n";
            }

            return x;
        }
    }
}
