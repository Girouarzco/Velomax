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
    /// Interaction logic for Gestionvelos.xaml
    /// </summary>
    public partial class Gestionvelos : Window
    {
        ObservableCollection<Velos> Bikes = new ObservableCollection<Velos>();
        public Gestionvelos()
        {
            InitializeComponent();
            //Update Grid UI
            UpdateGUI();
        }
        void UpdateGUI()
        {
            Bikes = new ObservableCollection<Velos>(DALClass.GetAllBikes());
            dgBike.ItemsSource = Bikes;
        }
        private void AddBike_Click(object sender, RoutedEventArgs e)
        {
            if (tbNom.Text == "" || tbPrix.Text == "" || tbnumeromodel.Text == "" || cmbGrandeur.SelectedItem == null
                || cmbligneproduit.SelectedItem == null || tbQuantite.Text == "")
            {
                MessageBox.Show("Veuillez renseigner tous les champs!");
                tbNom.Focus();
            }
            else
            {
                Velos bike = new Velos();
                bike.Grandeur = cmbGrandeur.SelectionBoxItem.ToString();
                bike.Ligne = cmbligneproduit.SelectionBoxItem.ToString();
                bike.Nom = tbNom.Text;
                bike.ModeleNum = tbnumeromodel.Text;
                bike.Prix = Convert.ToDouble(tbPrix.Text);
                bike.Quantite = Convert.ToInt32(tbQuantite.Text);
                bike.dateentree = dtentree.Text;
                bike.datefin = dtfin.Text;

                var res = DALClass.AddBike(bike);
                if (res)
                {
                    MessageBox.Show("Vélo enregistré");
                    UpdateGUI();
                }
                //Resetting Ui Controls
                tbnumeromodel.Text = "";
                tbNom.Text = "";
                tbPrix.Text = "";
            }
        }

        private void Update_Row(object sender, RoutedEventArgs e)
        {
            if (dgBike.SelectedItem != null)
            {
                var bike = dgBike.SelectedItem as Velos;
                var res = DALClass.UpdateBike(bike);
                if (res)
                {
                    MessageBox.Show("Vélo bien modifié");
                    UpdateGUI();
                }
            }
        }

        private void Delete_Row(object sender, RoutedEventArgs e)
        {
            if (dgBike.SelectedItem != null)
            {
                var bike = dgBike.SelectedItem as Velos;
                var res = DALClass.DeleteBike(bike.Id);
                if (res)
                {
                    MessageBox.Show("Vélo bien supprimé");
                    UpdateGUI();
                }
            }
        }
    }
}
