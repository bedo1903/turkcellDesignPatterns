/*
 * Problem:
 * Bir nesne, instance'i alındığı anda; başka nesneleri de barındırmak zorunda... Ayrıca bu nesneyi oluşturan sınıftan miras alan mirasçılarınız da var. Her bir nesnenin, barındırdırdığı nesneleri kolayca üretmem nasıl mümkün olabilir?
 */

/*
 * Senaryo:
 * Bir harita uygulaması yapıyorsunuz.
 *  Turist; İstanbul haritasında ziyaret etmek istediği kategoriyi seçer.
 *  A. Eğlence
 *      - Bar, Cafe, Pub
 *  B. Kültür
 *      - Sinema, Sergi vs...
 *  C. İnanç
 *      - İbathane, Mezarlık vs...
 *      
 *      
 */
CultureMap cultureMap = new CultureMap();
ReligionMap religionMap = new ReligionMap();

showVisitPoint(cultureMap);
Console.WriteLine("-----------------");
showVisitPoint(religionMap);


Console.ReadLine();



static void showVisitPoint(MapBase mapBase)
{
    foreach (var item in mapBase.VisitPoints)
    {
        Console.WriteLine($"{item.GetType().Name} objesinin değeri: {item.Icon}");
    }
}








public interface IRecomendedVisitPoint
{
    double Latitude { get; set; }
    double Longitude { get; set; }
    string Icon { get; set; }
    string API { get; set; }
}


public interface ICulturalRecomendedVisitPoint : IRecomendedVisitPoint
{
    public bool IsAvailable { get; set; }
}

public class Museum : ICulturalRecomendedVisitPoint
{
    public bool IsAvailable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string API { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Exhibition : ICulturalRecomendedVisitPoint
{
    public bool IsAvailable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string API { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Mosquee : IRecomendedVisitPoint
{
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string API { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Tomb : IRecomendedVisitPoint
{
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string API { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Bar : IRecomendedVisitPoint
{
    public double Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Icon { get; set; }
    public string API { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}


public abstract class MapBase
{
    public List<IRecomendedVisitPoint> VisitPoints { get; set; }
    public MapBase()
    {
        VisitPoints = new List<IRecomendedVisitPoint>();
        addToVisitPoints();
    }

    protected abstract void addToVisitPoints();


}

public class CultureMap : MapBase
{
    protected override void addToVisitPoints()
    {
        VisitPoints.Add(new Museum { Icon = "Topkapı Sarayı" });
        VisitPoints.Add(new Museum { Icon = "Yerebatan Sarnıcı" });
        VisitPoints.Add(new Exhibition { Icon = "Turkcell Odakule Fotoğraf sergisi" });

    }

}

public class ReligionMap : MapBase
{
    protected override void addToVisitPoints()
    {
        VisitPoints.Add(new Mosquee { Icon = "Ayasofya Camii" });
        VisitPoints.Add(new Mosquee { Icon = "Sultanahmet Camii" });
        VisitPoints.Add(new Tomb { Icon = "Ayrılık çeşmesi mezarlığı" });

    }
}

