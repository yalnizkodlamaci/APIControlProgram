var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.MapPost("/Mesaj", async (HttpRequest request) =>
{
    using var reader = new StreamReader(request.Body);
    string gelenMesaj = await reader.ReadToEndAsync();
    Console.WriteLine($"Gelen Mesaj : {gelenMesaj} ");
    return ("Mesaj API Penceresinde Gözüktü.");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
