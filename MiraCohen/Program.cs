using Microsoft.Extensions.Options;
using Repository;
using Microsoft.AspNetCore.Builder;
using Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MiraCohenDatabaseSettings>(
    builder.Configuration.GetSection("MiraCohenDatabaseSettings"));

// הוספת תמיכה בהזרקת המחלקה
builder.Services.AddSingleton<MiraCohenDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<MiraCohenDatabaseSettings>>().Value);

builder.Services.AddSingleton<IContext, MyDBContext>();

//builder.Services.AddControllers()


builder.Services.AddControllers();
    //.AddNewtonsoftJson(options =>
    //{
    //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    //});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
var app = builder.Build();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "hello Mira Cohen ");
app.Run();
