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
    /// Interaction logic for Fournisseurs.xaml
    /// </summary>
    public partial class Fournisseurs : Window
    {
        ObservableCollection<Fournisseur> list = new ObservableCollection<Fournisseur>();
        public Fournisseurs()
        {
            InitializeComponent();
            UpdateGUI();
        }
        void UpdateGUI()
        {
            list = new ObservableCollection<Fournisseur>(DALClass.GetAllfournisseur());
            dgSupp.ItemsSource = list;
        }

        private void AddSupp_Click(object sender, RoutedEventArgs e)
        {
            if (tbAddress.Text == "" || tbCompany.Text == "" || tbSiret.Text == "" || tbQualifiant.Text == ""|| tbContact.Text == "")
            //|| cmbProductLine.SelectedItem == null)
            {
                MessageBox.Show("Renseigner tous les champs");
                tbCompany.Focus();
            }
            else
            {
                Fournisseur obj = new Fournisseur();
                obj.Address = tbAddress.Text;
                obj.CompanyNom = tbCompany.Text;
                obj.Contact = tbContact.Text;
                obj.Qualifiant =Convert.ToInt32(tbQualifiant.SelectionBoxItem);
                obj.Siret = tbSiret.Text;

                var res = DALClass.AddFournisseur(obj);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                }
                //Resetting Ui Controls
                tbAddress.Text = "";
                tbCompany.Text = "";
                tbContact.Text = "";
            }
        }


        private void Update_Row(object sender, RoutedEventArgs e)
        {
            if (dgSupp.SelectedItem != null)
            {
                var obj = dgSupp.SelectedItem as Fournisseur;
                var res = DALClass.Updatefournisseur(obj);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                }
            }
        }

        private void Delete_Row(object sender, RoutedEventArgs e)
        {
            if (dgSupp.SelectedItem != null)
            {
                var obj = dgSupp.SelectedItem as Fournisseur;
                var res = DALClass.Deletefournisseur(obj.Id);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                }
            }
        }
    }
}
