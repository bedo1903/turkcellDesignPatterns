using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleRepository
{
    public class ProductService
    {
        public int AddProduct(string name, decimal price)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");
            SqlCommand command = new SqlCommand("INSERT into Products (ProductName,UnitPrice) values (@name,@price)", connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@price", price);

            connection.Open();
            var affectedRows = command.ExecuteNonQuery();
            connection.Close();

            return affectedRows;

        }
    }
}
