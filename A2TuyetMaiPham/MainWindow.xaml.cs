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
using System.Data;

namespace A2TuyetMaiPham
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data data = new Data();
        private CrudOpContinents crudContinents = new CrudOpContinents();
        private CrudOpCountries crudCountries = new CrudOpCountries();  
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbContinents.ItemsSource = crudContinents.GetContinents().DefaultView;
            cmbContinents.DisplayMemberPath = "ContinentName";
            cmbContinents.SelectedValuePath = "ContinentId";
        }

        private void cmbContinents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int continentId = Convert.ToInt32(cmbContinents.SelectedValue);

            DataRow[] countries = crudCountries.GetCountries(continentId);

            lstCountries.Items.Clear();

            foreach (DataRow country in countries) 
            {
                lstCountries.Items.Add(country["CountryName"]);
            }
            
        }
    }
}
