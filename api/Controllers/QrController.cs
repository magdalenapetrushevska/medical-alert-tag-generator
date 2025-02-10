using api.Services;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrController : ControllerBase
    {

        [HttpGet]
        [Route("qenerate/{qrText}")]
        public IActionResult GetQrCode(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return File(BitmapToBytes(qrCodeImage), "image/jpeg");
        }

        [HttpGet]
        [Route("qenerate-color/{qrText}")]
        public IActionResult GetColorQrCode(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.DarkRed, Color.PaleGreen, true);

            return File(BitmapToBytes(qrCodeImage), "image/jpeg");
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
