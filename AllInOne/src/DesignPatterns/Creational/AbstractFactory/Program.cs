/*
 * Problem:
 * 
 * Bir nesne ürettiğinizde; yeni üretilen nesnenin de başka nesneleri üretecekse; Abstract Factory kullanılabilir.
 * 
 *  Örnek:
 *     Hepsiemlak, Sahibinden ve Zingat.com'dan emlak analizi yapmak istiyorsunuz. Bir crawler (web'den data çeken sistemler)'a ihtiyacınız var. Parametre olarak site adını vereceksiniz (Zingat) size o siteden veri çekecek olan crawler'i üretecek. 
 *     Dikkat!!!
 *       Zingat arayüzünü değiştirirse, yeni bir crawler objesi oluşmalı....
 *     Demek ki crawler oluşturacak fabrikayı oluşturan bir fabrikaya ihtiyacınız var.  
 *     
 *     
 *  Senaryo:
 *  
 *  Turistler için yaptığınız haritada yeni bir özellik istiyorsunuz: Haritayı, uydu görseli ya da sokak görünümü ile göstermek...
 */
Map<SatelliteFunMap> map1 = new Map<SatelliteFunMap>();
map1.Show();
Console.WriteLine("---------------");
Map<RegionalReligionMap> map2 = new Map<RegionalReligionMap>();
map2.Show();



#region Harita Ayarları




public interface IRecomendedVisitPoint
{
    double Latitude { get; set; }
    double Longitude { get; set; }
    string Icon { get; set; }
    string API { get; set; }
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

public class ReligionMap : MapBase
{
    protected override void addToVisitPoints()
    {
        VisitPoints.Add(new Mosquee { Icon = "Ayasofya Camii" });
        VisitPoints.Add(new Mosquee { Icon = "Sultanahmet Camii" });
        VisitPoints.Add(new Tomb { Icon = "Ayrılık çeşmesi mezarlığı" });

    }
}

public class FunMap : MapBase
{
    protected override void addToVisitPoints()
    {
        VisitPoints.Add(new Bar { Icon = "Rock Bar" });
        VisitPoints.Add(new Bar { Icon = "Jazz Bar" });
        VisitPoints.Add(new Bar { Icon = "Kokteyl Bar" });
    }
}

#endregion
public interface IMapCreator
{
    List<IRecomendedVisitPoint> GetrecomendedVisitPoints();
    MapBase mapFormat();
}

public class SatelliteReligionMap : IMapCreator
{
    private ReligionMap religionMap = new ReligionMap();
    public List<IRecomendedVisitPoint> GetrecomendedVisitPoints()
    {
        return religionMap.VisitPoints;
    }

    public MapBase mapFormat()
    {
        return religionMap;
    }
}

public class RegionalReligionMap : IMapCreator
{
    private ReligionMap religionMap = new ReligionMap();
    public List<IRecomendedVisitPoint> GetrecomendedVisitPoints()
    {
        return religionMap.VisitPoints;
    }

    public MapBase mapFormat()
    {
        return religionMap;
    }
}

public class SatelliteFunMap : IMapCreator
{
    private FunMap funMap = new FunMap();
    public List<IRecomendedVisitPoint> GetrecomendedVisitPoints()
    {
        return funMap.VisitPoints;
    }

    public MapBase mapFormat()
    {
        return funMap;
    }
}

public class RegionalFunMap : IMapCreator
{
    private FunMap funMap = new FunMap();
    public List<IRecomendedVisitPoint> GetrecomendedVisitPoints()
    {
        return funMap.VisitPoints;
    }

    public MapBase mapFormat()
    {
        return funMap;
    }
}

public class Map<T> where T : IMapCreator, new()
{
    private T mapCreator;

    public Map()
    {
        mapCreator = new T();
    }
    public void Show()
    {
        foreach (var item in mapCreator.GetrecomendedVisitPoints())
        {
            Console.WriteLine($"{mapCreator.GetType().Name}: {item.GetType().Name} {item.Icon}");
        }
    }
}