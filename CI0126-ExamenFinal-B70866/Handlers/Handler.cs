using System.Configuration;
using System.Data.SqlClient;
using SqlKata.Execution;
using SqlKata.Compilers;

namespace CI0126_ExamenFinal_B70866.Handlers
{
    public abstract class Handler
    {
        protected SqlConnection connection;
        private string connectionUrl;
        protected QueryFactory db;

        public Handler()
        {
            connectionUrl = ConfigurationManager.ConnectionStrings["ExamenConnection"].ToString();
            connection = new SqlConnection(connectionUrl);
            db = new QueryFactory(connection, new SqlServerCompiler());
        }
    }
}