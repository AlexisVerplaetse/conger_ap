using MySql.Data.MySqlClient;

namespace demande_conge
{
    public partial class demande_conge : Form
    {
        // 1. Propriété pour stocker l'ID de l'utilisateur connecté
        public int IdUtilisateur { get; private set; }

        // Constructeur par défaut (gardez-le pour le concepteur de formulaires)
        public demande_conge()
        {
            InitializeComponent();
        }

        // 2. Nouveau constructeur qui accepte l'ID de l'utilisateur
        public demande_conge(int idUtilisateur)
        {
            InitializeComponent();
            // On stocke l'ID reçu dans notre propriété
            this.IdUtilisateur = idUtilisateur;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime datedebut = dateTimePicker1.Value;
            DateTime datefin = dateTimePicker2.Value;

            // On vérifie que la date de fin n'est pas antérieure à la date de début
            if (datefin < datedebut)
            {
                MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.");
                return;
            }

            //On compte le nombre de jours entre les deux dates
            TimeSpan difference = datefin - datedebut;

            // On prend le nombre total de jours de cette durée et on ajoute 1
            // (pour inclure le premier et le dernier jour dans le décompte)
            // Exemple : 11/11 - 10/11 = 1 jour. On fait +1 = 2 jours (le 10 et le 11).
            int nombreJours = difference.Days + 1;

            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;database=apcs;uid=root;pwd=;"))
                {
                    conn.Open();
                    //la deuxieme requete met à jour le nombre de jours de congés restants
                    string query = "INSERT INTO demande_congees (id_praticien, date_debut, date_fin, statut) VALUES (@id_praticien, @date_debut, @date_fin, @statut);" +
                        "UPDATE praticien SET nb_jour_congees_restant = nb_jour_congees_restant - @nombre_jours WHERE id = @id_praticien;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // On utilise la propriété IdUtilisateur qui a été définie à l'ouverture du formulaire
                        cmd.Parameters.AddWithValue("@id_praticien", this.IdUtilisateur);
                        cmd.Parameters.AddWithValue("@date_debut", datedebut);
                        cmd.Parameters.AddWithValue("@date_fin", datefin);
                        cmd.Parameters.AddWithValue("@statut", "en cours");
                        cmd.Parameters.AddWithValue("@nombre_jours", nombreJours); // On insère le nombre de jours calculé

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Votre demande de congé a été envoyée avec succès !");
                        }
                        else
                        {
                            MessageBox.Show("L'envoi de la demande a échoué.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;database=apcs;uid=root;pwd=;"))
                {
                    conn.Open();

                    string query = "SELECT nb_jours_conges_restant FROM praticien WHERE id = @id_praticien";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_praticien", this.IdUtilisateur);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int nbJoursRestants = reader.GetInt32("nb_jours_conges_restant");
                                textBox1.Text = nbJoursRestants.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Impossible de récupérer les jours de congé restants.");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

        // ... (le reste de votre code : label1_Click, etc.)
    }
}