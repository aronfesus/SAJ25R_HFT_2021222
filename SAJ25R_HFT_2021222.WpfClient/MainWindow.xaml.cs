using SAJ25R_HFT_2021222.WpfClient.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAJ25R_HFT_2021222.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OwnersGunsWindow win2 = new OwnersGunsWindow();
            win2.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GunsOwnersWindow win3 = new GunsOwnersWindow();
            win3.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RetailersOwnersWindow win4 = new RetailersOwnersWindow();
            win4.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AVGValueByOwnerWindow win5 = new AVGValueByOwnerWindow();
            win5.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SumWeightByOwnerWindow win6 = new SumWeightByOwnerWindow();
            win6.Show();
        }
    }
}
