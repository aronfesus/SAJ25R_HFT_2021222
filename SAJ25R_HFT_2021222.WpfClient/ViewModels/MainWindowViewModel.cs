using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAJ25R_HFT_2021222.WpfClient.ViewModels
{
    public class MainWindowViewModel
    {
        public RestCollection<Gun> Guns { get; set; }

        public RestCollection<Owner> Owners { get; set; }

        public RestCollection<Retailer> Retailers { get; set; }

        public RestCollection<OwnersGuns> OwnersGuns { get; set; }

        public RestCollection<KeyValuePair<string, double>> SumWeightByOwner { get; set; }

        public RestCollection<RetailersOwners> RetailersOwners { get; set; }

        private Gun selectedGun;

        public Gun SelectedGun
        {
            get { return selectedGun; }
            set { selectedGun = value; }
        }

        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set { selectedOwner = value; }
        }

        private Retailer selectedRetailer;

        public Retailer SelectedRetailer
        {
            get { return selectedRetailer; }
            set { selectedRetailer = value; }
        }




        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {

            Guns = new RestCollection<Gun>("http://localhost:7671/", "gun");
            Owners = new RestCollection<Owner>("http://localhost:7671/", "owner");
            Retailers = new RestCollection<Retailer>("http://localhost:7671/", "retailer");
            //OwnersGuns = new RestCollection<OwnersGuns>("http://localhost:7671/", "stat/ownsguns");
            //SumWeightByOwner = new RestCollection<KeyValuePair<string, double>>("http://localhost:7671/", "stat");
            //RetailersOwners = new RestCollection<RetailersOwners>("http://localhost:7671/", "stat");

        }
    }
}
