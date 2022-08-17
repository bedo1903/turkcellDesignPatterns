// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Problem:
 * Karmaşık adımlardan oluşan bir iş var. İstemciye bu karmaşayı hiç yansıtmadan basit bir biçimde nasıl yaptırabiliriz?
 * 
 * 
 * Senaryo:
 * Bir sipariş işlemi için
 *   1. Yeni sipariş eklenecek.
 *   2. Her ürün sipariş detay olarak detay tablosuna eklenecek.
 *   3. Her bir ürünün stoğu ürün tablosunda güncellenecek
 *   
 */

Customer Customer = new Customer() { Name="Türkay"};
List<Product> products = new List<Product>
{
    new Product{ Name="Tişört", Quantity=2},
    new Product{ Name="şort", Quantity=1},

};

OrderFacade orderFacade = new OrderFacade();
orderFacade.CreateOrder(Customer, products);


public class OrderFacade
{
    OrderService orderService = new OrderService();
    OrderDetailService orderDetailService = new OrderDetailService();
    ProductService productService = new ProductService();

    public void CreateOrder(Customer customer, List<Product> products)
    {
        int orderId = orderService.AddOrder(customer,DateTime.Now);
        orderDetailService.AddOrderDetail(orderId,products);
        productService.UpdateStock(products);

    }

}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class OrderService
{

    public int AddOrder(Customer customer, DateTime dateTime)
    {
        dateTime = DateTime.Now;
        Console.WriteLine($"{dateTime} tarihinde, {customer.Name} isimli müşteri sipariş verdi");
        return 3;

    }
}
public class OrderDetailService
{
    public void AddOrderDetail(int orderID, List<Product> products)
    {
        Console.WriteLine($"{orderID} numaralı siparişte:");
        products.ForEach(p => Console.WriteLine($"{p.Name} isimli üründen {p.Quantity} adet alındı"));

    }
}

public class ProductService
{
    public void UpdateStock(List<Product> products)
    {
        products.ForEach(p => Console.WriteLine($"{p.Name} isimli ürünün stoğundan {p.Quantity} adet düşüldü.... "));
    }
}
