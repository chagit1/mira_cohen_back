using Microsoft.Extensions.Options;
using Repository;
using Microsoft.AspNetCore.Builder;
using Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MiraCohenDatabaseSettings>(
    builder.Configuration.GetSection("MiraCohenDatabaseSettings"));

builder.Services.AddSingleton<MiraCohenDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<MiraCohenDatabaseSettings>>().Value);

builder.Services.AddSingleton<IContext, MyDBContext>();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
var app = builder.Build();

{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "hello Mira Cohen ");
app.Run();
