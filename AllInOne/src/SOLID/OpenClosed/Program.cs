// See https://aka.ms/new-console-template for more information
Customer customer = new Customer { Name = "Türkay", Card = new PremiumCard() };
OrderManager orderManager = new OrderManager { Customer = customer };
var discountedPrice = orderManager.GetTotalPrice(100);
Console.WriteLine(discountedPrice);

/*
 * Bir nesne, gelişime AÇIK değişime KAPALI olmalıdır.
 *
 */

public interface ICardType
{
    public double DiscountedPrice(double price);
}
public class SilverCard : ICardType
{
    public double DiscountedPrice(double price)
    {
        return price * .9;
    }
}

public class StandartCard : ICardType
{
    public double DiscountedPrice(double price)
    {
        return price * .95;
    }
}

public class GoldCard : ICardType
{
    public double DiscountedPrice(double price)
    {
        return price * .85;
    }
}

public class PremiumCard : ICardType
{
    public double DiscountedPrice(double price)
    {
        return price * .8;
    }
}
public class Customer
{
    public ICardType Card { get; set; }
    public string Name { get; set; }
}

public class OrderManager
{
    public Customer Customer { get; set; }
    public double GetTotalPrice(double totalPrice)
    {

        return Customer.Card.DiscountedPrice(totalPrice);

    }
}

