namespace DemoWebVuota;

public class Saluto : ISaluto
{
    private readonly IClock clock;
    private readonly IConfiguration configuration;

    public Saluto(IClock clock, IConfiguration configuration)
    {
        this.clock = clock;
        this.configuration = configuration;
    }

    public string Saluta(string nome)
    {
        if (clock.Now().Hour < 12)
        {
            return $"Buongiorno {configuration["Saluto"]}, {nome}!";
        }
        else
        {
            return $"Buonasera {configuration["Saluto"]}, {nome}!";
        }
    }

    
}

public class SalutoSpeciale : ISaluto
{
    public string Saluta(string nome)
    {
        return $"Ciao {nome}! Come stai?";
    }
}