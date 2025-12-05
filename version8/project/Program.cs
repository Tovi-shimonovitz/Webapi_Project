using lesson4.interfaces;
using lesson4.Services;
using LogMiddleware;
using Myuser.Services;
using user.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMusicService();
builder.Services.AddControllers();
builder.Services.AddUserService();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();//log4net seriLog
builder.Logging.AddConsole(); 


var app = builder.Build();
//app.Logger.LogInformation("Application started");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //  app.MapOpenApi(); 
    // app.UseSwaggerUI(options =>
    // {
    //     options.SwaggerEndpoint("/openapi/v1.json", "v1");
    // });
}
app.UseLogMiddleware();




app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();