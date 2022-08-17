// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
 * PROBLEM:
 * Eğer bir inheritance stratejisi inşa ettiyseniz ve minik bir ihtiyaçta dahi bu stratejideki base class'dan miras almanız gerekiyorsa, bu gelecekte kaosa sebep olacaktır.
 * 
 * 
 */
SalesReport salesReport = new SalesReport();
salesReport.Format = new HTMLFormat();
//salesReport.Format = new PdfFormat();
salesReport.Save();

public class Report
{
    public ReportFormat Format { get; set; }
    public virtual void Save()
    {
        Console.WriteLine($"{GetType().Name} raporu {Format.GetType().Name} dosyasına kaydedildi");
    }
}

public class PerformanceReport : Report
{

}
public class SalesReport: Report
{
   
}

public class ReportFormat
{

}
public class PdfFormat:ReportFormat
{

}

public class HTMLFormat: ReportFormat
{

}

