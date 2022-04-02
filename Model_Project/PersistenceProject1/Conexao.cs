using System.Configuration;
using System.Data.SqlClient;
using ModelProject1;

namespace PersistenceProject1
{
    public class Conexao
    {
        public Conexao(string txtNome, string txtcnpj)
        {
           
        }

        public string TxtNome { get; }

        public void conexao()
        {
           
            command.Parameters.AddWithValue("@nome", txtNome.Text);
            command.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
            command.ExecuteNonQuery();
            Connection.Close();
        }

    }
}
}
