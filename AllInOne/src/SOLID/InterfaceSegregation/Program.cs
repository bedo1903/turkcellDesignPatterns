// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
 * Bir metot, bir interface'e zorlanmamalı. Fakat bir sınıf bir interface'i implemente etmiş ise tüm metotları kullanmalı.
 * 
 * 
 */

public interface IMessage
{
    string From { get; set; }
    List<string> To { get; set; }
    string Subject { get; set; }
 


}

public interface IVideoMessage : IMessage
{
    int Duration { get; set; }
    string VideoFormat { get; set; }
    string Codec { get; set; }
}

public interface IImageMessage : IMessage
{
    int ImageSize { get; set; }
    string ImageFormat { get; set; }
}

public class TextMessage : IMessage
{
    public string From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class VideoMessage : IVideoMessage
{
    public int Duration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string VideoFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Codec { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}