using DemoWebVuota;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<Saluto>();
//builder.Services.AddSingleton<ISaluto, SalutoSpeciale>();
//builder.Services.AddSingleton<ISaluto, Saluto>();
//builder.Services.AddSingleton<IClock, SystemClock>();
//builder.Services.AddTransient<ISaluto, SalutoSpeciale>();
//builder.Services.AddTransient<ISaluto, Saluto>();
//builder.Services.AddTransient<IClock, SystemClock>();
builder.Services.AddScoped<ISaluto, SalutoSpeciale>();
builder.Services.AddScoped<ISaluto, Saluto>();
builder.Services.AddScoped<IClock, SystemClock>();


var app = builder.Build();


var logger = app.Logger;


app.UseStaticFiles();

app.Use(async (context, next) =>
{
    logger.LogInformation("First Middleware Request received");

    await next.Invoke();
});

app.Use(async (context, next) =>
{
    logger.LogInformation("Second Middleware Request received");

    await next.Invoke();
});

app.Use(async (context, next) =>
{
    logger.LogInformation("Third Middleware Request received");
    if (context.Request.Path == "/fatture")
    {
        logger.LogCritical("Non sei autorizzato!");
        await context.Response.WriteAsync("Esci Fuori");
    }
    else
    {
        await next.Invoke();
    }

});


app.MapGet("/", (ISaluto s) =>
  {


      //var myClock = new StaticClock();
      //var x = new Saluto(myClock);

    //  var sal = s.FirstOrDefault() ;
      var saluto = s.Saluta("Salvatore");
      return saluto;
  });

app.Run();
