// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var rectangle = GetRectangle(10);

Console.WriteLine(rectangle.GetArea());

// Bir base class bir de derived class olsun. Derived'ın davranışı, Base'in davranışlarını değiştiremez!!!
// Bir base class ile derived class ekstra işlem yapmaksızın birbirlerinin yerine kullanılabilir olmalıdır.


static IGeometry GetRectangle(int width, int? height=1)
{
    //Kare döndürüyor..
    if (height != 1)
    {
        return new Rectangle(width, height.Value);
    }

    return new Square(width);
}


public interface IGeometry
{
    int GetArea();
}

public class Rectangle : IGeometry
{
    public  int Width { get; set; }
    public  int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int GetArea()
    {
        return Width * Height;
    }


}

public class Square : IGeometry
{

    public  int Width { get; set; }

    public Square(int width)
    {
        Width = width;
    }

    public int GetArea()
    {
        return (int)Math.Pow(Width, 2);
    }
}