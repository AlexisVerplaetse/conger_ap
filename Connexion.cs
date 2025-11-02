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

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez saisir un nom d'utilisateur et un mot de passe.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;database=apcs;uid=root;pwd=;"))
                {
                    conn.Open();
                    // Remplacez "id" par le nom exact de votre colonne ID (ex: id_utilisateur)
                    string query = "SELECT id FROM utilisateur WHERE nom = @nom AND mdp = @mdp";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", user);
                        cmd.Parameters.AddWithValue("@mdp", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Connexion réussie, on récupère l'ID
                                int praticienId = reader.GetInt32("id");

                                MessageBox.Show("Connexion réussie !");

                                // 3. ICI : On ouvre le nouveau formulaire en lui passant l'ID
                                demande_conge formDemande = new demande_conge(praticienId);
                                formDemande.Show(); // Affiche le formulaire de demande de congé

                                this.Hide(); // Cache le formulaire de connexion
                            }
                            else
                            {
                                MessageBox.Show("Identifiant ou mot de passe incorrect.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la connexion : " + ex.Message);
            }
        }
    }

}
