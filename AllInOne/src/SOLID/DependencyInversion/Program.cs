// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//Büyük sistemler, küçük sistemlere değil; küçük sistemler büyüklere bağlı olmalı.
Report report = new Report(new MailSender());
Report report2 = new Report(new WhatsappSender());
Report report3 = new Report(new SMSSender());

public class Report
{
    private ISender sender;

    public Report(ISender sender)
    {
        this.sender = sender;
    }

    public void Send(string to)
    {      
        sender.Send(to);
    }
}

public interface ISender
{
    void Send(string to);
}
public class MailSender : ISender
{
    public void Send(string to)
    {
        Console.WriteLine($"{to} kişisine mail ile rapor gönderildi");
    }
}

public class WhatsappSender : ISender
{
    public void Send(string to)
    {
        Console.WriteLine($"{to} kişisine WS ile rapor gönderildi");
    }
}

public class SMSSender : ISender
{
    public void Send(string to)
    {
        Console.WriteLine($"{to} kişisine SMS ile rapor gönderildi");
    }
}