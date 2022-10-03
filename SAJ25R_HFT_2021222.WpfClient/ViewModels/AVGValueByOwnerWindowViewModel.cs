using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAJ25R_HFT_2021222.WpfClient.ViewModels
{
    public class AVGValueByOwnerWindowViewModel
    {
        RestService rest;

        public List<KeyValuePair<string, double>> AVGValueByOwer
        {
            get { return rest.Get<KeyValuePair<string, double>>("stat/AvgValueByOwner"); }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AVGValueByOwnerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                rest = new RestService("http://localhost:7671/");
            }

        }
    }
}
