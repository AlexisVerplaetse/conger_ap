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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private BDD BaseDonne;

        private void Form1_Load(object sender, EventArgs e)
        {
            BaseDonne = new BDD("localhost", "apcs", "root", "");
            BaseDonne.Ouvrir();
        }
    }
}
