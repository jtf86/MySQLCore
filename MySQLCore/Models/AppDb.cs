using System;
using MySql.Data.MySqlClient;
using MySQLCore;

namespace MySqlCore.Models
{
    public class AppDb : IDisposable
    {

        public MySqlConnection conn;

        public AppDb()
        {
            conn = new MySqlConnection(DBConfiguration.ConnectionString);
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
