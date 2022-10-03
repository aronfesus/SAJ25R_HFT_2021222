using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security;
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

        //Gun Commands
        public ICommand CreateGunCommand { get; set; }
        public ICommand DeleteGunCommand { get; set; }
        public ICommand UpdateGunCommand { get; set; }

        //Owner Commands
        public ICommand CreateOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }

        //Retailer Commands
        public ICommand CreateRetailerCommand { get; set; }
        public ICommand DeleteRetailerCommand { get; set; }
        public ICommand UpdateRetailerCommand { get; set; }


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
                if(value != null)
                {
                    selectedOwner = new Owner()
                    {
                        OwnerId = value.OwnerId,
                        Address = value.Address,
                        Age = value.Age,
                        Guns = value.Guns,
                        Job = value.Job,
                        Name = value.Name,
                        Retailer = value.Retailer,
                        SellerId = value.SellerId
                    };
                    OnPropertyChanged();
                    (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Retailer selectedRetailer;

        public Retailer SelectedRetailer
        {
            get { return selectedRetailer; }
            set 
            { 
                if(value != null)
                {
                    selectedRetailer = new Retailer()
                    {
                        DeskId = value.DeskId,
                        Salary = value.Salary,
                        Name = value.Name,
                        Position = value.Position,
                        SellingDate = value.SellingDate,
                        SellerId = value.SellerId
                        
                    };
                    OnPropertyChanged();
                    (DeleteRetailerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
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
                
                Guns = new RestCollection<Gun>("http://localhost:7671/", "gun", "hub");
                Owners = new RestCollection<Owner>("http://localhost:7671/", "owner", "hub");
                Retailers = new RestCollection<Retailer>("http://localhost:7671/", "retailer", "hub");
                //OwnersGuns = new RestCollection<OwnersGuns>("http://localhost:7671/", "stat/OwnsGuns");
                //SumWeightByOwner = new RestCollection<KeyValuePair<string, double>>("http://localhost:7671/", "stat");
                //RetailersOwners = new RestCollection<RetailersOwners>("http://localhost:7671/", "stat");

                #region Gun
                CreateGunCommand = new RelayCommand(() =>
                {
                    Guns.Add(new Gun()
                    {
                        GunName = selectedGun.GunName,
                        Caliber = selectedGun.Caliber,
                        Owner = selectedGun.Owner,
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
                #endregion

                #region Owner
                CreateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Add(new Owner()
                    {
                        Name = selectedOwner.Name,
                        Address = selectedOwner.Address,
                        Age = selectedOwner.Age,
                        SellerId = selectedOwner.SellerId,
                        Job = selectedOwner.Job,
                    });
                });

                UpdateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Update(SelectedOwner);
                });

                DeleteOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Delete(selectedOwner.OwnerId);
                },
                () =>
                {
                   return selectedOwner != null;
                });

                SelectedOwner = new Owner();
                #endregion

                #region Retailer
                CreateRetailerCommand = new RelayCommand(() =>
                {
                    Retailers.Add(new Retailer()
                    {
                        Salary = selectedRetailer.Salary,
                        Name = selectedRetailer.Name,
                        Position = selectedRetailer.Position,
                        SellingDate = selectedRetailer.SellingDate,
                        DeskId = selectedRetailer.DeskId
                    });
                });

                UpdateRetailerCommand = new RelayCommand(() =>
                {
                    Retailers.Update(selectedRetailer);
                });

                DeleteRetailerCommand = new RelayCommand(() =>
                {
                    Retailers.Delete(selectedRetailer.SellerId);
                },
                () =>
                {
                    return selectedRetailer != null;
                });
                SelectedRetailer = new Retailer();
                #endregion

            }


        }
    }
}
