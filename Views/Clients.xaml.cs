using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using VeloMax.DAL;
using VeloMax.Models;

namespace VeloMax.Views
{
    /// <summary>
    /// Interaction logic for StoreClients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        ObservableCollection<Client> list = new ObservableCollection<Client>();
        string Type = "";
        public Clients()
        {
            InitializeComponent();
            UpdateGUI();
        }
        void UpdateGUI()
        {
            list = new ObservableCollection<Client>(DALClass.GetAllStores());
            dgStore.ItemsSource = list;
        }

        private void AddStore_Click(object sender, RoutedEventArgs e)
        {
            if (tbAddress.Text == "" || tbCompany.Text == "" || tbEmail.Text == "" || tbContact.Text == "")
            {
                MessageBox.Show("Please Enter All Values");
                tbCompany.Focus();
            }
            else
            {
                Client obj = new Client();
                obj.Address = tbAddress.Text;
                obj.CompanyNom = tbCompany.Text;
                obj.Contact = tbContact.Text;
                obj.Email = tbEmail.Text;                
                obj.Type = Type;                

                if(Type == "Individus")
                {
                    obj.Fidelio = cmbFidelio.SelectionBoxItem.ToString();
                }
                else if (Type == "Store")
                {
                    obj.ContactPersonne = tbCpersonne.Text;
                    obj.Discount = tbDiscount.Text;
                }

                var res = DALClass.AddStore(obj);
                if (res)
                {
                    MessageBox.Show("Success");
                    UpdateGUI();
                }
                //Resetting Ui Controls
                tbAddress.Text = "";
                tbCompany.Text = "";
                tbContact.Text = "";
                tbEmail.Text = "";
                tbCpersonne.Text = "";
                tbDiscount.Text = "";
            }
        }

        private void Update_Row(object sender, RoutedEventArgs e)
        {
            if (dgStore.SelectedItem != null)
            {
                var obj = dgStore.SelectedItem as Client;
                var res = DALClass.UpdateStore(obj);
                if (res)
                {
                    MessageBox.Show("Record Updated");
                    UpdateGUI();
                }
            }
        }

        private void Delete_Row(object sender, RoutedEventArgs e)
        {
            if (dgStore.SelectedItem != null)
            {
                var obj = dgStore.SelectedItem as Client;
                var res = DALClass.DeleteStore(obj.Id);
                if (res)
                {
                    MessageBox.Show("Record Deleted");
                    UpdateGUI();
                }
            }
        }

        private void rbStore_Click(object sender, RoutedEventArgs e)
        {
            if(rbStore.IsChecked == true)
            {
                tbCpersonne.IsEnabled = true;
                tbDiscount.IsEnabled = true;
                cmbFidelio.IsEnabled = false;
                Type = "Store";
            }
            else
            {
                tbCpersonne.IsEnabled = false;
                tbDiscount.IsEnabled = false;
                cmbFidelio.IsEnabled = true;
            }
        }

        private void rbindividus_Click(object sender, RoutedEventArgs e)
        {
            if (rbindividus.IsChecked == true)
            {
                tbCpersonne.IsEnabled = false;
                cmbFidelio.IsEnabled = true;
                tbDiscount.IsEnabled = false;
                Type = "Individus";
            }
            else
            {
                tbCpersonne.IsEnabled = true;
                tbDiscount.IsEnabled = true;
                cmbFidelio.IsEnabled = false;
            }
        }

        private void cmbFidelioFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cmbFidelioFilter.SelectedItem;
            if(typeItem.Content != null)
            {
                string value = typeItem.Content.ToString();
                if (cmbFidelioFilter.SelectedItem != null && value != "Please Select")
                {
                    var list2 = list.Where(x => x.Fidelio == value)?.ToList();
                    dgStore.ItemsSource = list2;
                }
                else
                {
                    dgStore.ItemsSource = list;
                }
            }
           
        }
    }
}
