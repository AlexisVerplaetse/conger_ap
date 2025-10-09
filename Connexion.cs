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

                    string query = "SELECT COUNT(*) FROM utilisateur WHERE nom = @nom AND mdp = @mdp";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", user);
                        cmd.Parameters.AddWithValue("@mdp", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Connexion réussie !");
                            // Exemple : ouvrir une nouvelle fenêtre et cacher la fenêtre de login
                            // new MenuPrincipal().Show();
                            // this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Identifiant ou mot de passe incorrect.");
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
