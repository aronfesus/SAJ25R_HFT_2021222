using CommunityToolkit.Mvvm.ComponentModel;
using SAJ25R_HFT_2021222.Models.Others;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAJ25R_HFT_2021222.WpfClient.ViewModels
{
    public class GunsOwnersWindowViewModel : ObservableRecipient
    {
        RestService rest;

        public List<GunsOwners> GunsOwners
        {
            get { return rest.Get<GunsOwners>("stat/GunsOwns"); }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GunsOwnersWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                rest = new RestService("http://localhost:7671/");
            }

        }
    }
}
