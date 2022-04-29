using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAJ25R_HFT_2021222.Models.Tables
{
    public class Retailer
    {
        public Retailer()
        {
            this.Owners = new HashSet<Owner>();
        }

        public Retailer(int salary, string name, int deskId, string position, DateTime sellingDate)
        {
            this.Salary = salary;
            this.Name = name;
            this.DeskId = deskId;
            this.Position = position;
            this.SellingDate = sellingDate;
            this.Owners = new HashSet<Owner>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int SellerId { get; set; }

        [ToString]
        public int Salary { get; set; }

        [ToString]
        public string Name { get; set; }

        [ToString]
        public int DeskId { get; set; }

        [ToString]
        public string Position { get; set; }

        [ToString]
        public DateTime SellingDate { get; set; }

        [NotMapped]
        public virtual ICollection<Owner> Owners { get; set; }

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
