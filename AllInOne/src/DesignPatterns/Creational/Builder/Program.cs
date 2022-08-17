// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//Problem: Bir nesneyi oluşturma işi birçok aşamadan geçmektedir. Her aşamayı adım adım takip etmek (constructor'dan çağırmak) kaosa sebep olabilir. Bu adımları düzenlemek için Builder kullanılabilir.

ReportCreator reportCreator = new ReportCreator();
reportCreator.Create(new PerformanceReportBuilder());
reportCreator.Show();





//Enum
public enum ReportParts
{
    Title,
    Graph,
    Sign,
    Data
}

public enum ReportTypes
{
    Performance,
    Sales
}

//Elde etmek istediğimiz nesne:
public class Report
{
    private Dictionary<ReportParts, string> parts = new Dictionary<ReportParts, string>();
    private ReportTypes reportType;
    

    public Report(ReportTypes reportTypes)
    {
        this.reportType = reportTypes;
    }

    public string this[ReportParts part]
    {
        get { return parts[part]; }
        set { parts[part] = value; }
    }

    public void Demo()
    {
        Console.WriteLine($"{this.reportType} türünde rapor oluşturuldu:");
        Console.WriteLine($"Rapor başlığı: {this[ReportParts.Title]}");
        Console.WriteLine($"Rapor verisi: {this[ReportParts.Data]}");
        Console.WriteLine($"Rapor grafiği: {this[ReportParts.Graph]}");
        Console.WriteLine($"Rapor imzsı: {this[ReportParts.Sign]}");

    }


}
//Pattern burada başlıyor
public abstract class ReportBuilder
{
    public Report Report { get; private set; }
    public ReportBuilder(ReportTypes type)
    {
        Report = new Report(type);            
    }

    public abstract void CreateTitle();
    public abstract void CreateData();
    public abstract void CreateGraph();
    public abstract void CreateSign();
}

public class PerformanceReportBuilder : ReportBuilder
{
    public PerformanceReportBuilder():base( ReportTypes.Performance)
    {

    }
    public override void CreateData()
    {
        this.Report[ReportParts.Data] = "Çalışan performans verisi";
    }

    public override void CreateGraph()
    {
        this.Report[ReportParts.Graph] = "Çalışan performans grafiği";

    }

    public override void CreateSign()
    {
        this.Report[ReportParts.Sign] = "Çalışan performans raporunun imzası....";

    }

    public override void CreateTitle()
    {
        this.Report[ReportParts.Title] = "Çalışan performans rapor başlığı....";

    }
}

public class SalesReportBuilder : ReportBuilder
{
    public SalesReportBuilder(): base(ReportTypes.Sales)
    {

    }
    public override void CreateData()
    {
         this.Report[ReportParts.Data] = "Satış raporu verisi";
    }

    public override void CreateGraph()
    {
        this.Report[ReportParts.Graph] = "Satış grafiği";

    }

    public override void CreateSign()
    {
        this.Report[ReportParts.Sign] = "Satış raporundaki imza";
    }

    public override void CreateTitle()
    {
        this.Report[ReportParts.Title] = "Satış raporunun başlığı";
    }
}

public class ReportCreator
{
    private ReportBuilder reportBuilder;
    public void Create(ReportBuilder reportBuilder)
    {
        this.reportBuilder = reportBuilder;
        reportBuilder.CreateTitle();
        reportBuilder.CreateData();
        reportBuilder.CreateGraph();
        reportBuilder.CreateSign();
    }
    public void Show()
    {
        reportBuilder.Report.Demo();
    }
    public Report GetReport()
    {
        return reportBuilder.Report;
    }
}