using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenerationNet.dao
{
    //Classe qui représente la bdd
    class BDD
    {
        private static BDD _instance;
        private OracleConnection _bdd;

        private BDD()
        {
            
            string chainecnx = "DATA SOURCE=172.30.11.12:1521/orcl; PASSWORD = generationnet ;PERSIST SECURITY INFO=True;USER ID=GENERATIONNET";
            _bdd = new OracleConnection();
            this._bdd.ConnectionString = chainecnx;
            //création de la connexion à la BDD oracle             
            this._bdd.ConnectionString = chainecnx;
            this._bdd.Open();
        }


        public OracleDataReader getPrepareCommand(String command, Dictionary<string, object> parametre)
        {
            OracleCommand cmd = this._bdd.CreateCommand();
            cmd.CommandText = command;
            
            foreach (string x in parametre.Keys)
            {
                cmd.Parameters.Add(new OracleParameter(x, parametre[x]));
            }
            return cmd.ExecuteReader();
        }



        public static BDD getInstance()
        {
            if (_instance == null)
            {
                _instance = new BDD();
            }

            return _instance;
        }
    }
}