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
    public partial class demande_conge : Form
    {
        public demande_conge()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime datedebut = dateTimePicker1.Value;
            DateTime datefin = dateTimePicker2.Value;

            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;database=apcs;uid=root;pwd=;"))
                {
                    conn.Open();

                    string query = $"INSERT INTO demande_congees (id_praticien, date_debut, date_fin) VALUES ({idutilisateur},{datedebut},{datefin},en cours);";
                }
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
