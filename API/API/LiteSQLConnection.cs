using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    static public class LiteSQLConnection
    {
        static public SqlConnection getSQLConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-R75QLBQV\SQL;Initial Catalog=BDNeuralNetworks;Integrated Security=True");
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
