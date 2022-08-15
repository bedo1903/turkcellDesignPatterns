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
            var connecttionString = @"Data Source=(localdb)\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True";
            var commandText = "INSERT into Products (ProductName,UnitPrice) values (@name,@price)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@price", price);


            var affectedRows = new DbHelper(connecttionString).Execute(commandText, parameters);

            return affectedRows;

        }
    }
}
