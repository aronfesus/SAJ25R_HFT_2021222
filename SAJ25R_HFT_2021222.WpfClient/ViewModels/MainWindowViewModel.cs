using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SAJ25R_HFT_2021222.WpfClient.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {

        public RestCollection<Gun> Guns { get; set; }

        public RestCollection<Owner> Owners { get; set; }

        public RestCollection<Retailer> Retailers { get; set; }

        //public RestCollection<OwnersGuns> OwnersGuns { get; set; }

        //public RestCollection<KeyValuePair<string, double>> SumWeightByOwner { get; set; }

        //public RestCollection<RetailersOwners> RetailersOwners { get; set; }

        public ICommand CreateGunCommand { get; set; }
        public ICommand DeleteGunCommand { get; set; }
        public ICommand UpdateGunCommand { get; set; }

        private Gun selectedGun;

        public Gun SelectedGun
        {
            get { return selectedGun; }
            set 
            {
                if(value != null)
                {
                    selectedGun = new Gun()
                    {
                        GunName = value.GunName,
                        Caliber = value.Caliber,
                        Owner = value.Owner,
                        OwnerId = value.OwnerId,
                        Price = value.Price,
                        SerialNumber = value.SerialNumber,
                        Weight = value.Weight
                    };
                    OnPropertyChanged();
                    (DeleteGunCommand as RelayCommand).NotifyCanExecuteChanged();
                }   
            }
        }

        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set 
            { 
                SetProperty(ref selectedOwner, value);
                
            }
        }

        private Retailer selectedRetailer;

        public Retailer SelectedRetailer
        {
            get { return selectedRetailer; }
            set { SetProperty(ref selectedRetailer, value); }
        }



        //public List<KeyValuePair<string, double>> SumWeightByOwner
        //{
        //    get { return rest.Get<KeyValuePair<string, double>>("stat/SumWeightByOwner"); }
        //}




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
            if (!IsInDesignMode)
            {
                
                Guns = new RestCollection<Gun>("http://localhost:7671/", "gun");
                Owners = new RestCollection<Owner>("http://localhost:7671/", "owner");
                Retailers = new RestCollection<Retailer>("http://localhost:7671/", "retailer");
                //OwnersGuns = new RestCollection<OwnersGuns>("http://localhost:7671/", "stat/OwnsGuns");
                //SumWeightByOwner = new RestCollection<KeyValuePair<string, double>>("http://localhost:7671/", "stat");
                //RetailersOwners = new RestCollection<RetailersOwners>("http://localhost:7671/", "stat");

                CreateGunCommand = new RelayCommand(() =>
                {
                    Guns.Add(new Gun()
                    {
                        GunName = selectedGun.GunName,
                        Caliber = selectedGun.Caliber,
                        Owner = selectedGun.Owner,
                        SerialNumber = selectedGun.SerialNumber,
                        OwnerId = selectedGun.OwnerId,
                        Price = selectedGun.Price,
                        Weight = selectedGun.Weight
                        
                    });
                });

                UpdateGunCommand = new RelayCommand(() =>
                {
                    Guns.Update(SelectedGun);
                });

                DeleteGunCommand = new RelayCommand(() =>
                {
                    Guns.Delete(SelectedGun.SerialNumber);
                },
                () =>
                {
                    return selectedGun != null;
                });

                SelectedGun = new Gun();
            }


        }
    }
}
