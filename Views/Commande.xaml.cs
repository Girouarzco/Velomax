using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VeloMax.DAL;
using VeloMax.Models;

namespace VeloMax.Views
{
    /// <summary>
    /// </summary>
    public partial class Commande : Window
    {
        string Type = "";
        int quantity = 0;
        ObservableCollection<ClientOrders> list = new ObservableCollection<ClientOrders>();
        public Commande()
        {
            InitializeComponent();
            cmbClient.ItemsSource = DALClass.GetAllStores();
            cmbPart.ItemsSource = DALClass.GetAllBikeparts();
            cmbBike.ItemsSource = DALClass.GetAllBikes();
            UpdateGUI();
        }
        void UpdateGUI()
        {
            list = new ObservableCollection<ClientOrders>(DALClass.GetAllOrders());
            dgOrders.ItemsSource = list;
        }
        private void PlaceNewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (cmbClient.SelectedItem == null || (cmbBike.SelectedItem == null && cmbPart.SelectedItem == null) || tbQuantite.Text == ""
                || tbTotal.Text == "")
            {
                MessageBox.Show("Please Enter All Values");
            }
            else
            {

                Part part = new Part();
                Velos bike = new Velos();
                ClientOrders obj = new ClientOrders();

                var client = cmbClient.SelectedItem as Client;

                if (Type == "Bike")
                {
                    bike = cmbBike.SelectedItem as Velos;
                    obj.ProductId = bike.Id;
                    obj.Nom = bike.Nom;
                }
                else if (Type == "Part")
                {
                    part = cmbPart.SelectedItem as Part;
                    obj.ProductId = part.Id;
                    obj.Nom = part.ProductNumber;
                }

                obj.Type = Type;
                obj.ClientNom = client.CompanyNom;
                obj.ClientId = client.Id;
                obj.Quantite = Convert.ToInt32(tbQuantite.Text);
                obj.DeliveryTime = tbDeliveryTime.Text;
                obj.Total = Convert.ToDouble(tbTotal.Text);


                var res = DALClass.PlaceOrder(obj);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                    DALClass.UpdateStock(obj.ProductId, Type, quantity);
                }
                //Resetting Ui Controls
                tbQuantite.Text = "";
                tbDeliveryTime.Text = "";
                tbTotal.Text = "";
            }
        }


        private void Update_Row(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem != null)
            {
                var obj = dgOrders.SelectedItem as ClientOrders;
                var res = DALClass.UpdateOrder(obj);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                }
            }
        }

        private void Delete_Row(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem != null)
            {
                var obj = dgOrders.SelectedItem as ClientOrders;
                var res = DALClass.DeleteOrder(obj.Id);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                }
            }
        }

        private void rbBike_Click(object sender, RoutedEventArgs e)
        {
            if (rbBike.IsChecked == true)
            {
                cmbBike.IsEnabled = true;
                cmbPart.IsEnabled = false;
                Type = "Vélos";
            }
            else
            {
                cmbPart.IsEnabled = true;
                cmbBike.IsEnabled = false;
            }
        }

        private void rbParts_Click(object sender, RoutedEventArgs e)
        {
            if (rbParts.IsChecked == true)
            {
                cmbPart.IsEnabled = true;
                cmbBike.IsEnabled = false;
                Type = "Pièce";
            }
            else
            {
                cmbPart.IsEnabled = false;
                cmbBike.IsEnabled = true;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void tbQuantite_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbQuantite.Text))
            {
                int _quantity = Convert.ToInt32(tbQuantite.Text);

                if (Type == "Pièce")
                {
                    var part = cmbPart.SelectedItem as Part;
                    if (part.Quantite < _quantity)
                    {
                        MessageBox.Show("Quantité insuffisante!");
                        tbQuantite.Text = "";
                    }
                    else
                    {
                        quantity = part.Quantite - _quantity;
                        tbTotal.Text = (_quantity * part.Prix).ToString();
                    }
                }
                else if (Type == "Vélos")
                {
                    var bike = cmbBike.SelectedItem as Velos;
                    if (bike.Quantite < _quantity)
                    {
                        MessageBox.Show("Quantité insuffisante");
                        tbQuantite.Text = "";
                    }
                    else
                    {
                        quantity = bike.Quantite - _quantity;
                        tbTotal.Text = (_quantity * bike.Prix).ToString();
                    }
                }
            }
            

        }
    }
}
