using api.Data;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrController : ControllerBase
    {

        private readonly IMedicalAlertTagService _medicalTagService;
        public QrController(IMedicalAlertTagService medicalTagService)
        {
            _medicalTagService = medicalTagService;
        }

        [HttpGet]
        [Route("qenerate/{id:Guid}")]
        public IActionResult GetQrCode(Guid id)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            var medicalAlertTag = _medicalTagService.GetMedicalAlertTagById(id);
            if (medicalAlertTag == null)
                return NotFound();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(medicalAlertTag.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

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
