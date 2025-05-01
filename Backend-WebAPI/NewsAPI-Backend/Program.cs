using NewsAPI_DataAccesLayer;
using NewsAPI_DataAccesLayer.Interfaces;
using NewsAPI_ServiceLayer;
using NewsAPI_ServiceLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy(name: "MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "http://example.com") // Replace with your allowed origins
                            .AllowAnyMethod()
                            .AllowAnyHeader();
        });
});
builder.Services.AddControllers();

//Memory caching
builder.Services.AddMemoryCache();
//Dependency Injection

builder.Services.AddSingleton<INewsService, NewsService>();
builder.Services.AddSingleton<INewsData, NewsDataAccess>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else{ 
    app.UseHttpsRedirection(); // Only redirect to HTTPS in non-dev environments
}

app.UseCors("MyAllowSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
