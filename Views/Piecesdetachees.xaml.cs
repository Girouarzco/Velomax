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
    /// </summary>
    public partial class Piecesdetachees : Window
    {
        ObservableCollection<Part> Parts = new ObservableCollection<Part>();
        public Piecesdetachees()
        {
            InitializeComponent();
            //Update Grid UI
            UpdateGUI();

            cmbSupplier.ItemsSource = DALClass.GetAllfournisseur();
        }
        void UpdateGUI()
        {
            Parts = new ObservableCollection<Part>(DALClass.GetAllBikeparts());
            dgBikePart.ItemsSource = Parts;
        }

        private void AddBikePart_Click(object sender, RoutedEventArgs e)
        {
            if (tbdescription.Text == "" || tbPrix.Text == "" || tbGrandeur.Text == "" || tbProductNumber.Text == ""
                || cmbSupplier.SelectedItem == null || tbQuantite.Text == "")
            {
                MessageBox.Show("Entrez toutes les valeurs");
                tbdescription.Focus();
            }
            else
            {
                var supp = cmbSupplier.SelectedItem as Fournisseur;
                Part obj = new Part();
                obj.Fournisseur = supp.CompanyNom;
                obj.Id = supp.Id;
                obj.Description = tbdescription.Text;
                obj.Grandeur = tbGrandeur.Text;
                obj.ProductNumber= tbProductNumber.Text;
                obj.Quantite = Convert.ToInt32(tbQuantite.Text);
                obj.Prix = Convert.ToDouble(tbPrix.Text);
                obj.IntroductionDate = dtIntroduction.Text;
                obj.DiscontinuationDate = dtDiscontinuation.Text;

                var res = DALClass.AddBikePart(obj);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                }
                //Resetting Ui Controls
                tbdescription.Text = "";
                tbProductNumber.Text = "";
                tbGrandeur.Text = "";
                tbPrix.Text = "";
            }
        }

        private void Update_Row(object sender, RoutedEventArgs e)
        {
            if (dgBikePart.SelectedItem != null)
            {
                var obj = dgBikePart.SelectedItem as Part;
                var res = DALClass.UpdateBikePart(obj);
                if (res)
                {
                    MessageBox.Show("Enregistré");
                    UpdateGUI();
                }
            }
        }

        private void Delete_Row(object sender, RoutedEventArgs e)
        {
            if (dgBikePart.SelectedItem != null)
            {
                var obj = dgBikePart.SelectedItem as Part;
                var res = DALClass.DeleteBikePart(obj.Id);
                if (res)
                {
                    MessageBox.Show("Enregistre");
                    UpdateGUI();
                }
            }
        }
    }
}
