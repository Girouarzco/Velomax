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
using VeloMax.DAL;
using VeloMax.Views;

namespace VeloMax
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

        private void BikeManagement_Click(object sender, RoutedEventArgs e)
        {
            Gestionvelos _Gestionvelos = new Gestionvelos();
            _Gestionvelos.Show();
        }

        private void SpareParts_Click(object sender, RoutedEventArgs e)
        {
            Piecesdetachees window = new Piecesdetachees();
            window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SuppliersManagement_Click(object sender, RoutedEventArgs e)
        {
            Fournisseurs window = new Fournisseurs();
            window.Show();
        }



        private void ClientManagement_Click(object sender, RoutedEventArgs e)
        {
            Clients window = new Clients();
            window.Show();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            Commande window = new Commande();
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DALClass.ExportLowStock();
        }

        private void ExpiringClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TotalClients_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Total Registered Clients are "+DALClass.GetTotalClients());
        }
    }
}
