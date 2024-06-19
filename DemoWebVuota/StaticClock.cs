
namespace DemoWebVuota;

public class StaticClock : IClock
{
    public DateTime Now()
    {
        return new DateTime(2024, 1, 1, 19, 0,0); ;
    }
}

public class SystemClock : IClock
{
    public DateTime Now()
    {
        return DateTime.UtcNow;
    }
}   
