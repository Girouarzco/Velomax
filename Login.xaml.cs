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
using System.Windows.Shapes;

namespace VeloMax
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbUserName.Text) && !string.IsNullOrEmpty(pass.Password))
            {
                if (tbUserName.Text.ToLower() == "admin" && pass.Password == "123")
                {
                    MainWindow wind = new MainWindow();
                    wind.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("les informations d'identification invalides");                
            }
        }
    }
}
