using Microsoft.Extensions.Options;
using Repository;
using Microsoft.AspNetCore.Builder;
using Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// הוספת קונפיגורציות JWT ל-Configuration
builder.Services.Configure<MiraCohenDatabaseSettings>(
    builder.Configuration.GetSection("MiraCohenDatabaseSettings"));

builder.Services.AddSingleton<MiraCohenDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<MiraCohenDatabaseSettings>>().Value);

builder.Services.AddSingleton<IContext, MyDBContext>();
builder.Services.AddSingleton<JwtTokenService>();

// הוספת Authentication ו-JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
//במערכת שלך מספקת את כל הפרמטרים הדרושים לבדוק אם טוקן JWT Bearer Authentication הגדרת ה־ 
//הוא תקין ומאומת. זהו תהליך קרדינלי לאבטחת גישה למשאבים מוגנים באפליקציה שלך, . JWT 
//כך שרק משתמשים עם טוקן תקין יוכלו לגשת לנתונים או לפונקציות רגישות
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(builder.Configuration["Jwt:Key"]))
    };
});
//אפשרות להגדיל את המפתח

//var key = new byte[32];
//using (var rng = new RNGCryptoServiceProvider())
//{
//    rng.GetBytes(key);
//}
// המרת המפתח ל־Base64 כדי שניתן יהיה להשתמש בו בקובץ הקונפיגורציה
//var base64Key = Convert.ToBase64String(key);
//Console.WriteLine($"Generated Base64 Key: {base64Key}");

// הוספת שאר השירותים
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

var app = builder.Build();

// שימוש ב-Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// שימוש ב-HTTPS
app.UseHttpsRedirection();

// שימוש ב-Authentication ו-Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "hello Mira Cohen");
app.Run();
