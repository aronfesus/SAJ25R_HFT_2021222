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
    public class Gun
    {
        public Gun()
        {
        }

        public Gun(int ownerId, string gunName, string caliber, int weight, int price)
        {
            this.OwnerId = ownerId;
            this.GunName = gunName;
            this.Caliber = caliber;
            this.Weight = weight;
            this.Price = price;
        }


        [Key]
        [ToString]
        public int SerialNumber { get; set; }

        [ToString]
        public int OwnerId { get; set; }

        [ToString]
        public string GunName { get; set; }

        [ToString]
        public string Caliber { get; set; }

        [ToString]
        public int Weight { get; set; }

        [ToString]
        public int Price { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Owner Owner { get; set; }

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
