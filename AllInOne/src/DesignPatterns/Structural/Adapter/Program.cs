// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 *  Problem;
 *     Birden fazla kaynak belirli standartta veri akışı oluşturmanız gerekmekte, veriyi kullanan nesnenin sağlayıcıdan agnostik olarak tasarlanmasını nasıl sağlarsınız?
 *     
 *  Senaryo:
 *    Bir veri kaynağından veri okuyarak; kullanıcıya göstereceksiniz. Veri kaynağınız XML de olabilir DB de. O halde veriyi düzenleyecek bir adaptöre ihtiyacınız olacak!
   
 *     
 */

DataParser dataParser = new DataParser();
dataParser.GetProducts(new DBProvider()).ForEach(p => Console.WriteLine(p.FromProvider));
dataParser.GetProducts(new XMLProvider()).ForEach(p => Console.WriteLine(p.FromProvider));



public class Product 
{
    public string FromProvider { get; set; }
}

public class DataParser
{
    //public IProductsDataAdapter DataAdapter { get; set; } = new DBProvider();
    public List<Product> GetProducts(IProductsDataAdapter dataAdapter) 
    {
       return dataAdapter.GetProductsFromProvider();
    }
}

public interface IProductsDataAdapter
{
    List<Product> GetProductsFromProvider();
}
public class XMLProvider : IProductsDataAdapter
{
    public List<Product> GetProductsFromProvider()
    {
        //bu metod, bir XML dosyasından ürünleri okur ve List<Urun>'e dönüştürür
        return new List<Product> { new Product { FromProvider = "XML'den getirildi..." } };
    }
}

public class DBProvider : IProductsDataAdapter
{
    public List<Product> GetProductsFromProvider()
    {
        return new List<Product> { new Product { FromProvider = "DB'den getirildi..." } };
    }
}