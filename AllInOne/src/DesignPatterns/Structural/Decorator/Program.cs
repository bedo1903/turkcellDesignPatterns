// See https://aka.ms/new-console-template for more information
using System.IO.Compression;
using System.Net.Sockets;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");
/*
 * Problem:
 * 
 * Her evrimsel değişim (özellik değişimi) miras ile mi çöüzülür
 * Sütlü kahve, kahveden türer mi?
 * 
 */
//Stream stream = new FileStream("bilmemne.txt",FileMode.CreateNew);
//stream = new MemoryStream();
//stream = new NetworkStream()
//GZipStream zipped = new GZipStream(stream, CompressionLevel.SmallestSize);
//CryptoStream cryptoStream = new CryptoStream(zipped, null, CryptoStreamMode.Read);

CustomMail customMail = new CustomMail();
SignedMail signedMail = new SignedMail(customMail);
signedMail.IsSigned = true;
CryptoMail cryptoMail = new CryptoMail(signedMail);

cryptoMail.Send();

public interface IMail
{
    void Send();
}
public class CustomMail : IMail
{
    public string Body { get; set; }
    public void Send()
    {
        Console.WriteLine("Mail gönderildi");
    }
}

public class SignedMail : IMail
{
    private IMail mail;
    public SignedMail(IMail mail)
    {
        this.mail = mail;
    }

    public bool IsSigned { get; set; }
    public void Send()
    {
        if (IsSigned)
        {
            Console.WriteLine("Mail imzalandı");
        }
        mail.Send();
    }
}

public class CryptoMail : IMail
{
    private readonly IMail mail;

    public CryptoMail(IMail mail)
    {
        this.mail = mail;
    }

    public void Send()
    {
        Console.WriteLine("Mail şirfelendi");
        mail.Send();
    }

}