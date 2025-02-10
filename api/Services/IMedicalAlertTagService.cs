using api.DTOs;

namespace api.Services
{
    public interface IMedicalAlertTagService
    {
        Task<MedicalAlertTagDto> CreateMedicalAlertTagAsync(CreateMedicalAlertTagDto medicalAlertTagDto);
        Task<MedicalAlertTagDto?> GetMedicalAlertTagByIdAsync(Guid id);
        MedicalAlertTagDto? GetMedicalAlertTagById(Guid id);
        Task<IEnumerable<MedicalAlertTagDto>> GetAllMedicalAlertTagsAsync();
        Task UpdateMedicalAlertTagAsync(Guid id, UpdateMedicalAlertTagDto medicalAlertTagDto);
        Task DeleteMedicalAlertTagAsync(Guid id);
    }
}
