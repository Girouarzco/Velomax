using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloMax.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.IO;

namespace VeloMax.DAL
{
    public static class DALClass
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        static MySqlConnection connexion = new MySqlConnection(connectionString);
        static MySqlCommand cmd;
        public static bool AddBike(Velos bike)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Insert into Velos (ModeleNum,Nom,Grandeur,Ligne,Prix,dateentree,datefin,Quantite) Values('" + bike.ModeleNum + "','" + bike.Nom + "','" + bike.Grandeur + "'," + "'" + bike.Ligne + "','" + bike.Prix + "','" + bike.dateentree + "','" + bike.datefin + "','" + bike.Quantite + "')";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static List<Velos> GetAllBikes()
        {
            List<Velos> bikes = new List<Velos>();
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                cmd = new MySqlCommand("SELECT * FROM Velos", connexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Velos bike = new Velos();
                    bike.Id = (int)reader["Id"];
                    bike.Nom = reader["Nom"].ToString();
                    bike.ModeleNum = reader["ModeleNum"].ToString();
                    bike.Grandeur = reader["Grandeur"].ToString();
                    bike.Ligne = reader["Ligne"].ToString();
                    bike.Prix = (double)reader["Prix"];
                    bike.dateentree = reader["dateentree"].ToString();
                    bike.datefin = reader["datefin"].ToString();
                    bike.Quantite = Convert.ToInt32(reader["Quantite"]);
                    bikes.Add(bike);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }

            return bikes;
        }
        public static bool UpdateBike(Velos bike)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Update Velos set ModeleNum = '" + bike.ModeleNum + "', Nom = '" + bike.Nom + "', Grandeur = '" + bike.Grandeur + "'," +
                    " Ligne ='" + bike.Ligne + "' ,Prix= '" + bike.Prix + "' Where Id = '" + bike.Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static bool DeleteBike(int Id)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Delete From Velos Where Id = '" + Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }

        public static bool AddBikePart(Part bikePart)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Insert into Piece (ProductNumber,Description,Fournisseur,FournisseurId,Grandeur,Prix,dateentree,datefin,Quantite) Values('" + bikePart.ProductNumber + "','" + bikePart.Description + "','" + bikePart.Fournisseur + "'," + "'" + bikePart.FournisseurId + "','" + bikePart.Grandeur + "','" + bikePart.Prix + "','" + bikePart.IntroductionDate + "','" + bikePart.DiscontinuationDate + "','" + bikePart.Quantite + "')";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static List<Part> GetAllBikeparts()
        {
            List<Part> list = new List<Part>();
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                cmd = new MySqlCommand("SELECT * FROM Piece", connexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Part obj = new Part();
                    obj.Id = (int)reader["Id"];
                    obj.Description = reader["Description"].ToString();
                    obj.Fournisseur = reader["Fournisseur"].ToString();
                    obj.FournisseurId = (int)reader["FournisseurId"];
                    obj.ProductNumber = reader["ProductNumber"].ToString();
                    obj.Grandeur = reader["Grandeur"].ToString();
                    obj.Prix = (double)reader["Prix"];
                    obj.IntroductionDate = reader["dateentree"].ToString();
                    obj.DiscontinuationDate = reader["datefin"].ToString();
                    obj.Quantite = (int)reader["Quantite"];
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }

            return list;
        }
        public static bool UpdateBikePart(Part obj)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Update Piece set ProductNumber = '" + obj.Grandeur + "', Description = '" + obj.Description + "', Grandeur = '" + obj.Grandeur + "'," +
                    " Prix= '" + obj.Prix + "' Where Id = '" + obj.Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static bool DeleteBikePart(int Id)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Delete From Piece Where Id = '" + Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }

        public static bool AddFournisseur(Fournisseur obj)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Insert into fournisseur (Siret,CompanyNom,Contact,Address,Qualifiant) Values('" + obj.Siret + "','" + obj.CompanyNom + "','" + obj.Contact + "'," + "'" + obj.Address + "','" + obj.Qualifiant + "')";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static List<Fournisseur> GetAllfournisseur()
        {
            List<Fournisseur> list = new List<Fournisseur>();
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                cmd = new MySqlCommand("SELECT * FROM fournisseur", connexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Fournisseur obj = new Fournisseur();
                    obj.Id = (int)reader["Id"];
                    obj.Siret = reader["Siret"].ToString();
                    obj.CompanyNom = reader["CompanyNom"].ToString();
                    obj.Contact = reader["Contact"].ToString();
                    obj.Address = reader["Address"].ToString();
                    obj.Qualifiant = (int)reader["Qualifiant"];
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }

            return list;
        }
        public static bool Updatefournisseur(Fournisseur obj)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Update fournisseur set Siret = '" + obj.Siret + "', CompanyNom = '" + obj.CompanyNom + "', Contact = '" + obj.Contact + "'," +
                    " Address= '" + obj.Address + "' Where Id = '" + obj.Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static bool Deletefournisseur(int Id)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Delete From fournisseur Where Id = '" + Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }


        public static bool AddStore(Client obj)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Insert into Client (Email,CompanyNom,Contact,Address,ContactPersonne,Discount,Fidelio,Type) Values('" + obj.Email + "','" + obj.CompanyNom + "','" + obj.Contact + "'," + "'" + obj.Address + "','" + obj.ContactPersonne + "','" + obj.Discount + "','" + obj.Fidelio + "','" + obj.Type + "')";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static List<Client> GetAllStores()
        {
            List<Client> list = new List<Client>();
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                cmd = new MySqlCommand("SELECT * FROM Client", connexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Client obj = new Client();
                    obj.Id = (int)reader["Id"];
                    obj.Email = reader["Email"].ToString();
                    obj.CompanyNom = reader["CompanyNom"].ToString();
                    obj.Contact = reader["Contact"].ToString();
                    obj.Address = reader["Address"].ToString();
                    obj.Discount = reader["Discount"].ToString();
                    obj.ContactPersonne = reader["ContactPersonne"].ToString();
                    obj.Type = reader["Type"].ToString();
                    obj.Fidelio = reader["Fidelio"].ToString();
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }

            return list;
        }
        public static bool UpdateStore(Client obj)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Update Client set Email = '" + obj.Email + "', CompanyNom = '" + obj.CompanyNom + "', Contact = '" + obj.Contact + "'," +
                    " Address= '" + obj.Address + "' Where Id = '" + obj.Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static bool DeleteStore(int Id)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Delete From Client Where Id = '" + Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static int GetTotalClients()
        {
            int clients = 0;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                cmd = new MySqlCommand("SELECT Count(*) FROM Client", connexion);
                clients = int.Parse(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
            return clients;
        }


        public static bool PlaceOrder(ClientOrders obj)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Insert into clientorders (ClientNom,ClientId,Nom,ProductId,Type,Total,DeliveryTime,Quantite) Values('" + obj.ClientNom + "','" + obj.ClientId + "','" + obj.Nom + "'," + "'" + obj.ProductId + "','" + obj.Type + "','" + obj.Total + "','" + obj.DeliveryTime + "','" + obj.Quantite + "')";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static List<ClientOrders> GetAllOrders()
        {
            List<ClientOrders> list = new List<ClientOrders>();
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                cmd = new MySqlCommand("SELECT * FROM ClientOrders", connexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClientOrders obj = new ClientOrders();
                    obj.Id = (int)reader["Id"];
                    obj.ClientId = (int)reader["ClientId"];
                    obj.ClientNom = reader["ClientNom"].ToString();
                    obj.DeliveryTime = reader["DeliveryTime"].ToString();
                    obj.Nom = reader["Nom"].ToString();
                    obj.ProductId = (int)reader["ProductId"];
                    obj.Quantite = (int)reader["Quantite"];
                    obj.Total = (double)reader["Total"];
                    obj.Type = reader["Type"].ToString();
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }

            return list;
        }
        public static bool UpdateOrder(ClientOrders obj)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Update ClientOrders set Quantite = '" + obj.Quantite + "', Total = '" + obj.Total + "', Type = '" + obj.Type + "' Where Id = '" + obj.Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }
        public static bool DeleteOrder(int Id)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "Delete From ClientOrders Where Id = '" + Id + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }

        public static bool UpdateStock(int ProductId, string Type, int quan)
        {
            bool flag = false;
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                string sql = "";
                if (Type == "Vélos")
                    sql = "Update Velos set Quantite = '" + quan + "' Where Id = '" + ProductId + "'";
                else if (Type == "Pièce")
                    sql = "Update Piece set Quantite = '" + quan + "' Where Id = '" + ProductId + "'";

                cmd = new MySqlCommand(sql, connexion);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                connexion.Close();
            }

            return flag;
        }

        public static void ExportLowStock()
        {
            try
            {
                if (connexion.State != ConnectionState.Open)
                    connexion.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT Id,Nom,Quantite FROM Velos where Quantite <= 2 UNION Select Id,Description As Nom,Quantite FROM Piece where Quantite <= 2", connexion);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                string json = JsonConvert.SerializeObject(dt, new Newtonsoft.Json.Formatting());
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "json";
                sfd.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                sfd.ShowDialog();

                if(!string.IsNullOrEmpty(sfd.FileName))
                {
                    File.WriteAllText(sfd.FileName, json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }
    }
}
