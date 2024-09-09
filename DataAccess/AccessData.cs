using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace DataAccess
{
    public class AccessData
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public AccessData() 
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            command = new SqlCommand();
        }

        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void executeReader()
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public void closeConnection()
        {
            if (reader != null) 
                reader.Close();
            
            connection.Close();
        }
    }
}
