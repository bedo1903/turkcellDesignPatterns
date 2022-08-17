// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LondonMeeting londonMeeting = new LondonMeeting();
ParisMeeting parisMeeting = new ParisMeeting();
IstanbulMeeting istanbulMeeting = new IstanbulMeeting();

londonMeeting.Next = parisMeeting;
parisMeeting.Next = istanbulMeeting;

Reservation reservation = new Reservation { City = "İstanbul" };
londonMeeting.Confirm(reservation);


public class ReservationEventArgs
{
    public string City { get; set; }
}
public abstract class Responsible
{
    public Responsible Next { get; set; }
    public EventHandler<ReservationEventArgs> ReservationConfirm;

    public abstract void ReservationConfirmEventHandler(object sender, ReservationEventArgs e);

    protected void OnReserved(ReservationEventArgs e)
    {
        if (ReservationConfirm != null)
        {
            ReservationConfirm(this, e);
        }
    }

    public Responsible()
    {
        ReservationConfirm += ReservationConfirmEventHandler;
    }
    public void Confirm(Reservation reservation)
    {
        ReservationEventArgs args = new ReservationEventArgs { City = reservation.City };
        OnReserved(args);
    }


}

public class LondonMeeting : Responsible
{
    public override void ReservationConfirmEventHandler(object sender, ReservationEventArgs e)
    {
        if (e.City == "London")
        {
            Console.WriteLine("Onaylandı");
        }
        else
        {
            Next.ReservationConfirmEventHandler(this, e);
        }
    }
}
public class ParisMeeting : Responsible
{
    public override void ReservationConfirmEventHandler(object sender, ReservationEventArgs e)
    {
        if (e.City == "Paris")
        {
            Console.WriteLine("Onaylandı");
        }
        else
        {
            Next.ReservationConfirmEventHandler(this, e);
        }
    }
}

public class IstanbulMeeting : Responsible
{
    public override void ReservationConfirmEventHandler(object sender, ReservationEventArgs e)
    {
        if (e.City == "İstanbul")
        {
            Console.WriteLine("Onaylandı");
        }
        else
        {
            Console.WriteLine("Belirttiğiniz şehirde hizmetimiz bulunmuyor.");
        }
    }
}

public class Reservation
{
    public string City { get; set; }
}