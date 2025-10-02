using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace demande_conge
{
    public class BDD
    {
        private MySqlConnection connexion;

        public BDD(string serveur, string bdd, string user, string MDP, string port = "3306")
        {
            string chaine = $"server={serveur};Database={bdd};port={port};uid={user};pwd={MDP}";
            connexion = new MySqlConnection(chaine);
        }
        public void Ouvrir() => connexion.Open();
        public void Fermer() => connexion.Close();

        public MySqlConnection Connexion => connexion;

        

        
    }
    
}
