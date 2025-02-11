using api.DTOs;
using api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class FakeMedicalAlertTagService : IMedicalAlertTagService
    {
        public Task<MedicalAlertTagDto> CreateMedicalAlertTagAsync(CreateMedicalAlertTagDto medicalAlertTagDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMedicalAlertTagAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicalAlertTagDto>> GetAllMedicalAlertTagsAsync()
        {
            throw new NotImplementedException();
        }

        public MedicalAlertTagDto? GetMedicalAlertTagById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalAlertTagDto?> GetMedicalAlertTagByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMedicalAlertTagAsync(Guid id, UpdateMedicalAlertTagDto medicalAlertTagDto)
        {
            throw new NotImplementedException();
        }
    }
}
