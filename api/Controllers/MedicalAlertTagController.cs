using api.Data;
using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace api.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class MedicalAlertTagController : ControllerBase
    {
        private readonly IMedicalAlertTagService _medicalTagService;
        public MedicalAlertTagController(IMedicalAlertTagService medicalTagService)
        {
            _medicalTagService = medicalTagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicalTags = await _medicalTagService.GetAllMedicalAlertTagsAsync();
            return Ok(medicalTags);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _medicalTagService.DeleteMedicalAlertTagAsync(id);
            return NoContent();
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var medicalTag = await _medicalTagService.GetMedicalAlertTagByIdAsync(id);  

            return medicalTag == null ? NotFound() : Ok(medicalTag);    
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMedicalAlertTagDto medicalAlertTagDto)
        {
            var medicalTag = await _medicalTagService.CreateMedicalAlertTagAsync(medicalAlertTagDto);
            return Ok(medicalTag);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMedicalAlertTagDto medicalAlertTagDto)
        {
            await _medicalTagService.UpdateMedicalAlertTagAsync(id, medicalAlertTagDto);
            return NoContent();
        }

    }
}
