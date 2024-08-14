using WebApplication1;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseAutofac();
builder.Services.AddApplication<MainModule>();
var app = builder.Build();
app.InitializeApplication();
app.Run();
