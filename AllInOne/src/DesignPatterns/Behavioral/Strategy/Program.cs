// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * Sorun:
 *   Halihazırda bellekte bulunan bir nesnenin, bir işi yapma biçimini (algoritmasını) değiştirmek istiyorsunuz. Bunu nasıl yaparsınız?
 *   
 */

ProductCollection productCollection = new ProductCollection();
productCollection.Products(new BubbleSort());
productCollection.Products(new HeapSort());
public class ProductCollection
{
    private List<object> products = new List<object>();
    public List<object> Products(ISortStrategy sortStrategy)
    {
        //Bubblesort....
        return sortStrategy.Sort();

    }
}

public interface ISortStrategy
{
    List<object> Sort();
}

public class BubbleSort : ISortStrategy
{
    public List<object> Sort()
    {
        Console.WriteLine("Bubble sort ile sıralanıyor...");
        return null;
    }
}

public class HeapSort : ISortStrategy
{
    public List<object> Sort()
    {
        Console.WriteLine("Heap sort ile sıralanıyor...");
        return null;
    }
}