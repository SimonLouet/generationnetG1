using GenerationNet.dao;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generationnet2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            BDD bdd = BDD.getInstance();
            string message = "SELECT Client: \n";
            OracleDataReader test = bdd.getPrepareCommand("Select * FROM Client", new Dictionary<string, object>());

            
            while (test.Read())
            {
                int id = test.GetInt32(test.GetOrdinal("CLI_ID"));
                string prenom = (String)test["CLI_PRENOM"];
                string nom = (String)test["CLI_NOM"];
                message += "id : " + id + "  prenom : " + prenom + "   nom : " + nom + "\n";
            }
            label1.Text = message;
        }
    }
}
