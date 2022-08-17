// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Renk siyah = new Renk();
Renk kirmizi = (Renk)siyah.Clone();
kirmizi.R = 255;
Renk yesil = (Renk)kirmizi.Clone();
Console.WriteLine(yesil.R);

string[] foods = new string[] { "Bezelye", "Fasülye", "Pilav" };
string test = "neyaptın";

public class Renk : ICloneable
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Renk()
    {
        //varsayın ki bu iş uzun sürüyor:
        R = 0;
        B = 0;
        G = 0;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}


public class Weapon
{

}

public class Armor
{

}

public class Enemy : ICloneable
{
    public Weapon Weapon { get; set; }
    public Armor Armor { get; set; }
    public object Clone()
    {
        throw new NotImplementedException();
    }

    public object Clone(bool isDeep)
    {
        if (isDeep)
        {
            //Serialize to memory and return deserialize.

        }
        return Clone();

    }
}