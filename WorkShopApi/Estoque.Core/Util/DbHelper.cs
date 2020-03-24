using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Estoque.Core.Util
{
    public sealed class DbHelper : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbHelper()
        {
            Connection = new MySqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            GC.SuppressFinalize(this);
        }
    }
}
