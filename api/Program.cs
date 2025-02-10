using api.Data;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IMedicalAlertTagService, MedicalAlertTagService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapGet("/GenerateQRCode", (string text) =>
{
    //generate guid
    var guid = Guid.NewGuid().ToString();
    QRCodeGenerator qrGenerator = new QRCodeGenerator();
    QRCodeData qrCodeData = qrGenerator.CreateQrCode(text + "\r\n" + guid, QRCodeGenerator.ECCLevel.Q);
    QRCode qrCode = new QRCode(qrCodeData);
    Bitmap qrCodeImage = qrCode.GetGraphic(20);
    // use this when you want to show your logo in middle of QR Code and change color of qr code
    Bitmap logoImage = new Bitmap(@"wwwroot/img/aircodlogo.jpg");
    // Generate QR Code bitmap and convert to Base64
    using (Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.WhiteSmoke, logoImage))
    {
        using (MemoryStream ms = new MemoryStream())
        {
            qrCodeAsBitmap.Save(ms, ImageFormat.Png);
            string base64String = Convert.ToBase64String(ms.ToArray());
            var data = "data:image/png;base64," + base64String;
            return data;
        }
    }
});

app.Run();
