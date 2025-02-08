using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace api.Services
{
    public class MedicalAlertTagService : IMedicalAlertTagService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ILogger<MedicalAlertTagService> _logger;

        public MedicalAlertTagService(ApplicationDBContext dbContext, ILogger<MedicalAlertTagService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<MedicalAlertTagDto> CreateMedicalAlertTagAsync(CreateMedicalAlertTagDto medicalAlertTagDto)
        {
            var medicalTag = MedicalAlertTag.Create(
                medicalAlertTagDto.FullName,
                medicalAlertTagDto.DateOfBirth,
                medicalAlertTagDto.MedicalConditions,
                medicalAlertTagDto.Allergies,
                medicalAlertTagDto.Medications,
                medicalAlertTagDto.EmergencyContactName,
                medicalAlertTagDto.EmergencyContactPhone);

            await _dbContext.MedicalAlertTags.AddAsync(medicalTag);
            await _dbContext.SaveChangesAsync();

            return new MedicalAlertTagDto(
               medicalTag.Id,
               medicalTag.FullName,
               medicalTag.DateOfBirth,
               medicalTag.MedicalConditions,
               medicalTag.Allergies,
               medicalTag.Medications,
               medicalTag.EmergencyContactName,
               medicalTag.EmergencyContactPhone
            );
        }

        public async Task DeleteMedicalAlertTagAsync(Guid id)
        {
            var medicalTagToDelete = await _dbContext.MedicalAlertTags.FindAsync(id);
            if (medicalTagToDelete != null)
            {
                _dbContext.MedicalAlertTags.Remove(medicalTagToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MedicalAlertTagDto>> GetAllMedicalAlertTagsAsync()
        {
            return await _dbContext.MedicalAlertTags
                .AsNoTracking()
                .Select(medicalTag => new MedicalAlertTagDto(
                   medicalTag.Id,
                   medicalTag.FullName,
                   medicalTag.DateOfBirth,
                   medicalTag.MedicalConditions,
                   medicalTag.Allergies,
                   medicalTag.Medications,
                   medicalTag.EmergencyContactName,
                   medicalTag.EmergencyContactPhone
                ))
                .ToListAsync();
        }

        public async Task<MedicalAlertTagDto?> GetMedicalAlertTagByIdAsync(Guid id)
        {
            var medicalTag = await _dbContext.MedicalAlertTags
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalTag == null)
                return null;

            return new MedicalAlertTagDto(
                medicalTag.Id,
                medicalTag.FullName,
                medicalTag.DateOfBirth,
                medicalTag.MedicalConditions,
                medicalTag.Allergies,
                medicalTag.Medications,
                medicalTag.EmergencyContactName,
                medicalTag.EmergencyContactPhone
            );
        }

        public async Task UpdateMedicalAlertTagAsync(Guid id, UpdateMedicalAlertTagDto medicalAlertTagDto)
        {
            var medicalTagToUpdate = await _dbContext.MedicalAlertTags.FindAsync(id);
            if (medicalTagToUpdate is null)
                throw new ArgumentNullException($"Invalid Medical Tag Id.");
            medicalTagToUpdate.Update(
                medicalAlertTagDto.FullName,
                medicalAlertTagDto.DateOfBirth,
                medicalAlertTagDto.MedicalConditions,
                medicalAlertTagDto.Allergies,
                medicalAlertTagDto.Medications,
                medicalAlertTagDto.EmergencyContactName,
                medicalAlertTagDto.EmergencyContactPhone);
            await _dbContext.SaveChangesAsync();
        }
    }
}
