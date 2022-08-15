using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleRepository
{
    public class DbHelper
    {
        SqlConnection sqlConnection = null;
        public DbHelper(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public int Execute(string commandText, Dictionary<string,object> parameters)
        {
            SqlCommand sqlCommand = createCommand(commandText, parameters);
            sqlCommand.Connection.Open();
            var result = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();

            return result;
        }

        private SqlCommand createCommand(string commandText, Dictionary<string, object> parameters)
        {
            var command = sqlConnection.CreateCommand();
            command.CommandText = commandText;
            AddParametersToCommand(command, parameters);
            return command;
        }

        private void AddParametersToCommand(SqlCommand command, Dictionary<string, object> parameters)
        {
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

        }
    }
}
