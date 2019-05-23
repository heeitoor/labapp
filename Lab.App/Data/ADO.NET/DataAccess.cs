using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.App.Data
{
    class DataAccess : IDataAccess, IDisposable
    {
        public List<T> Query<T>(string query, Func<DataRow, T> mapping)
        {
            DataTable dataTable = Query(query);
            return dataTable.Rows.Cast<DataRow>().Select(mapping).ToList();
        }

        public DataTable Query(string query)
        {
            DataTable dataTable = null;

            using (SqlCommand command = new SqlCommand(query, GetConnection()))
            {
                dataTable = new DataTable();
                dataTable.Load(GetReader(command));
            }

            return dataTable;
        }

        private SqlDataReader GetReader(SqlCommand command)
        {
            return command.ExecuteReader();
        }

        private SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
        }

        public int Execute(string query)
        {
            using (SqlCommand command = new SqlCommand(query, GetConnection()))
            {
                return command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {

        }
    }
}
