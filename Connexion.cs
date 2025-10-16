using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace demande_conge
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }
        public BDD BaseDonne { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaseDonne = new BDD("localhost", "apcs", "root", "");
            BaseDonne.Ouvrir();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connexion_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;database=apcs;uid=root;pwd=;"))
                {
                    conn.Open();

                    // On récupère toutes les infos nécessaires
                    string query = "SELECT id_role FROM compte_praticien WHERE login = @login AND mdp = @mdp";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", user);
                        cmd.Parameters.AddWithValue("@mdp", password);

                        object result = cmd.ExecuteScalar(); // renvoie la valeur de id_role ou null

                        if (result != null)
                        {
                            int role = Convert.ToInt32(result); // on récupère le rôle

                            if (role == 2)
                            {
                                // Redirection vers le formulaire "demande_conge"
                                demande_conge client = new demande_conge();
                                client.Show();
                                this.Hide();
                            }
                            else if (role == 1)
                            {
                                // Exemple : redirection vers un autre formulaire pour l'admin
                                Admin Rh = new Admin();
                                Rh.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Rôle inconnu !");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login ou mot de passe incorrect.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }

        }

        }

    }
