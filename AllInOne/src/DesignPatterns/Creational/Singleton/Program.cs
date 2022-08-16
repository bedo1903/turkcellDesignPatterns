// See https://aka.ms/new-console-template for more information
var dbProcessor = DatabaseProcessor.Create();
dbProcessor.BackupCount = 2;

var alternateDbProcessor = DatabaseProcessor.Create();
Console.WriteLine(alternateDbProcessor.BackupCount);
//Bir nesnenden ugulamanın life-cycle'ı boyunca sadece ve sadece 1 adet olmasını istiyorsak bu patternden faydalanırız!

public class DatabaseProcessor
{
    private static DatabaseProcessor processor;
    private DatabaseProcessor()
    {

    }

    public int BackupCount { get; set; }

    public static DatabaseProcessor Create()
    {
        if (processor == null)
        {
            processor = new DatabaseProcessor();
        }

        return processor;
    }

}
